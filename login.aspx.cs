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

public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        Session.Clear();


        /*Clearing Page Cache>*/
        HttpResponse.RemoveOutputCacheItem("/caching/login.aspx");//for current page
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        /*End Clearing Page Cache>*/
        HttpContext.Current.Session.Clear();
    }

    //protected void btnlogin_Click(object sender, EventArgs e)
    //{
    #region MyRegion
    //try
    //{
    //    if (txtagentid.Text.Trim() == "")
    //    {
    //        Response.Write("<script>alert('Enter partner id to continue..!')</script>");
    //        txtagentid.Focus();
    //        return;
    //    }

    //    if (txtpassword.Text.Trim() == "")
    //    {
    //        Response.Write("<script>alert('Enter password to continue..!')</script>");
    //        txtpassword.Focus();
    //        return;
    //    }


    //    SqlCommand cmd = new SqlCommand("Proc_LoginApp", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@Action", "1");
    //    cmd.Parameters.AddWithValue("@Agentid", txtagentid.Text.Trim());
    //    cmd.Parameters.AddWithValue("@Password", txtpassword.Text.Trim());
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    if (dt.Rows.Count > 0)
    //    {
    //        if (Convert.ToString(dt.Rows[0]["IsLogin"]) == "1")
    //        {
    //            //Response.Redirect("http://app.grofinhub.com/",false);                

    //            //Response.Redirect("https://localhost:44317/", false);

    //            Response.Redirect("https://localhost:44317/Account/Login?userName=hem&password=123/", false);


    //        }
    //        else if (Convert.ToString(dt.Rows[0]["IsLogin"]) == "0")
    //        {
    //            Response.Write("<script>alert('Invalid Partner ID and Password..!')</script>");
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Something went wrong..!')</script>");
    //    }
    //}
    //catch (Exception ex)
    //{
    //} 
    #endregion
    //}
}