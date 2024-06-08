using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

/// <summary>
/// Summary description for Registerscript
/// </summary>
public class Registerscript
{
    public Registerscript()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool RegisterScript(System.Web.UI.Page newPage, string AlertMessage)
    {
        newPage.ClientScript.RegisterStartupScript(GetType(), "AlertMessage", "alert('" + AlertMessage + "');", true);
        return true;
    }

}