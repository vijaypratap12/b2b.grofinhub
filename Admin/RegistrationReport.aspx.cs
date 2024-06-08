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
using stablishconnection;
public partial class Admin_RegistrationReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["username"] != null)
        {
            string userid = "";
            if (!IsPostBack)
            {
                userid = Session["username"].ToString();

                bindState();
                //BindRegistration();
                totalRegistration.Text = "0";
            }


        }
        else
        {
            Response.Redirect("/Admin/login.aspx");
        }
    }

    public void BindRegistration()
    {
        try
        {
            rptRegistration.DataSource = null;
            rptRegistration.DataBind();

            string query = "USP_Registration";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", 2);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                rptRegistration.DataSource = dt;
                rptRegistration.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void rptRegistration_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();

        if (e.CommandName == "UnderProcess")
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update tbl_Registration set Status = 'Under Process' where Id=" + id + "", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                Response.Write("<script>alert('Status updated Successfully...')</script>");
                BindRegistration();
            }
        }
        else if (e.CommandName == "Alot")
        {
            string query = "USP_Registration";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", 27);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('Status Alot  Successfully.')</script>");
                BindRegistration();
            }
        }
        else if (e.CommandName == "Hold")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Registration set Status='Hold' where Id=" + id + "", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                Response.Write("<script>alert('Status Hold Successfully.')</script>");
                BindRegistration();
            }
        }
        if (e.CommandName == "Reject")
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update tbl_Registration set Status='Reject' where Id=" + id + "", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                Response.Write("<script>alert('Status Reject Successfully.')</script>");
                BindRegistration();
            }
        }
        if (e.CommandName == "Delete")
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("delete from tbl_Registration where Id=" + id + "", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                Response.Write("<script>alert('Delete Successfully.')</script>");
                BindRegistration();
            }
        }


        if (e.CommandName == "Unblock")
        {
            con.Open();
            string Agentid = e.CommandArgument.ToString();

            SqlCommand cmd1 = new SqlCommand("usp_OTP", con);
            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.CommandTimeout = 0;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Agentid", Agentid);
            cmd1.Parameters.AddWithValue("@Action", 4);

            SqlDataAdapter da = new SqlDataAdapter(cmd1);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + dt.Rows[0]["msg"] + "');", true);
                BindRegistration();
            }
        }
        if (e.CommandName == "SeeDetails")
        {
            //Response.Redirect("gst_bill.aspx?code=" + id + "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('RegistrationDetail.aspx?code=" + id + "','_new');", true);
        }
    }

    protected void totalRegistration_Load(object sender, EventArgs e)
    {
        SqlDataAdapter sda = new SqlDataAdapter("select count(*) totalRegistration from tbl_Registration where Active = 1 and role<>1 and UPPER(status)<>'ALOT' ", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            totalRegistration.Text = Convert.ToString("Total Registration : " + (dt.Rows[0]["totalRegistration"]));
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string query = "USP_Registration";

            string FromDate = "";
            string ToDate = "";

            if (txtfromdate.Text.Trim() != "")
            {
                FromDate = txtfromdate.Text.Trim();
            }

            if (txttodate.Text.Trim() != "")
            {
                ToDate = txttodate.Text.Trim();
            }

            string State = "";


            if (ddlstate.SelectedValue != "0")
            {
                State = ddlstate.SelectedValue;
            }

            string District = "";


            if (ddldistrict.SelectedValue != "0")
            {
                District = ddldistrict.SelectedValue;
            }

            string Block = "";

            if (ddlblock.SelectedValue != "0")
            {
                Block = ddlblock.SelectedValue;
            }


            string Status = "";

            if (ddlstatus.SelectedValue != "0")
            {
                Status = ddlstatus.SelectedItem.Text.Trim();
            }


            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", 4);

            cmd.Parameters.AddWithValue("@FromDate", FromDate == "" ? null : FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate == "" ? null : ToDate);
            cmd.Parameters.AddWithValue("@StateId", State == "" ? null : State);
            cmd.Parameters.AddWithValue("@DistrictId", District == "" ? null : District);
            cmd.Parameters.AddWithValue("@BlockId", Block == "" ? null : Block);
            cmd.Parameters.AddWithValue("@Status", Status == "" ? null : Status);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                totalRegistration.Text = "Total Registration : " + dt.Rows.Count.ToString();
                rptRegistration.DataSource = dt;
                rptRegistration.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record not found... ');window.location='RegistrationReport.aspx';", true);
            }
        }
        catch (Exception ex)
        {
        }
    }




    protected void ExportToPrint_Click(object sender, EventArgs e)
    {

        try
        {
            string query = "USP_Registration";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "4");
            cmd.Parameters.AddWithValue("@FromDate", txtfromdate.Text == "" ? null : txtfromdate.Text);
            cmd.Parameters.AddWithValue("@ToDate", txttodate.Text == "" ? null : txttodate.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=RepeaterExport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        Response.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
        }


    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDistrict();
    }
    public void bindState()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id , StateName  FROM tbl_State WHERE Status='1' ORDER BY StateName ASC  ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ddlstate.DataSource = ds;
            ddlstate.DataTextField = "StateName";
            ddlstate.DataValueField = "Id";
            ddlstate.DataBind();
            //ddlproperty.Items.Insert(0, "Select State");
            ddlstate.Items.Insert(0, new ListItem("--All--", "0"));
            ddldistrict.Items.Insert(0, new ListItem("--All--", "0"));
            ddlblock.Items.Insert(0, new ListItem("--All--", "0"));
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


    public void bindDistrict()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id , DistrictName  FROM tbl_District WHERE Status='1' and StateId='" + ddlstate.SelectedValue + "'  ORDER BY DistrictName ASC  ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                ddldistrict.DataSource = ds;
                ddldistrict.DataTextField = "DistrictName";
                ddldistrict.DataValueField = "Id";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("--All--", "0"));
                ddlblock.Items.Insert(0, new ListItem("--All--", "0"));
                //   ddldistrict.Items.Insert(0, new ListItem("--Select District--", "0"));
            }
            else
            {
                ddldistrict.Items.Clear();
                ddldistrict.DataSource = null;
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("--All--", "0"));
                ddlblock.Items.Insert(0, new ListItem("--All--", "0"));
                //ddldistrict.Items.Insert(0, new ListItem("--NA--", "0"));
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
        SqlCommand cmd = new SqlCommand("SELECT Id , BlockName  FROM tbl_Block WHERE Status='1' and StateId=" + ddlstate.SelectedValue + " and DistrictId=" + ddldistrict.SelectedValue + "  ORDER BY BlockName ASC ", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        ddlblock.DataSource = ds;
        ddlblock.DataTextField = "BlockName";
        ddlblock.DataValueField = "Id";
        ddlblock.DataBind();
        ddlblock.Items.Insert(0, new ListItem("--All--", "0"));
        //ddlblock.Items.Insert(0, "Select Block");

        con.Close();
    }

}


