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


public partial class Admin_RegistrationDetail : System.Web.UI.Page
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

                if (Request.QueryString["code"] != null && Request.QueryString["code"] != string.Empty)
                {
                    string AppNo = Request.QueryString["code"];
                    BindRegistration(AppNo);
                }                
            }
            else
            {
                Response.Redirect("/Admin/login.aspx");
            }


             

        }
    }


    public void BindRegistration(string AppNo)
    {

        try
        {
            string query = "USP_Registration";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", 7);
            cmd.Parameters.AddWithValue("@AppNo", AppNo);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                rptRegistration.DataSource = dt;
                rptRegistration.DataBind();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                Repeater2.DataSource = dt;
                Repeater2.DataBind();
                Repeater3.DataSource = dt;
                Repeater3.DataBind();
                Repeater4.DataSource = dt;
                Repeater4.DataBind();
                Repeater5.DataSource = dt;
                Repeater5.DataBind();
                Repeater6.DataSource = dt;
                Repeater6.DataBind();
                Repeater7.DataSource = dt;
                Repeater7.DataBind();
                Repeater8.DataSource = dt;
                Repeater8.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void rptRegistration_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}