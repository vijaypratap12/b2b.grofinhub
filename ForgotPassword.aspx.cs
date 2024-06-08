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

public partial class ForgotPassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    static bool vcaptcha = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlOTP.Visible = false;
        pnlForget.Visible = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (vcaptcha == true)
        {
            pnlOTP.Visible = false;
            txtOtp.Text = "";
            lblOTP.Text = "";

            Random ran = new Random();
            int OTP = ran.Next(111111, 999999);
            lblOTP.Text = OTP.ToString();

            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@Action", 28);
            cmd.Parameters.AddWithValue("@Agentid", txtAgentNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text.Trim());
            cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
            cmd.Parameters.AddWithValue("@Dob", txtdob.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                SqlCommand cmd_Otp = new SqlCommand("usp_OTP", con);
                cmd_Otp.CommandType = CommandType.StoredProcedure;
                cmd_Otp.CommandTimeout = 0;
                cmd_Otp.Parameters.AddWithValue("@Action", 1);
                cmd_Otp.Parameters.AddWithValue("@Mobile", txtmobile.Text.Trim());
                cmd_Otp.Parameters.AddWithValue("@Agentid", txtAgentNo.Text.Trim());
                cmd_Otp.Parameters.AddWithValue("@OTP", lblOTP.Text.Trim());
                SqlDataAdapter da_Otp = new SqlDataAdapter(cmd_Otp);
                DataTable dt_Otp = new DataTable();
                da_Otp.Fill(dt_Otp);
                if (dt_Otp.Rows.Count > 0)
                {
                    pnlOTP.Visible = true;
                    pnlForget.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + dt_Otp.Rows[0]["msg"] + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went wrong..!');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Partner Details..!');", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Captcha, Please Try Again..!');", true);
            return;
        }
    }

    //Captcha
    protected void ValidateCaptcha(object sender, ServerValidateEventArgs e)
    {
        Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
        e.IsValid = Captcha1.UserValidated;
        if (e.IsValid)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Valid Captcha!');", true);
            //   ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Valid Captcha!');", true);
            vcaptcha = true;
        }
        else
        {
            //  ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('InValid Captcha!');", true);
            vcaptcha = false;
            return;
        }
    }
    //Captcha

    protected void btnOtpVerify_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_OTP", con);
        cmd.CommandTimeout = 0;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Action", 3);
        cmd.Parameters.AddWithValue("@OTP", txtOtp.Text.Trim());
        cmd.Parameters.AddWithValue("@Agentid", txtAgentNo.Text.Trim());
        cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text.Trim());

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string OTP = txtOtp.Text.Trim();

            if (OTP == Convert.ToString(dt.Rows[0]["OTP"]))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToString(dt.Rows[0]["iid"]) == "1")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + dt.Rows[0]["msg"] + "');window.location ='login.aspx';", true);
                    }
                    else if (Convert.ToString(dt.Rows[0]["iid"]) == "2")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + dt.Rows[0]["msg"] + "');", true);
                        txtOtp.Focus();
                        return;
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + dt.Rows[0]["msg"] + "');", true);
                txtOtp.Focus();
                return;
            }
        }
    }
}