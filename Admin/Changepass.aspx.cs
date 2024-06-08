using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Changepass : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (Session["username"] != null)
            {
            txtUser.Text = Session["username"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }


    protected void btnchangepassword_Click(object sender, EventArgs e)
    {

        if (txtUserId.Text == "")
        {
            con.Open();
            string ValidatePassword = "";

            string OldPass = txtOldPassword.Text.Trim();

            string str = "";

            str = "select * from Tbl_Login where name = '" + txtUser.Text + "' and Active = 1";



            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ValidatePassword = dr["pass"].ToString();


                con.Close();

                if (ValidatePassword.Trim() == OldPass.Trim())
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("update  Tbl_Login set pass ='" + txtcnewpassword.Text + "' where name = '" + txtUser.Text + "' and Active=1 ", con);
                    int n = cmd1.ExecuteNonQuery();
                    if (n > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Admin old password has been  changed...');window.location ='Changepass.aspx';", true);
                    }
                    con.Close();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Your old password is incorrect...');window.location ='Changepass.aspx';", true);
                }
            }


        }
        else
        {
            con.Open();
            string ValidatePassword = "";

            string OldPass = txtOldPassword.Text.Trim();

            string str = "";

            str = "select * from Registration where AppNo = '" + txtUserId.Text + "' and Active = 1";




            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ValidatePassword = dr["Password"].ToString();


                con.Close();

                if (ValidatePassword.Trim() == OldPass.Trim())
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("update  Registration set Password ='" + txtcnewpassword.Text + "' where AppNo='" + txtUserId.Text + "' and Active=1 ", con);
                    int n = cmd1.ExecuteNonQuery();
                    if (n > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('User old password has been  changed...');window.location ='Changepass.aspx';", true);
                    }
                    con.Close();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('User old password is incorrect...');window.location ='Changepass.aspx';", true);
                }
            }

        }

    }

}


