using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MySelfCare.App_Code
{
    public class dbfunction
    {
        public string strConstring = ConfigurationManager.AppSettings["asthaparadise"].ToString();
        #region SQL Update Method [This method is used to execute INSERT & UPDATE & DELETE queries.]
        public Int32 dbUpdate(string SQLQuery)
        {
            //string strConstring = ConfigurationManager.ConnectionStrings["conString"].ToString();
            // string conString = settings.ConnectionString;
            SqlConnection dbconn = new SqlConnection(strConstring);

            try
            {
                //Openning connection to database.
                dbconn.Open();
                SqlTransaction dbTran;
                dbTran = dbconn.BeginTransaction();
                SqlCommand dbCmd = new SqlCommand(SQLQuery, dbconn, dbTran);

                //Declaring variable for record count update.
                Int32 ReCount = 0;
                try
                {
                    ReCount = dbCmd.ExecuteNonQuery();
                    dbTran.Commit();
                    return ReCount;
                }
                catch (Exception ex1)
                {
                    //Rollback the action if error occurs.
                    dbTran.Rollback();
                    //Through exception if error Occured while updating to database.
                    throw new Exception("Error Occured while updating database.\r\n" + ex1.Message);
                }
            }
            catch (Exception ex)
            {
                //Through exception if error Occured while connecting to database.
                throw new Exception("Error Occured while connecting to database.\r\n" + ex.Message);
            }
            finally
            {
                //Finaliz code here.
                dbconn.Close();
                dbconn.Dispose();
            }
        }

        public Int32 dbUpdate1(string SQLQuery, SqlParameter[] Para)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);
            try
            {
                //Openning connection to database.
                dbconn.Open();
                SqlTransaction dbTran;
                dbTran = dbconn.BeginTransaction();
                SqlCommand dbCmd = new SqlCommand(SQLQuery, dbconn, dbTran);
                for (int i = 0; i < Para.Length; i++)
                {
                    dbCmd.Parameters.Add(Para[i]);
                }
                //Declaring variable for record count update.
                Int32 ReCount = 0;
                try
                {
                    ReCount = dbCmd.ExecuteNonQuery();
                    dbTran.Commit();
                    return ReCount;
                }
                catch (Exception ex1)
                {
                    //Rollback the action if error occurs.
                    dbTran.Rollback();
                    //Through exception if error Occured while updating to database.
                    throw new Exception("Error Occured while updating database.\r\n" + ex1.Message);
                }
            }
            catch (Exception ex)
            {
                //Through exception if error Occured while connecting to database.
                throw new Exception("Error Occured while connecting to database.\r\n" + ex.Message);
            }
            finally
            {
                //Finaliz code here.
                dbconn.Close();
                dbconn.Dispose();
            }
        }

        public Int32 dbUpdate2(string SQLQuery, SqlParameter[] Para)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);


            try
            {
                //Openning connection to database.
                dbconn.Open();
                SqlTransaction dbTran;
                dbTran = dbconn.BeginTransaction();
                SqlCommand dbCmd = new SqlCommand(SQLQuery, dbconn, dbTran);
                dbCmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Para.Length; i++)
                {
                    dbCmd.Parameters.Add(Para[i]);
                }
                //Declaring variable for record count update.
                Int32 ReCount = 0;
                try
                {
                    ReCount = dbCmd.ExecuteNonQuery();
                    dbTran.Commit();
                    return ReCount;
                }
                catch (Exception ex1)
                {
                    //Rollback the action if error occurs.
                    dbTran.Rollback();
                    //Through exception if error Occured while updating to database.
                    throw new Exception("Error Occured while updating database.\r\n" + ex1.Message);
                }
            }
            catch (Exception ex)
            {
                //Through exception if error Occured while connecting to database.
                throw new Exception("Error Occured while connecting to database.\r\n" + ex.Message);
            }
            finally
            {
                //Finaliz code here.
                dbconn.Close();
                dbconn.Dispose();
            }
        }


        #endregion

        #region bind data in table
        public DataTable FetchData(string qry)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, dbconn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
            return dt;
        }
        public DataSet FetchDataSet(string qry)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);

            DataSet dt = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, dbconn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
            return dt;
        }
        public DataTable FetchDataProc(string qry)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, dbconn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
            return dt;
        }

        public DataTable FetchData1(string qry, SqlParameter[] Para)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, dbconn);
                for (int i = 0; i < Para.Length; i++)
                {
                    cmd.Parameters.Add(Para[i]);
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
            return dt;
        }

        public DataTable FetchData1Proc(string qry, SqlParameter[] Para)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, dbconn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Para.Length; i++)
                {
                    cmd.Parameters.Add(Para[i]);
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
            return dt;
        }

        public DataSet FetchDataSetProc(string qry, SqlParameter[] Para)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, dbconn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Para.Length; i++)
                {
                    cmd.Parameters.Add(Para[i]);
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(ds);
            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
            return ds;
        }
        public DataTable FetchData1(string qry, List<SqlParameter> Para)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, dbconn);
                for (int i = 0; i < Para.Count; i++)
                {
                    cmd.Parameters.Add(Para[i]);
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
            return dt;
        }

        public DataSet FetchDataDataset(string qry, List<SqlParameter> Para)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);
            DataSet dt = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, dbconn);
                for (int i = 0; i < Para.Count; i++)
                {
                    cmd.Parameters.Add(Para[i]);
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
            return dt;
        }
        #endregion

        #region bind drodownlist
        public void fillDropdown(DropDownList ddlList, string sSQL, string strDisplayMember, string strValueMember)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter(sSQL, dbconn);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlList.DataSource = dt;
                    ddlList.DataTextField = strDisplayMember;
                    ddlList.DataValueField = strValueMember;
                    ddlList.DataBind();
                }
            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        #endregion

        #region bind gridview
        public void bindGridView(GridView gvDetails,string sSQL)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, dbconn);
                sda.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    gvDetails.DataSource = dt;
                    gvDetails.DataBind();
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    gvDetails.DataSource = dt;
                    gvDetails.DataBind();
                    int columncount = gvDetails.Rows[0].Cells.Count;
                    gvDetails.Rows[0].Cells.Clear();
                    gvDetails.Rows[0].Cells.Add(new TableCell());
                    gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvDetails.Rows[0].Cells[0].Text = "<font color=Red><b><center>No Record Found...</center></b></font>";
                }
            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        #endregion

        #region getjobid
        public  string getJobId()
        {
            String Result = null; ;
            SqlConnection con=new SqlConnection (strConstring);
            SqlDataAdapter sda=new SqlDataAdapter("declare @se  varchar(10);Select @se=se+'/' from U01_SrMaster select  @se+ ISNULL(CONVERT(Varchar,MAX(CONVERT(bigint,RIGHT(orderId,LEN(orderId)-CHARINDEX('/',orderId)))+1)),(SELECT Serial_no FROM U01_SrMaster)) from U01_JobOrderMaster where orderId like @se+'%'",con);
            DataTable dt=new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count>0)
            {
                Result = dt.Rows[0][0].ToString();
            }
            return Result;
        }
        #endregion

      

        public void fillDropdownCaption(DropDownList ddlList, string sSQL, string strDisplayMember, string strValueMember,string strCaption)
        {
            SqlConnection dbconn = new SqlConnection(strConstring);
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter(sSQL, dbconn);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlList.DataSource = dt;
                    ddlList.DataTextField = strDisplayMember;
                    ddlList.DataValueField = strValueMember;
                    ddlList.DataBind();
                  
                }
                ddlList.Items.Insert(0, new ListItem(strCaption, "0"));
            }
            catch (Exception ex)
            {
                string msg = "Some Fetching Error Occur";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
        }
      
   
    }

}