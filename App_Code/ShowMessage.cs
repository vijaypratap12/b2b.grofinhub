using System;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for ShowMessage
/// </summary>
public class ShowMessage
{
    public enum MessageType { Success, Error, Info, Warning };
    public static void Show(string message)
    {
        string str = message;
        string script = "<script type=\"text/javascript\">alert('" + str + "');</script>";
        Page currentHandler = HttpContext.Current.CurrentHandler as Page;
        ScriptManager.RegisterStartupScript(currentHandler, typeof(Page), "alert", script, false);
    }

    public static void Page(string str)
    {
        string script = "<script type=\"text/javascript\">window.open('" + str + "');</script>";
        Page currentHandler = HttpContext.Current.CurrentHandler as Page;
        ScriptManager.RegisterStartupScript(currentHandler, typeof(Page), "alert", script, false);
    }


    public static void ShowMessage2(string Message, MessageType type)
    {
        Page currentHandler = HttpContext.Current.CurrentHandler as Page;
        ScriptManager.RegisterStartupScript(currentHandler, currentHandler.GetType(), "text", "ShowMessage('" + Message + "','" + type + "');", true);
    }


    public static void Page2(string str)
    {
        string script = "<script type=\"text/javascript\">window.open('" + str + "','_blank');</script>";
        Page currentHandler = HttpContext.Current.CurrentHandler as Page;
        ScriptManager.RegisterStartupScript(currentHandler, typeof(Page), "alert", script, false);
    }

    //public static void Show(string message)
    //{
    //    string str = message;
    //    string script = "<script type=\"text/javascript\">alert('" + str + "');</script>";
    //    Page currentHandler = HttpContext.Current.CurrentHandler as Page;
    //    ScriptManager.RegisterStartupScript(currentHandler, typeof(Page), "alert", script, false);
    //}


}