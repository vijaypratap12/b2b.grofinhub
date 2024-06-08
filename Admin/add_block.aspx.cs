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

public partial class add_block : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["username"] != null)
            {
                //readrights();
                //gridbind();

                if (lbledit.Text == "False")
                {
                    GridView2.Columns[2].Visible = false;
                }
                if (lbldelete.Text == "False")
                {
                    GridView2.Columns[3].Visible = false;
                }
                bindSate();

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    protected void readrights()
    {
        //SqlConnection con = new SqlConnection(obj.str);
        //SqlDataReader drr;
        //con.Open();
        //cmd = new SqlCommand("select edit_data,delete_data from login where username='" + Session["username"].ToString() + "'", con);
        //drr = cmd.ExecuteReader();
        //if (drr.Read())
        //{
        //    lbledit.Text = drr["edit_data"].ToString();
        //    lbldelete.Text = drr["delete_data"].ToString();
        //}
        //con.Close();
    }
    public void bindproperty()
    {
        GridView2.DataSource = null;
        GridView2.DataBind();

        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT Id , DistrictName  FROM tbl_District WHERE Status='1' and StateId = '" + ddlstate.SelectedValue + "'  ", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        ddlproperty.DataSource = ds;
        ddlproperty.DataTextField = "DistrictName";
        ddlproperty.DataValueField = "Id";
        ddlproperty.DataBind();
        ddlproperty.Items.Insert(0, new ListItem("--Select --", "0"));
        //   ddlproperty.Items.Insert(0, "Select");

        con.Close();
    }
    public void gridbind()
    {
        //SqlCommand cmd = new SqlCommand("SELECT  b.DistrictName , a.BlockName , * FROM tbl_Block a JOIN tbl_District b  ON a.StateId=b.Id WHERE a.Status='1'  ", con);

        try
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
            con.Open();
            //string query = "select a.id,a.StateId,a.BlockName,b.Id as DistrictId, b.DistrictName from tbl_Block a JOIN tbl_District b ON a.StateId = b.StateId where a.Status = 1 and a.StateId = ISNULL(" + ddlstate.SelectedValue + ", a.StateId) and b.Id = ISNULL(" + ddlproperty.SelectedValue + ", b.Id) order by a.BlockName,a.StateId";

            string state = ddlstate.SelectedValue == "0" ? null : ddlstate.SelectedValue;
            string District = ddlproperty.SelectedValue == "0" ? null : ddlproperty.SelectedValue;

            string query = "select * from State_District_Block_View where StateId = ISNULL(" + state + ", StateId) and DistrictId = ISNULL(" + District + ", DistrictId) ORDER BY StateName, BlockName";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
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
    public void gridsearchbind()
    {

        //SqlCommand cmd = new SqlCommand("SELECT  b.DistrictName , a.BlockName , * FROM tbl_Block a JOIN tbl_District b  ON a.StateId=b.Id WHERE a.Status='1' and b.Id = '" + ddlproperty.SelectedValue + "'", con);

        try
        {
            //string query = "select a.id,a.StateId,a.BlockName,b.Id as DistrictId, b.DistrictName from tbl_Block a JOIN tbl_District b ON a.StateId = b.StateId where a.Status = 1 and a.StateId = ISNULL(" + ddlstate.SelectedValue + ", a.StateId) and b.Id = ISNULL(" + ddlproperty.SelectedValue + ", b.Id) order by a.BlockName,a.StateId";

            string state = ddlstate.SelectedValue == "0" ? null : ddlstate.SelectedValue;
            string District = ddlproperty.SelectedValue == "0" ? null : ddlproperty.SelectedValue;

            string query = "select * from State_District_Block_View where StateId = ISNULL(" + state + ", StateId) and DistrictId = ISNULL(" + District + ", DistrictId) ORDER BY StateName, BlockName";

            GridView2.DataSource = null;
            GridView2.DataBind();

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Button1.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_InsertBlockMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateId", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@DistrictId", ddlproperty.SelectedValue);
                cmd.Parameters.AddWithValue("@BlockName", txtblock.Text.Trim());

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.ExecuteNonQuery();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ID"].ToString() != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Block added succesfully');", true);
                        clear();
                        con.Close();
                        gridbind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Block Already Exist under the site!');", true);
                    }
                }
            }
            else if (Button1.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_UpdateBlock1Master", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateId", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@DistrictId", ddlproperty.SelectedValue);
                cmd.Parameters.AddWithValue("@BlockName", txtblock.Text.Trim());
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Block updated successfully');", true);
                        clear();
                        con.Close();
                        gridbind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Block Already Exist under the site!');", true);
                }
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

    public void clear()
    {
        //ddlproperty.SelectedIndex = 0;
        txtblock.Text = "";

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string number = e.CommandArgument.ToString();

        if (e.CommandName == "Edit1")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Block  WHERE Id ='" + e.CommandArgument.ToString() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtblock.Text = dr["BlockName"].ToString();
                lblentryid.Text = dr["Id"].ToString();
                Button1.Text = "Update";
            }
            con.Close();
            dr.Close();
        }
        else if (e.CommandName == "Delete1")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Block set Status='0'  where Id='" + number + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Block deleted successfully');", true);
            con.Close();
            gridbind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Block cannot be deleted');", true);
        }
    }



    protected void ddlproperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridsearchbind();
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindproperty();
    }

    public void bindSate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT Id , StateName  FROM tbl_State WHERE Status='1' ", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        ddlstate.DataSource = ds;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "Id";
        ddlstate.DataBind();

        ddlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
        ddlproperty.Items.Insert(0, new ListItem("--NA--", "0"));
        //ddlstate.Items.Insert(0, new ListItem("--Select --", "0"));
        //ddlproperty.Items.Insert(0, "Select");

        con.Close();
    }
}



