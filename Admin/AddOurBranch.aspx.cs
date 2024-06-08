using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using stablishconnection;

public partial class AddOurBranch : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["username"] != null)
            {
                bindState();
                gridbind();

                if (lbledit.Text == "False")
                {
                    GridView2.Columns[2].Visible = false;
                }
                if (lbldelete.Text == "False")
                {
                    GridView2.Columns[3].Visible = false;
                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }

    public void bindState()
    {
        try
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT Id , StateName  FROM tbl_State WHERE Status='1' ORDER BY StateName ASC  ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ddlstate.DataSource = ds;
            ddlstate.DataTextField = "StateName";
            ddlstate.DataValueField = "Id";
            ddlstate.DataBind();

            ddlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
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
    public void bindDistrict()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT Id , DistrictName  FROM tbl_District WHERE  StateId='" + ddlstate.SelectedValue + "' and Status='1' ", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        ddldistrict.DataSource = ds;
        ddldistrict.DataTextField = "DistrictName";
        ddldistrict.DataValueField = "Id";
        ddldistrict.DataBind();

        ddldistrict.Items.Insert(0, new ListItem("--Select District--", "0"));
        ddlblock.Items.Insert(0, new ListItem("--NA--", "0"));
        con.Close();
    }

    public void bindBlock()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT Id , BlockName  FROM tbl_Block WHERE StateId='" + ddldistrict.SelectedValue + "' and Status='1' ORDER BY BlockName ASC ", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        ddlblock.DataSource = ds;
        ddlblock.DataTextField = "BlockName";
        ddlblock.DataValueField = "Id";
        ddlblock.DataBind();
        ddlblock.Items.Insert(0, new ListItem("--Select Block--", "0"));
        con.Close();
    }
    public void gridbind()
    {

        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT  a.Id, b.BlockName , a.BranchName ,a.BranchMobile  FROM tbl_Branch a JOIN tbl_Block b  ON a.BlockId=b.Id WHERE a.Status='1'", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt != null && dt.Rows.Count > 0)
        {

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
        con.Close();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (Button1.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_InsertBranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateId", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@DistrictId", ddldistrict.SelectedValue);
                cmd.Parameters.AddWithValue("@BlockId", ddlblock.SelectedValue);
                cmd.Parameters.AddWithValue("@BranchName", txtblock.Text.Replace("'", "''").Trim());
                cmd.Parameters.AddWithValue("@BranchMobile", txtMobile.Text.Trim());

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.ExecuteNonQuery();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    if (ds.Tables[0].Rows[0]["ID"].ToString() != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Branch added succesfully');", true);
                        clear();
                        con.Close();

                        gridbind();



                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Branch Already Exist under the site!');", true);

                    }
                }
            }
            else if (Button1.Text == "Update")
            {

                con.Open();


                SqlCommand cmd = new SqlCommand("USP_UpdateBranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateId", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@DistrictId", ddldistrict.SelectedValue);
                cmd.Parameters.AddWithValue("@BlockId", ddlblock.SelectedValue);
                cmd.Parameters.AddWithValue("@BranchName", txtblock.Text.Replace("'", "''").Trim());
                cmd.Parameters.AddWithValue("@BranchMobile", txtMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@entryid", lblentryid.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.ExecuteNonQuery();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Id"].ToString() != "0")
                    {

                        Button1.Text = "Submit";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Branch updated successfully');", true);
                        clear();
                        con.Close();
                        gridbind();
                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Branch Already Exist under the site!');", true);

                }
            }


        }

        catch (Exception ex)
        {

        }
    }

    public void clear()
    {
        ddlstate.SelectedIndex = 0;
        ddldistrict.SelectedIndex = 0;
        ddlblock.SelectedIndex = 0;
        txtblock.Text = "";
        txtMobile.Text = "";

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
        SqlCommand cmd = null;

        try
        {
            string number = e.CommandArgument.ToString();

            if (e.CommandName == "Edit1")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_Branch  WHERE Id ='" + e.CommandArgument.ToString() + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    bindState();
                    ddlstate.SelectedValue = Convert.ToString(dt.Rows[0]["StateId"]);
                    ddlstate_SelectedIndexChanged(sender, e);
                    bindDistrict();
                    ddldistrict.SelectedValue = Convert.ToString(dt.Rows[0]["DistrictId"]);
                    ddldistrict_SelectedIndexChanged(sender, e);
                    bindBlock();
                    ddlblock.SelectedValue = Convert.ToString(dt.Rows[0]["BlockId"]);
                    txtblock.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
                    txtMobile.Text = Convert.ToString(dt.Rows[0]["BranchMobile"]);
                    lblentryid.Text = Convert.ToString(dt.Rows[0]["Id"]);

                    Button1.Text = "Update";
                }

           
            }
            else if (e.CommandName == "Delete1")
            {
                cmd = new SqlCommand("update tbl_Branch set Status='0'  where Id='" + number + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Branch deleted successfully');", true);
                gridbind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Branch cannot be deleted');", true);
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
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDistrict();
    }


    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindBlock();
    }
}



