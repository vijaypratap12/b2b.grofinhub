using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Web.Services;
public partial class registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());

    static bool vcaptcha = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindproperty();
            Qualification();
        }
    }
    public void bindproperty()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id , StateName  FROM tbl_State WHERE Status='1' ORDER BY StateName ASC  ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ddlproperty.DataSource = ds;
            ddlproperty.DataTextField = "StateName";
            ddlproperty.DataValueField = "Id";
            ddlproperty.DataBind();
            //ddlproperty.Items.Insert(0, "Select State");
            ddlproperty.Items.Insert(0, new ListItem("--Select State--", "0"));
            ddldistrict.Items.Insert(0, new ListItem("--NA--", "0"));
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        finally
        {
            con.Close();
        }
    }

    public void Qualification()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Id,QaulificationName from tbl_qualification where IsActive=1 order by QaulificationName  ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ddlQualification.DataSource = ds;
            ddlQualification.DataTextField = "QaulificationName";
            ddlQualification.DataValueField = "Id";
            ddlQualification.DataBind();
            ddlQualification.Items.Insert(0, new ListItem("--Select Qualification--", "0"));
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        finally
        {
            con.Close();
        }
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (vcaptcha == true)
                {
                    string query = "Usp_Registration";

                    con.Open();
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[8];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var RandamPassword = new String(stringChars);

                    string str = "";
                    string Image = "";
                    string Aadharchard = "";
                    string Pancard = "";
                    string Qualification = "";

                    #region UPLOAD
                    if (FileUpload1.HasFile)
                    {
                        HttpPostedFile _HttpPostedFile = FileUpload1.PostedFile;
                        str = FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("Uploads/" + str));
                        Image = "Uploads/" + str.ToString();
                        Aadharchard = str;
                    }

                    if (FileUpload2.HasFile)
                    {
                        HttpPostedFile _HttpPostedFile = FileUpload2.PostedFile;
                        str = FileUpload2.FileName;
                        FileUpload2.PostedFile.SaveAs(Server.MapPath("Uploads/" + str));
                        Image = "Uploads/" + str.ToString();
                        Pancard = str;
                    }

                    if (FileUpload3.HasFile)
                    {
                        HttpPostedFile _HttpPostedFile = FileUpload3.PostedFile;
                        str = FileUpload3.FileName;
                        FileUpload3.PostedFile.SaveAs(Server.MapPath("Uploads/" + str));
                        Image = "Uploads/" + str.ToString();
                        Qualification = str;
                    }
                    #endregion

                    string company = rdbAssociatedCompany.SelectedItem.Text;
                    string Agent = rdbfamilyInsurance.SelectedItem.Text;
                    string Mutual = rdbfamilyMutual.SelectedItem.Text;

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Password", RandamPassword);
                    cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile ", txtmobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@AadharCard", "");
                    cmd.Parameters.AddWithValue("@PanCard", "");
                    cmd.Parameters.AddWithValue("@Qualification ", ddlQualification.SelectedValue);
                    cmd.Parameters.AddWithValue("@AssociateCompany", company);
                    cmd.Parameters.AddWithValue("@AssociateMutual", Mutual);
                    cmd.Parameters.AddWithValue("@AssociateCompanyAgent", Agent);
                    cmd.Parameters.AddWithValue("@StateId", ddlproperty.SelectedValue);
                    cmd.Parameters.AddWithValue("@DistrictId", ddldistrict.SelectedValue);
                    cmd.Parameters.AddWithValue("@BlockId", ddlblock.SelectedValue);

                    DateTime Dob = Convert.ToDateTime(txtdob.Text);
                    DateTime today = DateTime.Now;
                    int diff = today.Year - Dob.Year;
                    if (diff >= 18)
                    {
                        cmd.Parameters.AddWithValue("@Dob", txtdob.Text.Trim());
                        cmd.Parameters.AddWithValue("@Action", 1);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt != null)
                            {
                                if (dt.Rows[0]["msg"].ToString() == "error")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Mobile No already exist. Contact to Customer care.');window.location ='registration.aspx';", true);
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Your Application has been saved succesfully. Our Team will contact you soon');window.location ='registration.aspx';", true);
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Age should not be less than 18');", true);
                        txtdob.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Captcha!');", true);
                    txtCaptcha.Focus();
                    txtCaptcha.Text = "";
                    return;
                }
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }

    //Captcha
    protected void ValidateCaptcha(object sender, ServerValidateEventArgs e)
    {
        Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
        e.IsValid = Captcha1.UserValidated;
        if (e.IsValid)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Valid Captcha!');", true);
            //   ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Valid Captcha!');", true);
            vcaptcha = true;
        }
        else
        {
            //  ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('InValid Captcha!');", true);
            vcaptcha = false;
            return;
        }
    }
    //Captcha

    protected void ddlproperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDistrict();
    }


    public void bindDistrict()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id , DistrictName  FROM tbl_District WHERE Status='1' and  StateId='" + ddlproperty.SelectedValue + "' ORDER BY DistrictName ASC  ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                ddldistrict.DataSource = ds;
                ddldistrict.DataTextField = "DistrictName";
                ddldistrict.DataValueField = "Id";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("--Select District--", "0"));
            }
            else
            {
                ddldistrict.Items.Clear();
                ddldistrict.DataSource = null;
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("--NA--", "0"));
            }
        }
        catch (Exception ex)
        {
            con.Close();
        }
        finally
        {
            con.Close();
        }
    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindBlock();
    }

    public void bindBlock()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select id,BlockName from State_District_Block_View where StateId = " + ddlproperty.SelectedValue + " and DistrictId = " + ddldistrict.SelectedValue + " ORDER BY StateName, BlockName", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        ddlblock.DataSource = ds;
        ddlblock.DataTextField = "BlockName";
        ddlblock.DataValueField = "Id";
        ddlblock.DataBind();
        ddlblock.Items.Insert(0, "Select Block");

        con.Close();
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = termsAndCondtion.Checked;
    }
}
