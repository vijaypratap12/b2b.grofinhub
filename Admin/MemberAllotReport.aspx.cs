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
public partial class MemberAllotReport : System.Web.UI.Page
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
                totalRegistration.Text = "0";
            }
        }
        else
        {
            Response.Redirect("/Admin/login.aspx");
        }
    }

   
    protected void totalRegistration_Load(object sender, EventArgs e)
    {
        SqlDataAdapter sda = new SqlDataAdapter("select count(*) totalRegistration from tbl_Registration where Active = 1 and role<>1", con);
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

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "4.1");

            cmd.Parameters.AddWithValue("@FromDate", FromDate == "" ? null : FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate == "" ? null : ToDate);
            cmd.Parameters.AddWithValue("@StateId", State == "" ? null : State);
            cmd.Parameters.AddWithValue("@DistrictId", District == "" ? null : District);
            cmd.Parameters.AddWithValue("@BlockId", Block == "" ? null : Block);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record not found... ');window.location='MemberAllotReport.aspx';", true);
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


