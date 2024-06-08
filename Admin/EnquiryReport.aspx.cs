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
public partial class Admin_EnquiryReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userid = "";
            if (Session["username"] != null)
            {
                userid = Session["username"].ToString();
                BindEnquiryDetails();
            }
            else
            {
                Response.Redirect("/Admin/login.aspx");
            }
        }
    }

    public void BindEnquiryDetails()
    {

        try
        {
            string query = "USP_Enquiry";

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
                rptGallery.DataSource = dt;
                rptGallery.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void rptGallery_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();

        if (e.CommandName == "Delete")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from newwaydb.[dbo.Tbl_Enquiry] where id=" + id + "", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Deleted Successfully... ');window.location='EnquiryReport.aspx';", true);
            }
        }
    }
     

    protected void totalEnquiry_Load(object sender, EventArgs e)
    {
        SqlDataAdapter sda = new SqlDataAdapter("select count(*) totalEnquiry from newwaydb.[dbo.Tbl_Enquiry] where Active = 1", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            totalEnquiry.Text = Convert.ToString("Total Enquiry  : " + (dt.Rows[0]["totalEnquiry"]));
        }
    }
}