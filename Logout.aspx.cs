using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Response.Cache.SetExpires(DateTime.Now.Date);
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Session["username"] = null;
        Session["userAppNo"] = null;
        Response.Redirect("login.aspx");

    }
}