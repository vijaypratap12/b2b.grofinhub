using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using stablishconnection;

public partial class Admin_ContactUsReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["username"] != null)
            {
                //readrights();
       gridbind();

                if (lbledit.Text == "False")
                {
                    GridView2.Columns[2].Visible = false;
                }
                if (lbldelete.Text == "False")
                {
                    GridView2.Columns[3].Visible = false;
                }
               bindproperty();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    protected void readrights()
    {
        //SqlConnection con = new SqlConnection(obj.str);
        //SqlDataReader drr;
        //con.Open();
        //cmd = new SqlCommand("select edit_data,delete_data from login where username='" + Session["username"].ToString() + "'", con);
        //drr = cmd.ExecuteReader();
        //if (drr.Read())
        //{
        //    lbledit.Text = drr["edit_data"].ToString();
        //    lbldelete.Text = drr["delete_data"].ToString();
        //}
        //con.Close();
    }
    public void bindproperty()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select CountryID ,CountryName  from tbl_Countries ", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        ddlproperty.DataSource = ds;
        ddlproperty.DataTextField = "CountryName";
        ddlproperty.DataValueField = "CountryID";
        ddlproperty.DataBind();
        ddlproperty.Items.Insert(0, new ListItem("--Select --", "0"));
       // ddlproperty.Items.Insert(0, "Select");

        con.Close();
    }
    public void gridbind()
    {
       
        con.Open();
        SqlCommand cmd = new SqlCommand(" SELECT  b.StateName , a.CountryName , * FROM tbl_Countries a JOIN tbl_State b  ON a.CountryID=b.CountryCode WHERE b.Status='1' ", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt != null && dt.Rows.Count > 0)
        {

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
        con.Close();

    }

    public void gridSearchbind()
    {

        con.Open();
        SqlCommand cmd = new SqlCommand(" SELECT  b.StateName , a.CountryName , * FROM tbl_Countries a JOIN tbl_State b  ON a.CountryID=b.CountryCode WHERE b.Status='1' and a.CountryId= '" + ddlproperty.SelectedValue+"'  ", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt != null && dt.Rows.Count > 0)
        {

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
        con.Close();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
           
            if (Button1.Text == "Submit")
            {


                con.Open();


                SqlCommand cmd = new SqlCommand("USP_InsertStateMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryCode", ddlproperty.SelectedValue);
                cmd.Parameters.AddWithValue("@StateName", txtblock.Text.Trim());



                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                sda.Fill(ds);
                cmd.ExecuteNonQuery();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    if (ds.Tables[0].Rows[0]["ID"].ToString() != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('State added succesfully');", true);
                        clear();
                        con.Close();

                        gridbind();



                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('State Already Exist under the site!');", true);

                    }
                }
            }
            else if (Button1.Text == "Update")
            {

                con.Open();


                SqlCommand cmd = new SqlCommand("USP_UpdateStateMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryCode", ddlproperty.SelectedValue);
                cmd.Parameters.AddWithValue("@StateName", txtblock.Text.Trim());
                cmd.Parameters.AddWithValue("@entryid", lblentryid.Text);
            
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.ExecuteNonQuery();
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ID"].ToString() != "0")
                    {
                        gridbind();
                        Button1.Text = "Submit";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('State updated successfully');", true);
                        clear();
                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('State Already Exist under the site!');", true);

                }
            }


        }

        catch (Exception ex)
        {

        }
    }

    public void clear()
    {
        ddlproperty.SelectedIndex = 0;
        txtblock.Text = "";

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit1")
        {
            string number = e.CommandArgument.ToString();
         
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_State  WHERE Id ='" + e.CommandArgument.ToString() + "'", con);
      SqlDataReader      dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ddlproperty.SelectedValue = dr["CountryCode"].ToString();
                // txtpropertyname.Text = dr["Sitename"].ToString();
                txtblock.Text = dr["StateName"].ToString();
                lblentryid.Text = dr["Id"].ToString();

                Button1.Text = "Update";
            }
            con.Close();
        }
        else if (e.CommandName == "Delete1")
        {
            string number = e.CommandArgument.ToString();




            con.Open();
            SqlCommand cmd = new SqlCommand("update tbl_State set Status='0' where Id='"+ number + "' ", con);
           
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
        
            cmd.ExecuteNonQuery();
         
                 ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('State deleted successfully');", true);

                    con.Close();

                    gridbind();



                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('State cannot be deleted');", true);
                }
            }



    protected void ddlproperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridSearchbind();
    }
}

 

