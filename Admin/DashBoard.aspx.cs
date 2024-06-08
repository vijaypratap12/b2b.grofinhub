using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class DashBoard : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["username"] != null)
            {
                ssnValue.Text = Session["username"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
             
        }
    }

    protected void totalImage_Load(object sender, EventArgs e)
    {
        // SqlDataAdapter sda = new SqlDataAdapter("select count(*) ImgCount from TblGallery where Active = 1", con);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        //if (dt.Rows.Count > 0)
        //{
        //    totalImage.Text = Convert.ToString("Total Images in Gallery : " + (dt.Rows[0]["ImgCount"]));
        //}
     }

    protected void totalContact_Load(object sender, EventArgs e)
    {
        //SqlDataAdapter sda = new SqlDataAdapter("select count(*) totalContact from Tbl_Contact where Active = 1", con);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        //if (dt.Rows.Count > 0)
        //{
        //    totalContact.Text = Convert.ToString("Total Contact Us : " + (dt.Rows[0]["totalContact"]));
        //}
    }

    protected void totalEnquiry_Load(object sender, EventArgs e)
    {
        //SqlDataAdapter sda = new SqlDataAdapter("select count(*) totalEnquiry from newwaydb.[dbo.Tbl_Enquiry] where Active = 1", con);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);

        //if (dt.Rows.Count > 0)
        //{
        //    totalEnquiry.Text = Convert.ToString("Total Enquiry  : " + (dt.Rows[0]["totalEnquiry"]));
        //}
    }

    protected void totalRegistration_Load(object sender, EventArgs e)
    {
        SqlDataAdapter sda = new SqlDataAdapter("select count(*) totalRegistration from tbl_Registration where Active = 1", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            totalRegistration.Text = Convert.ToString("Total Registration : " + (dt.Rows[0]["totalRegistration"]));
        }
    }
}