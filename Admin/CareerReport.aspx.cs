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

public partial class Admin_CareerReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());

    public static string Editid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userid = "";
            if (Session["username"] != null)
            {
                userid = Session["username"].ToString();

            }
            else
            {
                Response.Redirect("/Admin/login.aspx");
            }
            //BindGalleryDetails();
            //pnlaboutUpdate.Visible = false;
            //Panel2.Visible = false;
            //Image2.Visible = false;


            pnlaboutView.Visible = true;
        }

    }
    public void BindCareersDetails()
    {
        string query = "usp_Careers";

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
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }

    protected void btnaboutView_Click(object sender, EventArgs e)
    {
        //pnlaboutnNew.Visible = false;

        BindCareersDetails();
        pnlaboutView.Visible = true;

        //btnreset.Visible = false;
        //btnsave.Visible = false;
    }

    //protected void btnaboutreset_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("AddNews.aspx");
    //}

    //protected void btnreturenupdate_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("AddNews.aspx");
    //}

    //protected void imgbtnaboutEdit_Click(object sender, ImageClickEventArgs e)
    //{

    //    pnlaboutsave.Visible = false;
    //    pnlaboutUpdate.Visible = true;
    //    pnlaboutnNew.Visible = true;
    //    pnlaboutView.Visible = false;
    //    Panel2.Visible = true;
    //    //Image2.Visible = true;



    //    Editid = ((sender as ImageButton).CommandArgument).ToString();
    //    ViewState["ImageId"] = Editid;
    //    try
    //    {
    //        if (Editid.ToString() != "")
    //        {
    //            string Sql = "Usp_News";

    //            SqlCommand cmd = new SqlCommand(Sql, con);
    //            cmd.CommandTimeout = 0;
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            cmd.Parameters.AddWithValue("@Action", 3);
    //            cmd.Parameters.AddWithValue("@Id", Editid);

    //            DataTable dt = new DataTable();

    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
    //            da.Fill(dt);

    //            if (dt.Rows.Count > 0)
    //            {

    //                txttitle.Text = Convert.ToString(dt.Rows[0]["Heading"]);
    //                //ViewState["ImageFile"] = dt.Rows[0]["Image"].ToString();
    //                //txtcreator.Text = Convert.ToString(dt.Rows[0]["Created_By"]);
    //                txtnews.Text = Convert.ToString(dt.Rows[0]["News_Link"]);
    //                //Image2.ImageUrl = "../Admin/ImageGallery/" + dt.Rows[0]["Image"].ToString();




    //            }
    //        }

    //    }

    //    catch (Exception ex)
    //    {

    //    }


    //}


    protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
    {

        string Id = ((sender as ImageButton).CommandArgument).ToString();

        try
        {
            if (Id.ToString() != "")
            {


                con.Open();

                string Sql = "usp_Careers";
                SqlCommand cmd1 = new SqlCommand(Sql, con);
                cmd1.CommandTimeout = 0;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Id", Id);
                cmd1.Parameters.AddWithValue("@Action", 3);
                int n = cmd1.ExecuteNonQuery();
                if (n > 0)
                {
                    Response.Write("<script>alert('Record Delete successfull')</script>");
                    //string Msg = "Record has Delete Successfully!";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "alert('" + Msg + "');", true);

                    //pnlaboutUpdate.Visible = false;

                }
                con.Close();
                BindCareersDetails();
            }
        }

        catch (Exception ex)
        {

        }
    }
}