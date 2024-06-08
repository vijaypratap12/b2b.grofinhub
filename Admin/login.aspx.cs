using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.Configuration;
using stablishconnection;
using System.Configuration;
using System.Net;
using System.IO;
using StablishConnection;



public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Cache.SetNoStore();
            Session.Abandon();
            txtuserid.Focus();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            string Sql = "usp_Login";

            //string Sql = "select * from Tbl_Login where lower(username)=lower('" + txtuserid.Text + "') AND lower(Pass)=lower('" + txtpassword.Text.Trim() + "')";


            SqlCommand cmd = new SqlCommand(Sql, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", txtuserid.Text.Trim());
            cmd.Parameters.AddWithValue("@Pass", txtpassword.Text.Trim());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["username"] = dt.Rows[0]["username"].ToString();
                Response.Redirect("/Admin/Dashboard.aspx");
                Session.RemoveAll();
                Session.Abandon();
            }
            else
            {
                Response.Write("<script>alert('Invalid User Name or password!')</script>");
            }
        }
        catch (Exception ex)
        {
            // string Qry = "select * from users_m where lower(username)=lower('" + txtuserid.Text + "') AND lower(Pass)=lower('" + txtpass.Text.Trim() + "')";


        }
    }
}
