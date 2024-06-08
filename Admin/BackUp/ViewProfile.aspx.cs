using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewProfile : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    DataTable dt = new DataTable();
        string Id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["AgentId"] != null)
        {
           Id = Request.QueryString["AgentId"];
            binddeta();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Id not found... ');window.location='RegistrationReport.aspx';", true);
        }
    }

    public void binddeta()
    {
        try
        {
            string query = "USP_Registration";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", 26);
            cmd.Parameters.AddWithValue("@AgentId", Id);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtname.Text = dt.Rows[0]["Name"].ToString();
                txtnumber.Text = dt.Rows[0]["Mobile"].ToString();
                txtQualification.Text = dt.Rows[0]["Qaulification"].ToString();
                txtdob.Text = dt.Rows[0]["Dob"].ToString();
                txtstate.Text = dt.Rows[0]["State"].ToString();
                txtdistrict.Text = dt.Rows[0]["District"].ToString();
                txtblock.Text = dt.Rows[0]["Block"].ToString();
                txtaddress.Text = dt.Rows[0]["Address"].ToString();
                txtassociate.Text = dt.Rows[0]["AssociateCompany"].ToString();
                txtfamily.Text = dt.Rows[0]["AssociateCompanyAgent"].ToString();
                txtfund.Text = dt.Rows[0]["AssociateMutual"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record not found... ');window.location='ViewProfile.aspx';", true);
            }
        }
        catch (Exception ex)
        {
        }
    }
}