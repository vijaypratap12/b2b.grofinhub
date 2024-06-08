using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.Web;
using System.Linq;

/// <summary>
/// Summary description for ConnectionClass
/// </summary>
namespace StablishConnection
{
    public class ConnectionClass
    {
        public ConnectionClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SqlConnection con;
        public void Connection()
        {
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ToString();
            con = new SqlConnection(str);
        }
        public string str = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ToString();


        public void sendsms(string mobile, string Msg)
        {

            SqlConnection con = new SqlConnection(str);
            con.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd1 = new SqlCommand("select apiurl,senderid,senderpassword,sendername from Add_Company", con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd1);
            sa.Fill(ds);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string result = apicall("" + ds.Tables[0].Rows[0]["apiurl"].ToString() + "username=" + ds.Tables[0].Rows[0]["sendername"].ToString() + "&password=" + ds.Tables[0].Rows[0]["senderpassword"].ToString() + "&senderid=" + ds.Tables[0].Rows[0]["senderid"].ToString() + "&route=1&number=" + mobile + "&message=" + Msg);
            }
            con.Close();
            //string URL = " http://88.99.240.160/http-api.php?username=proprace&password=123456&senderid=PROPRC&route=1&number=" + mobile + "&message=" + Msg;
           // string URL = "http://bhashsms.com/api/sendmsg.php?user=martizaa&pass=123456&sender=MRTIZA&phone=" + Mob + "&text=" + Msg + "&priority=ndnd&stype=normal";
            //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(URL);
            //HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            //System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            //string responseString = respStreamReader.ReadToEnd();
            //respStreamReader.Close();
            //myResp.Close();
        }


        public string apicall(string url)
        {
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();

                StreamReader sr = new StreamReader(httpres.GetResponseStream());

                string results = sr.ReadToEnd();

                sr.Close();
                return results;

            }
            catch
            {
                return "0";
            }
        }

        public DataTable GetEmailIDs()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select *  from EmailDetails where emailId<>''";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable CheckValidation(string Username, string Password)
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_CheckUserLogin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("UserName", Username);
            cmd.Parameters.AddWithValue("Password", Password);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetMainMenu()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Menu_Master";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandTimeout = 2000;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable GetSubMenu( int M_ID)
    {
        Connection();
        DataTable dt = new DataTable();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select Url_Name as Menu,Url_ID as M_ID from Url_Master where M_ID=@M_ID";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.CommandTimeout = 2000;
        cmd.Parameters.AddWithValue("M_ID", M_ID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.Close();
        return dt;
    }

       



        public string InsertUpdateCustomer(Customer_master C, user_master U)
        {
            Connection();
            con.Open();
            string str = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UserRegistration";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entry_id", C.entry_id);
                cmd.Parameters.AddWithValue("@user_id", C.user_id);
                cmd.Parameters.AddWithValue("@email_id1", C.email_id1);
                cmd.Parameters.AddWithValue("@email_id2", C.email_id2);
                cmd.Parameters.AddWithValue("@organisation_name", C.organisation_name);
                cmd.Parameters.AddWithValue("@contact_person", C.contact_person);
                cmd.Parameters.AddWithValue("@mobile1", C.mobile1);
                cmd.Parameters.AddWithValue("@mobile2", C.mobile2);
                cmd.Parameters.AddWithValue("@mobile3", C.mobile3);
                cmd.Parameters.AddWithValue("@landline", C.landline);
                cmd.Parameters.AddWithValue("@firm_type", C.firm_type);
                cmd.Parameters.AddWithValue("@website", C.website);
                cmd.Parameters.AddWithValue("@sms_alert", C.sms_alert);
                cmd.Parameters.AddWithValue("@address_line1", C.address_line1);
                cmd.Parameters.AddWithValue("@address_line2", C.address_line2);
                cmd.Parameters.AddWithValue("@landmark", C.landmark);
                cmd.Parameters.AddWithValue("@city", C.city);
                cmd.Parameters.AddWithValue("@pin", C.pin);
                cmd.Parameters.AddWithValue("@state", C.state);
                cmd.Parameters.AddWithValue("@Pan", C.Pan);
                cmd.Parameters.AddWithValue("@UserType_Id", C.UserType_Id);
                cmd.Parameters.AddWithValue("@Status", C.Status);
                cmd.Parameters.AddWithValue("@Gender", C.Gender);
                cmd.Parameters.AddWithValue("@Photo", C.Photo);
                cmd.Parameters.AddWithValue("@passward", U.passward);
                cmd.Parameters.AddWithValue("@Msg", "");
                cmd.Parameters["@Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["@Msg"].Size = 256;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["@Msg"].Value.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                con.Close();
            }
            return str;
        }
        public bool CheckUserValidity(string str)
        {
            bool i = false;
            if (!string.IsNullOrEmpty(str))
            {
                Connection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT user_id FROM Customer_master WHERE user_id = @UserId", con);
                cmd.Parameters.AddWithValue("@UserId", str);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    i = false;
                }
                else
                {
                    i = true;
                }
                con.Close();
            }
            return i;
        }
        public DataTable GetUser(string UserId, string Name, DateTime FromDate, DateTime Todate, int UserTypeId, string Status)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GetUserDetail";
            cmd.Parameters.AddWithValue("UserId", UserId);
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("FromDate", FromDate);
            cmd.Parameters.AddWithValue("ToDate", Todate);
            cmd.Parameters.AddWithValue("UserTypeId", UserTypeId);
            cmd.Parameters.AddWithValue("Status", Status);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public string UpdateUserStatus(string UserId, string Status)
        {
            string str = "";
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_UpdateUserStatus";
            cmd.Parameters.AddWithValue("UserId", UserId);
            cmd.Parameters.AddWithValue("Status", Status);
            cmd.Parameters.AddWithValue("Msg", "");
            cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["Msg"].Size = 256;
            cmd.ExecuteNonQuery();
            str = cmd.Parameters["Msg"].Value.ToString();
            con.Close();
            return str;
        }
        public DataTable GetDSCType(int Id)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_GetDSCType";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EntryId", Id);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public string CreateDSCRequest(Dsc_Request D, List<T02_Transection> T02, List<T03_Transection> T03)
        {
            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CreateDSCRequest";
                cmd.Parameters.AddWithValue("entryId", D.entryId);
                cmd.Parameters.AddWithValue("DscType_Id", D.DscType_Id);
                cmd.Parameters.AddWithValue("Total_DSC", D.Total_DSC);
                cmd.Parameters.AddWithValue("User_Id", D.User_Id);
                cmd.Parameters.AddWithValue("Status", D.Status);
                cmd.Parameters.AddWithValue("RequestDate", D.RequestDate);
                cmd.Parameters.AddWithValue("ResponceDate", D.ResponceDate);
                cmd.Parameters.AddWithValue("PaymentDate", D.PaymentDate);
                cmd.Parameters.AddWithValue("PaymentNo", D.PaymentNo);
                cmd.Parameters.AddWithValue("PaymentDescription", D.PaymentDescription);
                cmd.Parameters.AddWithValue("Remark", D.Remark);
                cmd.Parameters.AddWithValue("entryDate", D.entryDate);
                cmd.Parameters.AddWithValue("PaymentType", D.PaymentType);
                cmd.Parameters.AddWithValue("PaidAmount", D.PaidAmount);
                cmd.Parameters.AddWithValue("TotalAmt", D.TotalAmt);
                cmd.Parameters.AddWithValue("Balance", D.Balance);
                cmd.Parameters.AddWithValue("InstrumentDate", D.InstrumentDate);
                cmd.Parameters.AddWithValue("Bank", D.Bank);
                cmd.Parameters.AddWithValue("Branch", D.Branch);
                cmd.Parameters.AddWithValue("Recieptimage", D.Recieptimage);
                cmd.Parameters.AddWithValue("RecieptNo", D.RecieptNo);
                cmd.Parameters.AddWithValue("AddToken", D.AddToken);
                cmd.Parameters.AddWithValue("TokenAmt", D.TokenAmt);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                cmd.Dispose();
                for (int j = 0; j < T02.Count; j++)
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "SET @T01_Id = IDENT_CURRENT('T01_Transection') INSERT INTO T02_Transection(T01_Id , TaxHead , Value , IsTokenTax) SELECT @T01_Id , @TaxHead , @Value , @IsTokenTax";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("T01_Id", T02[j].T01_Id);
                    cmd.Parameters.AddWithValue("TaxHead", T02[j].TaxHead);
                    cmd.Parameters.AddWithValue("Value", T02[j].Value);
                    cmd.Parameters.AddWithValue("IsTokenTax", T02[j].IsTokenTax);
                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();
                }
                for (int j = 0; j < T03.Count; j++)
                {
                    cmd = new SqlCommand();
                    cmd.CommandText =
          "SET @T01_Id = IDENT_CURRENT('T01_Transection') INSERT INTO T03_Transection(T01_Id,ITEMName,Value,IsToken,Qty) SELECT @T01_Id,@ITEMName,@Value,@IsToken,@Qty";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("T01_Id", T03[j].T01_Id);
                    cmd.Parameters.AddWithValue("ITEMName", T03[j].ITEMName);
                    cmd.Parameters.AddWithValue("Value", T03[j].Value);
                    cmd.Parameters.AddWithValue("IsToken", T03[j].IsToken);
                    cmd.Parameters.AddWithValue("Qty", T03[j].Qty);
                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;
        }
        public DataTable GetDSCRequest(int entryId, int DscType, string UserId, string Status, DateTime FromDate, DateTime Todate, string Name)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_GetDSCRequest";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("EntryId", entryId);
            cmd.Parameters.AddWithValue("DscTypeId", DscType);
            cmd.Parameters.AddWithValue("UserId", UserId);
            cmd.Parameters.AddWithValue("Status", Status);
            cmd.Parameters.AddWithValue("FromDate", FromDate);
            cmd.Parameters.AddWithValue("Todate", Todate);
            cmd.Parameters.AddWithValue("Name", Name);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public string InsertBulkDSCMaster(DataTable dt, string Status, string Remark, int entryId)
        {
            string str = "";
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InsertBulkDSCMaster";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@DSCMaster", dt);
            cmd.Parameters.AddWithValue("Status", Status);
            cmd.Parameters.AddWithValue("Remark", Remark);
            cmd.Parameters.AddWithValue("entryId", entryId);
            cmd.Parameters.AddWithValue("Msg", "");
            cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["Msg"].Size = 256;
            cmd.ExecuteNonQuery();
            str = cmd.Parameters["Msg"].Value.ToString();
            con.Close();
            return str;
        }
        public string InsertPayment(T01_Transection T01)
        {
            Connection();
            string str = "";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_InsertPayment";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", T01.Id);
            cmd.Parameters.AddWithValue("UserId", T01.UserId);
            cmd.Parameters.AddWithValue("PaidAmt", T01.PaidAmt);
            cmd.Parameters.AddWithValue("TotalAmt", T01.TotalAmt);
            cmd.Parameters.AddWithValue("BalAmt", T01.BalAmt);
            cmd.Parameters.AddWithValue("Perticular", T01.Perticular);
            cmd.Parameters.AddWithValue("EntryDate", T01.EntryDate);
            cmd.Parameters.AddWithValue("PaymentDate", T01.PaymentDate);
            cmd.Parameters.AddWithValue("PaymentType", T01.PaymentType);
            cmd.Parameters.AddWithValue("InstrumentDate", T01.InstrumentDate);
            cmd.Parameters.AddWithValue("Bank", T01.Bank);
            cmd.Parameters.AddWithValue("Branch", T01.Branch);
            cmd.Parameters.AddWithValue("Reciept", T01.Reciept);
            cmd.Parameters.AddWithValue("Status", T01.Status);
            cmd.Parameters.AddWithValue("DSCRequestId", T01.DSCRequestId);
            cmd.Parameters.AddWithValue("PyamentNo", T01.PyamentNo);
            cmd.Parameters.AddWithValue("Msg", "");
            cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["Msg"].Size = 256;
            cmd.ExecuteNonQuery();
            str = cmd.Parameters["Msg"].Value.ToString();
            con.Close();
            return str;
        }
        public DataSet GetUserBalance(string UserId)
        {
            Connection();
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_GetUserPaymentHistry";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public string InsertCustomerDSCRequest(Customer_master C, user_master U, CustomerDoc Cd, Dsc_Request Dsc, Dsc_Master DM, bool IsUser, List<T02_Transection> T02, List<T03_Transection> T03)
        {
            Connection();
            con.Open();
            string str = "";
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UserRegistration";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entry_id", C.entry_id);
                cmd.Parameters.AddWithValue("@user_id", C.user_id);
                cmd.Parameters.AddWithValue("@email_id1", C.email_id1);
                cmd.Parameters.AddWithValue("@email_id2", C.email_id2);
                cmd.Parameters.AddWithValue("@organisation_name", C.organisation_name);
                cmd.Parameters.AddWithValue("@contact_person", C.contact_person);
                cmd.Parameters.AddWithValue("@mobile1", C.mobile1);
                cmd.Parameters.AddWithValue("@mobile2", C.mobile2);
                cmd.Parameters.AddWithValue("@mobile3", C.mobile3);
                cmd.Parameters.AddWithValue("@landline", C.landline);
                cmd.Parameters.AddWithValue("@firm_type", C.firm_type);
                cmd.Parameters.AddWithValue("@website", C.website);
                cmd.Parameters.AddWithValue("@sms_alert", C.sms_alert);
                cmd.Parameters.AddWithValue("@address_line1", C.address_line1);
                cmd.Parameters.AddWithValue("@address_line2", C.address_line2);
                cmd.Parameters.AddWithValue("@landmark", C.landmark);
                cmd.Parameters.AddWithValue("@city", C.city);
                cmd.Parameters.AddWithValue("@pin", C.pin);
                cmd.Parameters.AddWithValue("@state", C.state);
                cmd.Parameters.AddWithValue("@Pan", C.Pan);
                cmd.Parameters.AddWithValue("@UserType_Id", C.UserType_Id);
                cmd.Parameters.AddWithValue("@Status", C.Status);
                cmd.Parameters.AddWithValue("@Gender", C.Gender);
                cmd.Parameters.AddWithValue("@Photo", C.Photo);
                cmd.Parameters.AddWithValue("@passward", U.passward);
                cmd.Parameters.AddWithValue("@Msg", "");
                cmd.Parameters["@Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["@Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["@Msg"].Value.ToString();
                cmd.Dispose();

                cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertCustomerDoc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@UserId", Cd.UserId);
                cmd.Parameters.AddWithValue("@Photo", Cd.Photo);
                cmd.Parameters.AddWithValue("@Pan", Cd.Pan);
                cmd.Parameters.AddWithValue("@Address", Cd.Address);
                cmd.Parameters.AddWithValue("@TIN_ST2", Cd.TIN_ST2);
                cmd.Parameters.AddWithValue("@Authority", Cd.Authority);
                cmd.Parameters.AddWithValue("@ITR", Cd.ITR);
                cmd.Parameters.AddWithValue("@Bank_Statement", Cd.Bank_Statement);
                cmd.Parameters.AddWithValue("@OtherDoc", Cd.OtherDoc);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsUser == false)
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "SP_CreateDSCRequest";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@entryId", Dsc.entryId);
                    cmd.Parameters["@entryId"].Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.AddWithValue("@DscType_Id", Dsc.DscType_Id);
                    cmd.Parameters.AddWithValue("@Total_DSC", Dsc.Total_DSC);
                    cmd.Parameters.AddWithValue("@User_Id", Dsc.User_Id);
                    cmd.Parameters.AddWithValue("@Status", Dsc.Status);
                    cmd.Parameters.AddWithValue("@RequestDate", Dsc.RequestDate);
                    cmd.Parameters.AddWithValue("@ResponceDate", Dsc.ResponceDate);
                    cmd.Parameters.AddWithValue("@PaymentDate", Dsc.PaymentDate);
                    cmd.Parameters.AddWithValue("@PaymentNo", Dsc.PaymentNo);
                    cmd.Parameters.AddWithValue("@PaymentDescription", Dsc.PaymentDescription);
                    cmd.Parameters.AddWithValue("@Remark", Dsc.Remark);
                    cmd.Parameters.AddWithValue("@entryDate", Dsc.entryDate);
                    cmd.Parameters.AddWithValue("@PaymentType", Dsc.PaymentType);
                    cmd.Parameters.AddWithValue("@PaidAmount", Dsc.PaidAmount);
                    cmd.Parameters.AddWithValue("@TotalAmt", Dsc.TotalAmt);
                    cmd.Parameters.AddWithValue("@Balance", Dsc.Balance);
                    cmd.Parameters.AddWithValue("@InstrumentDate", Dsc.InstrumentDate);
                    cmd.Parameters.AddWithValue("@Bank", Dsc.Bank);
                    cmd.Parameters.AddWithValue("@Branch", Dsc.Branch);
                    cmd.Parameters.AddWithValue("@Recieptimage", Dsc.Recieptimage);
                    cmd.Parameters.AddWithValue("@RecieptNo", Dsc.RecieptNo);
                    cmd.Parameters.AddWithValue("@AddToken", Dsc.AddToken);
                    cmd.Parameters.AddWithValue("@TokenAmt", Dsc.TokenAmt);
                    cmd.Parameters.AddWithValue("@Msg", "");
                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();
                    Dsc.entryId = int.Parse(cmd.Parameters["@entryId"].Value.ToString());
                    cmd.Dispose();
                    for (int j = 0; j < T02.Count; j++)
                    {
                        cmd = new SqlCommand();
                        cmd.CommandText = "SET @T01_Id = IDENT_CURRENT('T01_Transection') INSERT INTO T02_Transection(T01_Id , TaxHead , Value , IsTokenTax) SELECT @T01_Id , @TaxHead , @Value , @IsTokenTax";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("T01_Id", T02[j].T01_Id);
                        cmd.Parameters.AddWithValue("TaxHead", T02[j].TaxHead);
                        cmd.Parameters.AddWithValue("Value", T02[j].Value);
                        cmd.Parameters.AddWithValue("IsTokenTax", T02[j].IsTokenTax);
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                    }
                    for (int j = 0; j < T03.Count; j++)
                    {
                        cmd = new SqlCommand();
                        cmd.CommandText =
              "SET @T01_Id = IDENT_CURRENT('T01_Transection') INSERT INTO T03_Transection(T01_Id,ITEMName,Value,IsToken,Qty) SELECT @T01_Id,@ITEMName,@Value,@IsToken,@Qty";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("T01_Id", T03[j].T01_Id);
                        cmd.Parameters.AddWithValue("ITEMName", T03[j].ITEMName);
                        cmd.Parameters.AddWithValue("Value", T03[j].Value);
                        cmd.Parameters.AddWithValue("IsToken", T03[j].IsToken);
                        cmd.Parameters.AddWithValue("Qty", T03[j].Qty);
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                    }

                }

                cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertDSCMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("entry_Id", DM.entry_Id);
                cmd.Parameters.AddWithValue("Dsc_TypeId", DM.Dsc_TypeId);
                cmd.Parameters.AddWithValue("Dsc_No", DM.Dsc_No);
                cmd.Parameters.AddWithValue("Status", DM.Status);
                cmd.Parameters.AddWithValue("Dsc_RequestId", Dsc.entryId);
                cmd.Parameters.AddWithValue("AssignedUserId", DM.AssignedUserId);
                cmd.Parameters.AddWithValue("entryDate", DM.entryDate);
                cmd.Parameters.AddWithValue("Assign_Date", DM.Assign_Date);
                cmd.Parameters.AddWithValue("ValidFrom", DM.ValidFrom);
                cmd.Parameters.AddWithValue("ValidTo", DM.ValidTo);
                cmd.Parameters.AddWithValue("AssignedById", DM.AssignedById);
                cmd.Parameters.AddWithValue("AssignedToId", DM.AssignedToId);
                cmd.Parameters.AddWithValue("DSCSrNo", DM.DSCSrNo);
                cmd.Parameters.AddWithValue("DSCFrom", DM.DSCFrom);
                cmd.Parameters.AddWithValue("URL", DM.URL);
                cmd.Parameters.AddWithValue("CustomerRemark", DM.CustomerRemark);
                cmd.Parameters.AddWithValue("Challenge_Passphase", DM.Challenge_Passphase);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
                con.Close();
            }
            return str;
        }
        public DataTable GetDSCRegRequest(string UserId, string ToUserId, string Status, int DscTypeId, DateTime From, DateTime To)
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_GetDSCRegRequest";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserID", UserId);
            cmd.Parameters.AddWithValue("ToUserId", ToUserId);
            cmd.Parameters.AddWithValue("Status", Status);
            cmd.Parameters.AddWithValue("DscTypeId", DscTypeId);
            cmd.Parameters.AddWithValue("From", From);
            cmd.Parameters.AddWithValue("To", To);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public string UpdateDSCRegistration(Dsc_Request D, Dsc_Master DM)
        {
            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CreateDSCRequest";
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("entryId", D.entryId);
                cmd.Parameters.AddWithValue("DscType_Id", D.DscType_Id);
                cmd.Parameters.AddWithValue("Total_DSC", D.Total_DSC);
                cmd.Parameters.AddWithValue("User_Id", D.User_Id);
                cmd.Parameters.AddWithValue("Status", D.Status);
                cmd.Parameters.AddWithValue("RequestDate", D.RequestDate);
                cmd.Parameters.AddWithValue("ResponceDate", D.ResponceDate);
                cmd.Parameters.AddWithValue("PaymentDate", D.PaymentDate);
                cmd.Parameters.AddWithValue("PaymentNo", D.PaymentNo);
                cmd.Parameters.AddWithValue("PaymentDescription", D.PaymentDescription);
                cmd.Parameters.AddWithValue("Remark", D.Remark);
                cmd.Parameters.AddWithValue("entryDate", D.entryDate);
                cmd.Parameters.AddWithValue("PaymentType", D.PaymentType);
                cmd.Parameters.AddWithValue("PaidAmount", D.PaidAmount);
                cmd.Parameters.AddWithValue("TotalAmt", D.TotalAmt);
                cmd.Parameters.AddWithValue("Balance", D.Balance);
                cmd.Parameters.AddWithValue("InstrumentDate", D.InstrumentDate);
                cmd.Parameters.AddWithValue("Bank", D.Bank);
                cmd.Parameters.AddWithValue("Branch", D.Branch);
                cmd.Parameters.AddWithValue("Recieptimage", D.Recieptimage);
                cmd.Parameters.AddWithValue("Recieptimage", D.RecieptNo);
                cmd.Parameters.AddWithValue("Recieptimage", D.Recieptimage);
                cmd.Parameters.AddWithValue("Recieptimage", D.Recieptimage);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                cmd.Dispose();

                cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertDSCMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("entry_Id", DM.entry_Id);
                cmd.Parameters.AddWithValue("Dsc_TypeId", DM.Dsc_TypeId);
                cmd.Parameters.AddWithValue("Dsc_No", DM.Dsc_No);
                cmd.Parameters.AddWithValue("Status", DM.Status);
                cmd.Parameters.AddWithValue("Dsc_RequestId", DM.Dsc_RequestId);
                cmd.Parameters.AddWithValue("AssignedUserId", DM.AssignedUserId);
                cmd.Parameters.AddWithValue("entryDate", DM.entryDate);
                cmd.Parameters.AddWithValue("Assign_Date", DM.Assign_Date);
                cmd.Parameters.AddWithValue("ValidFrom", DM.ValidFrom);
                cmd.Parameters.AddWithValue("ValidTo", DM.ValidTo);
                cmd.Parameters.AddWithValue("AssignedById", DM.AssignedById);
                cmd.Parameters.AddWithValue("AssignedToId", DM.AssignedToId);
                cmd.Parameters.AddWithValue("DSCSrNo", DM.DSCSrNo);
                cmd.Parameters.AddWithValue("DSCFrom", DM.DSCFrom);
                cmd.Parameters.AddWithValue("URL", DM.URL);
                cmd.Parameters.AddWithValue("CustomerRemark", DM.CustomerRemark);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();
                return str;
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
                con.Close();
            }
            return str;
        }
        public DataTable GetCustomerDoc(string UserId)
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT UserId, Photo, Pan, Address, TIN_ST2, Authority, ITR, Bank_Statement,OtherDoc FROM  CustomerDoc WHERE UserId = @UserId";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void DSCRequestProcess(List<ReqStatus> s)
        {
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                for (int i = 0; i < s.Count; i++)
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "SP_DSCRequestProcess";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("entryId", s[i].entryId);
                    cmd.Parameters.AddWithValue("DScReqId", s[i].DScReqId);
                    cmd.Parameters.AddWithValue("Status", s[i].Status);
                    cmd.Parameters.AddWithValue("ReqStatus", s[i].ReqStatu);
                    cmd.Parameters.AddWithValue("UserId", s[i].UserId);
                    cmd.Parameters.AddWithValue("DSCFrom", s[i].DSCFrom);
                    cmd.Parameters.AddWithValue("URL", s[i].URL);
                    cmd.Parameters.AddWithValue("Remark", s[i].Remark);
                    cmd.Parameters.AddWithValue("DSCSrNo", s[i].DSCSrNo);
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
            }
            con.Close();
        }
        public void UpdateDSCRequestId(int entryId, string status, string RequestId, string RegCode, string ChallPass, string DSCSrNo, string Remark, int ReqId, string ReqIdCom, string RegCodeCom)
        {
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Dsc_Master SET Status = @Status,Remark=@Remark , RequestId = @RequestId, RegistrationCode = @RegistrationCode, Challenge_Passphase = @Challenge_Passphase , DSCSrNo = @DSCSrNo , RequestIdCom = @ReqIdCom , RegCodeCom =  @RegCodeCom  WHERE entry_Id  = @entryId ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Transaction = trans;
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@RequestId", RequestId);
            cmd.Parameters.AddWithValue("@RegistrationCode", RegCode);
            cmd.Parameters.AddWithValue("@Challenge_Passphase", ChallPass);
            cmd.Parameters.AddWithValue("@entryId", entryId);
            cmd.Parameters.AddWithValue("@DSCSrNo", DSCSrNo);
            cmd.Parameters.AddWithValue("@Remark", Remark);
            cmd.Parameters.AddWithValue("@ReqIdCom", ReqIdCom);
            cmd.Parameters.AddWithValue("@RegCodeCom", RegCodeCom);
            cmd.ExecuteNonQuery();
            trans.Commit();
            con.Close();
        }
        public void UpdateDscRefcode(string Refcode, string Authcode, DateTime @ValidTo, int entryId, int dscentryId, string RefCodeCom, string AuthCodeCom)
        {
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = trans;
            cmd.CommandText = "UPDATE Dsc_Master SET AuthCode = @Authcode , RefCode = @Refcode , RefCodeCom = @RefCodeCom  , AuthCodeCom = @AuthCodeCom , Status = 'A' , ValidFrom = GETDATE(),ValidTo = @ValidTo  WHERE entry_Id = @entryId";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Transaction = trans;
            cmd.Parameters.AddWithValue("Refcode", Refcode);
            cmd.Parameters.AddWithValue("Authcode", Authcode);
            cmd.Parameters.AddWithValue("ValidTo", ValidTo);
            cmd.Parameters.AddWithValue("entryId", entryId);
            cmd.Parameters.AddWithValue("RefCodeCom", RefCodeCom);
            cmd.Parameters.AddWithValue("AuthCodeCom", AuthCodeCom);
            cmd.ExecuteNonQuery();


            cmd = new SqlCommand();
            cmd.Transaction = trans;
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Dsc_Request SET Status = 'A' , ResponceDate = GETDATE() WHERE entryId = @entryId";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("entryId", dscentryId);
            cmd.ExecuteNonQuery();
            trans.Commit();
            con.Close();
        }

        public DataTable GetUserDSCPrice(string UserId)
        {
            DataTable ds = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_GetUserDSCPrice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("UserId", UserId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public string InsertUserDSCPrice(List<D01_UserDSCPrice> D01)
        {
            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            for (int i = 0; i < D01.Count; i++)
            {
                cmd = new SqlCommand();
                cmd.Transaction = trans;
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_InsertUserDSCPrice";
                cmd.Parameters.AddWithValue("UserId", D01[i].UserId);
                cmd.Parameters.AddWithValue("Ind_Class_2_Sign", D01[i].Ind_Class_2_Sign);
                cmd.Parameters.AddWithValue("Org_Class_2_Sign", D01[i].Org_Class_2_Sign);
                cmd.Parameters.AddWithValue("Ind_Class_2_Com", D01[i].Ind_Class_2_Com);
                cmd.Parameters.AddWithValue("Org_Class_2_Com", D01[i].Org_Class_2_Com);
                cmd.Parameters.AddWithValue("Ind_Class_3_Sign", D01[i].Ind_Class_3_Sign);
                cmd.Parameters.AddWithValue("Org_Class_3_Sign", D01[i].Org_Class_3_Sign);
                cmd.Parameters.AddWithValue("Ind_Class_3_Com", D01[i].Ind_Class_3_Com);
                cmd.Parameters.AddWithValue("Org_Class_3_Com", D01[i].Org_Class_3_Com);
                cmd.Parameters.AddWithValue("DGPT_1Y", D01[i].DGPT_1Y);
                cmd.Parameters.AddWithValue("DGPT_2Y", D01[i].DGPT_2Y);
                cmd.Parameters.AddWithValue("Token", D01[i].Token);
                cmd.Parameters.AddWithValue("TaxApplied", D01[i].TaxApplied);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
            }
            trans.Commit();
            con.Close();
            return str;
        }
        public void UpdateDSCBasicPrice(string DSC, decimal Amount)
        {
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Dsc_Typemaster SET Amount = @Amount WHERE Dsc_Type = @DSC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@DSC", DSC);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string InsertUpdateTax(M02_TaxMaster M02)
        {
            string str = "";
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InsertUpdateTax";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("TaxId", M02.TaxId);
            cmd.Parameters.AddWithValue("Tax", M02.Tax);
            cmd.Parameters.AddWithValue("value", M02.value);
            cmd.Parameters.AddWithValue("IsAppliedOnToken", M02.IsAppliedOnToken);
            cmd.Parameters.AddWithValue("IsActive", M02.IsActive);
            cmd.Parameters.AddWithValue("Msg", "");
            cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["Msg"].Size = 256;
            cmd.ExecuteNonQuery();
            str = cmd.Parameters["Msg"].Value.ToString();
            con.Close();
            return str;
        }
        public DataTable GetTax(int TaxId)
        {
            DataTable ds = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_GetTax";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("TaxId", TaxId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public void ChangePass(string UserId, string Pass)
        {
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE user_master SET passward=@Pass WHERE user_id = @UserId";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Pass", Pass);
            cmd.ExecuteNonQuery();
            con.Close();


        }
        public DataTable GetState()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM M03_State ORDER BY State";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetDSCDownload(string Name, string Email, string Mob, string Pan, string UserId)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_GetDSCDownload";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("Mob", Mob);
            cmd.Parameters.AddWithValue("Pan", Pan);
            cmd.Parameters.AddWithValue("UserId", UserId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAdminLedger(DateTime From, DateTime To, string UserId)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT UserId , contact_person as Name ,SUM (Amt_Dr) as Dr , SUM(Amt_Cr) as CR ,SUM(Amt_Dr - Amt_Cr ) AS Bal FROM Ledger L JOIN Customer_master C ON C.user_id = L.UserId WHERE @UserId = (CASE WHEN @UserId = '' THEN @UserId ELSE UserId END)  AND L.EntryDate BETWEEN @From AND @To GROUP BY UserId ,contact_person";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@From", From);
            cmd.Parameters.AddWithValue("@To", To);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetMemberLedger(DateTime From, DateTime To, string UserId)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Ledger where UserId = @UserId AND EntryDate BETWEEN @From AND @To ORDER BY EntryDate";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@From", From);
            cmd.Parameters.AddWithValue("@To", To);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetUserDSCleft(string UserId, int DSCId)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_GetUserDSCleft";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DSCTypeId", DSCId);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetRemark(int Id)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_GetRemark";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public string InserUpdateRemark(M04_RemarkMaster M04, bool IsDelete)
        {
            Connection();
            con.Open();
            string str = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InsertUpdateRemark";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Id", M04.Id);
            cmd.Parameters.AddWithValue("Remark", M04.Remark);
            cmd.Parameters.AddWithValue("Description", M04.Description);
            cmd.Parameters.AddWithValue("IsDelete", IsDelete);
            cmd.Parameters.AddWithValue("Msg", "");
            cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["Msg"].Size = 256;
            cmd.ExecuteNonQuery();
            str = cmd.Parameters["Msg"].Value.ToString();
            con.Close();
            return str;
        }
        public DataTable GetDSCStatus(string AssignedUserId, string Name, DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_DSCStatus";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AssignedUserId", AssignedUserId);
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("From", From);
            cmd.Parameters.AddWithValue("To", To);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public string UpdateDSC(Customer_master C, user_master U, int entryId)
        {
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            string str = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UserRegistration";
                cmd.Connection = con;
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entry_id", C.entry_id);
                cmd.Parameters.AddWithValue("@user_id", C.user_id);
                cmd.Parameters.AddWithValue("@email_id1", C.email_id1);
                cmd.Parameters.AddWithValue("@email_id2", C.email_id2);
                cmd.Parameters.AddWithValue("@organisation_name", C.organisation_name);
                cmd.Parameters.AddWithValue("@contact_person", C.contact_person);
                cmd.Parameters.AddWithValue("@mobile1", C.mobile1);
                cmd.Parameters.AddWithValue("@mobile2", C.mobile2);
                cmd.Parameters.AddWithValue("@mobile3", C.mobile3);
                cmd.Parameters.AddWithValue("@landline", C.landline);
                cmd.Parameters.AddWithValue("@firm_type", C.firm_type);
                cmd.Parameters.AddWithValue("@website", C.website);
                cmd.Parameters.AddWithValue("@sms_alert", C.sms_alert);
                cmd.Parameters.AddWithValue("@address_line1", C.address_line1);
                cmd.Parameters.AddWithValue("@address_line2", C.address_line2);
                cmd.Parameters.AddWithValue("@landmark", C.landmark);
                cmd.Parameters.AddWithValue("@city", C.city);
                cmd.Parameters.AddWithValue("@pin", C.pin);
                cmd.Parameters.AddWithValue("@state", C.state);
                cmd.Parameters.AddWithValue("@Pan", C.Pan);
                cmd.Parameters.AddWithValue("@UserType_Id", C.UserType_Id);
                cmd.Parameters.AddWithValue("@Status", C.Status);
                cmd.Parameters.AddWithValue("@Gender", C.Gender);
                cmd.Parameters.AddWithValue("@Photo", C.Photo);
                cmd.Parameters.AddWithValue("@passward", U.passward);
                cmd.Parameters.AddWithValue("@Msg", "");
                cmd.Parameters["@Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["@Msg"].Size = 256;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["@Msg"].Value.ToString();

                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Dsc_Master SET Status = @Status WHERE entry_Id = @entryId";
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("entryId", entryId);
                cmd.Parameters.AddWithValue("Status", "P");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
                con.Close();
            }
            return str;
        }
        public string DeleteDSCReq(int DSCId, int DSCReqId)
        {
            string str = "";
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_DeleteDSCReq";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DSCId", DSCId);
            cmd.Parameters.AddWithValue("DSCReqId", DSCReqId);
            cmd.Parameters.AddWithValue("@Msg", "");
            cmd.Parameters["@Msg"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["@Msg"].Size = 256;
            cmd.ExecuteNonQuery();
            str = cmd.Parameters["@Msg"].Value.ToString();
            con.Close();
            return str;
        }
        public string InsertSmsCount(int DSCId)
        {
            string str = "";
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Dsc_Master SET SmsSent = (ISNULL(SmsSent,0) + 1) WHERE entry_Id = @entryId";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@entryId", DSCId);
            cmd.ExecuteNonQuery();
            con.Close();
            return str;
        }
        public DataTable GetUnpaidlist(string UserId, DateTime From, DateTime To, string Status)
        {
            DataTable dt = new DataTable();
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SP_GetUnpaidlist";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserId", UserId);
            cmd.Parameters.AddWithValue("From", From);
            cmd.Parameters.AddWithValue("To", To);
            cmd.Parameters.AddWithValue("Status", Status);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void UpdatePaymentStatus(long Id, string Status, string Remark)
        {
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE T01_Transection SET Status = @Status , AdminRemark = @Remark WHERE Id = @Id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.Parameters.AddWithValue("Status", Status);
            cmd.Parameters.AddWithValue("Remark", Remark);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateUserType(string UserId, int UserTypeId)
        {
            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE user_master SET User_TypeId = @User_TypeId WHERE user_id = @user_id     UPDATE Customer_master SET UserType_Id = @User_TypeId  WHERE user_id = @user_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@user_id", UserId);
            cmd.Parameters.AddWithValue("@User_TypeId", UserTypeId);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable GetMainMenu(string role)
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();

            /*cmd.CommandText = "SELECT '" + role + "' as Role_Id , * FROM Menu_Master";*/
            if (role == "1")
            {
                cmd.CommandText = "SELECT M_ID,Menu FROM Menu_Master where Astatus=1";
            }
            else
            {
                cmd.CommandText = "SELECT M_ID,Menu FROM Menu_Master where ustatus=1";
            }
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandTimeout = 2000;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //public string InsertUpdateMenuRights(string Roleid, string UrlId)
        //{
        //    Connection();
        //    con.Open();
        //    string str = "";
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "USP_I_ROLE_RIGHT";
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Role_Id", Roleid);
        //        cmd.Parameters.AddWithValue("@Url_ID", UrlId);
        //        cmd.Parameters.AddWithValue("@flag", "Y");
        //        //cmd.Parameters.AddWithValue("@Msg", "");
        //        //cmd.Parameters["@Msg"].Direction = ParameterDirection.InputOutput;
        //        //cmd.Parameters["@Msg"].Size = 256;
        //        cmd.ExecuteNonQuery();
        //        //str = cmd.Parameters["@Msg"].Value.ToString();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        str = ex.Message;
        //        con.Close();
        //    }
        //    return str;
        //}
        public string InsertUpdateMenuRights(string Roleid, string UrlId, string Flag,string Name)
        {
            Connection();
            con.Open();
            string str = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "USP_I_ROLE_RIGHT";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Role_Id", Roleid);
                cmd.Parameters.AddWithValue("@Url_ID", UrlId);
                cmd.Parameters.AddWithValue("@flag", Flag);
                cmd.Parameters.AddWithValue("@Name", Name);
                //cmd.Parameters.AddWithValue("@Msg", "");;
                //cmd.Parameters["@Msg"].Direction = ParameterDirection.InputOutput;
                //cmd.Parameters["@Msg"].Size = 256;
                cmd.ExecuteNonQuery();
                //str = cmd.Parameters["@Msg"].Value.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                con.Close();
            }
            return str;
        }

        public string InsertUpdateMainMenuRights(string Roleid, string UrlId, string Flag ,string Name)
        {
            Connection();
            con.Open();
            string str = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "USP_I_MainROLE_RIGHT";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Role_Id", Roleid);
                cmd.Parameters.AddWithValue("@Url_ID", UrlId);
                cmd.Parameters.AddWithValue("@flag", Flag);
                cmd.Parameters.AddWithValue("@Name", Name);
                //cmd.Parameters.AddWithValue("@Msg", "");
                //cmd.Parameters["@Msg"].Direction = ParameterDirection.InputOutput;
                //cmd.Parameters["@Msg"].Size = 256;
                cmd.ExecuteNonQuery();
                //str = cmd.Parameters["@Msg"].Value.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                con.Close();
            }
            return str;
        }
        #region NewsEvent

        public DataTable GetNewsEvent()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetNews_Event";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string InsertUpdateNewsEvent(int Id, string Headline,string Newsfor,string PostedDate,string Postedby,string description,bool IsActive,bool IsDelete)
        {
            Connection();
            con.Open();
            string str = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertUpdateNews_Event";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.Parameters.AddWithValue("@Headline", Headline);
            cmd.Parameters.AddWithValue("@NewsDescription", description);
            cmd.Parameters.AddWithValue("@Newsfor", Newsfor);
            cmd.Parameters.AddWithValue("@PostedDate", PostedDate);
            cmd.Parameters.AddWithValue("@PostedBy", Postedby);         
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDelete", IsDelete);
            cmd.Parameters.AddWithValue("Msg", "");
            cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["Msg"].Size = 256;
            cmd.ExecuteNonQuery();
            str = cmd.Parameters["Msg"].Value.ToString();
            con.Close();
            return str;
        }

        #endregion

        #region

        //public string insertupdategallery(int Id, string name, string imagepath, string Services)
        //{

        //    string str = "";
        //    Connection();
        //    con.Open();
        //    SqlTransaction trans = con.BeginTransaction();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "USP_InsertUpdateGallery";
        //        cmd.Parameters.AddWithValue("Id", Id);
        //        cmd.Parameters.AddWithValue("Name", name);
        //        cmd.Parameters.AddWithValue("IamgePath", imagepath);
        //        cmd.Parameters.AddWithValue("Services", Services);
        //        cmd.Parameters.AddWithValue("Msg", "");
        //        cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
        //        cmd.Parameters["Msg"].Size = 256;
        //        cmd.Transaction = trans;
        //        cmd.ExecuteNonQuery();
        //        str = cmd.Parameters["Msg"].Value.ToString();
        //        trans.Commit();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        str = ex.Message;
        //        trans.Rollback();
        //    }
        //    con.Close();
        //    return str;

        //}
        public string insertupdatPopImage(int Id, string name, string imagepath)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertPopUpImage";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("IamgePath", imagepath);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }
        public string insertupdateprojectgallery(int Id, string name, string imagepath,string SiteName)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateProjectGallery";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("IamgePath", imagepath);
                cmd.Parameters.AddWithValue("SiteName", SiteName);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }
        public string insertdeleteprojectgallery(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateProjectGallery";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }
        public string insertdeletegallery(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabIntrumentImage";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }
        public string insertdeletePopUp(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertPopUpImage";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetImageGallery()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetImageDetails_New";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetPopUpDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetPopUpDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetProjectImageGallery()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetProjectImageDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetProjectDetail()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetProjectDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        #endregion





        public string insertupdategallery(int Id,int Category, string Image, int SubCategory)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabIntrumentImage_NEW";
                cmd.Parameters.AddWithValue("Id", Id);
            
                cmd.Parameters.AddWithValue("Category", Category);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Subcategory", SubCategory);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }






        public string insertupdateCategory(int Id, string name)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateCategory";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("Name", name);
               
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }


        public string insertdeleteGalleryCategory(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateCategory";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }



        public string insertupdateallgalleryDetails(int Id, string name, string imagepath, int CategoryId)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateAllGallery";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Category_Id", CategoryId);
                cmd.Parameters.AddWithValue("IamgePath", imagepath);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }


        public string insertdeleteallGallery(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateAllGallery";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetAllImageGallery()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetAllImageDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetCategoryDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Image_Category");
           cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        ///Labcategory

        public string insertupdateLabCategory(int Id, string CategoryName,string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabCategory";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }
        


         public DataTable GetLabCategoryDetails()
          {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabInstrument_category where IsActive=1 ");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


               public string insertdeleteLabCategory(int Id)
               {

                   string str = "";
                   Connection();
                   con.Open();
                   SqlTransaction trans = con.BeginTransaction();
                   try
                   {
                       SqlCommand cmd = new SqlCommand();
                       cmd.Connection = con;
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.CommandText = "USP_InsertUpdateLabCategory";
                       cmd.Parameters.AddWithValue("Id", Id);
                       cmd.Parameters.AddWithValue("@flag", "Delete");
                       cmd.Parameters.AddWithValue("Msg", "");
                       cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                       cmd.Parameters["Msg"].Size = 256;
                       cmd.Transaction = trans;
                       cmd.ExecuteNonQuery();
                       str = cmd.Parameters["Msg"].Value.ToString();
                       trans.Commit();
                       con.Close();
                   }
                   catch (Exception ex)
                   {
                       str = ex.Message;
                       trans.Rollback();
                   }
                   con.Close();
                   return str;

               }


        // Lab Details

        public string insertupdateLabDetails(int Id, string CategoryName,string Heading, string Imppoint, string Description, string EntryBy, string Subcategory)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabinstrumentDetails_Bacckup";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("subcategory", Subcategory);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Imppoint", Imppoint);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetLabDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabInstrumentDetails_Backup where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public string insertdeleteLabDetails(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabinstrumentDetails_Bacckup";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }




        //Lab Features Details

        public string insertupdateLabFeatureDetails(int Id, string CategoryName, string Subcategory, string Heading, string Description, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabinstrumentFeatureDetails_New";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Subcategory", Subcategory);
                cmd.Parameters.AddWithValue("Heading", Heading);
               cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetLabFeatureDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabInstrumentFeatureDetails_New where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string insertdeleteLabFeatureDetails(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabinstrumentFeatureDetails";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }




        //SubCategory Image
        public string insertupdateSubGallery(int Id, string name, string imagepath,int CategoryId ,int subcategory)
               {

                   string str = "";
                   Connection();
                   con.Open();
                   SqlTransaction trans = con.BeginTransaction();
                   try
                   {
                       SqlCommand cmd = new SqlCommand();
                       cmd.Connection = con;
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.CommandText = "USP_InsertUpdateSubGallery";
                       cmd.Parameters.AddWithValue("Id", Id);
                       cmd.Parameters.AddWithValue("Name", name);
                       cmd.Parameters.AddWithValue("Category_Id", CategoryId);
                       cmd.Parameters.AddWithValue("SubcatId", subcategory);
                       cmd.Parameters.AddWithValue("IamgePath", imagepath);
                       cmd.Parameters.AddWithValue("Msg", "");
                       cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                       cmd.Parameters["Msg"].Size = 256;
                       cmd.Transaction = trans;
                       cmd.ExecuteNonQuery();
                       str = cmd.Parameters["Msg"].Value.ToString();
                       trans.Commit();
                       con.Close();
                   }
                   catch (Exception ex)
                   {
                       str = ex.Message;
                       trans.Rollback();
                   }
                   con.Close();
                   return str;

               }


               public string insertdeleteSubGallery(int Id)
               {

                   string str = "";
                   Connection();
                   con.Open();
                   SqlTransaction trans = con.BeginTransaction();
                   try
                   {
                       SqlCommand cmd = new SqlCommand();
                       cmd.Connection = con;
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.CommandText = "USP_InsertUpdateSubGallery";
                       cmd.Parameters.AddWithValue("Id", Id);
                       cmd.Parameters.AddWithValue("@flag", "Delete");
                       cmd.Parameters.AddWithValue("Msg", "");
                       cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                       cmd.Parameters["Msg"].Size = 256;
                       cmd.Transaction = trans;
                       cmd.ExecuteNonQuery();
                       str = cmd.Parameters["Msg"].Value.ToString();
                       trans.Commit();
                       con.Close();
                   }
                   catch (Exception ex)
                   {
                       str = ex.Message;
                       trans.Rollback();
                   }
                   con.Close();
                   return str;

               }

               public DataTable GetSubGallery()
               {
                   Connection();
                   DataTable dt = new DataTable();
                   con.Open();
                   SqlCommand cmd = new SqlCommand();
                   cmd.CommandText = "USP_GetSubImageDetails";
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Connection = con;
                   SqlDataAdapter da = new SqlDataAdapter();
                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   con.Close();
                   return dt;
               }


        ///Features Image details
        public string insertupdateFeaturegallery(int Id, int Category, int SubCategory, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabIntrumentFeatureImage_New";
                cmd.Parameters.AddWithValue("Id", Id);

                cmd.Parameters.AddWithValue("Category", Category);
                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetLabFeatureImage()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabInstrumentFeatureImage_New where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public string insertdeleteFeaturesgallery(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabIntrumentFeatureImage";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }




        //Lab Heading Details

        public string insertupdateLabHeading(int Id, string CategoryName, string Heading, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabHeading";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Heading", Heading);
              cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetLabInstrumentHeading()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabInstrumentHeading where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string insertdeleteLabHeading(int Id)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabHeading";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("@flag", "Delete");
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }


        // Lab Consumable category


        public string insertupdateLabConsumableCategory(int Id, string CategoryName, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabConsumableCategory";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }



        public DataTable GetLabConsumableCategoryDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabConsumable_category where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


       



        // Lab cosumable Heading 


        public string insertupdateLabConsumableHeading(int Id, string CategoryName, string Heading, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabConsumableHeading";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetLabConsumableHeading()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabConsumableHeading where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }



        // lab consumable Details

        public string insertupdateLabConsumbleDetails(int Id, string CategoryName,string Heading,string Image, string Description, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateConsumableDetails";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetLabConsumableDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabConsumableDetails where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }



        //Lab Consumable Image

        public string insertupdateConsumablegallery(int Id, int Category, int SubCategory, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabConsumableImage_New";
                cmd.Parameters.AddWithValue("Id", Id);

                cmd.Parameters.AddWithValue("Category", Category);
                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetImageConsumableGallery()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetConsumableImageDetails_New";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        // Lab COnsumable Feature Image
        public string insertupdateConsumableFeaturegallery(int Id, int Category, int SubCategory, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateConsumableFeatureImage_New";
                cmd.Parameters.AddWithValue("Id", Id);

                cmd.Parameters.AddWithValue("Category", Category);
                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetLabConsumableFeatureImage()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabConsumableFeatureImage_New where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        // lab Consumable Feature Details

        public string insertupdateLabConsumbaleFeatureDetails(int Id, string CategoryName,string Subcategory, string Heading, string Description, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabConsumableFeatureDetails_New";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("SubCategory", Subcategory);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetLabConsumableFeatureDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabConsumableFeatureDetails_New where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        // Add Diagnostic Category


        public string insertupdateDiagnosticCategory(int Id, string CategoryName, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateDiagnosticCategory";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }



        public DataTable GetDiagnosticCategoryDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Diagnostic_category where IsActive=1 ");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        //Diagnostic Heading
        public string insertupdateDiagnosticHeading(int Id, string CategoryName, string Heading, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateDiagnosticHeading";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetDiagnosticHeading()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DiagnosticHeading where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        //Diagnostic Details
        public string insertupdateDiagnosticDetails(int Id, string CategoryName, string SubCategory, string Heading, string Imppoint, string Description, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateDiagnosticDetailscategorywise";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Imppoint", Imppoint);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetDiagnosticDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DiagnosticDetailscategorywise where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        // Diagnostic Image

        public string insertupdateDiagnosticgallery(int Id, int Category, int SubCategory, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateDiagnosticImage_New";
                cmd.Parameters.AddWithValue("Id", Id);

                cmd.Parameters.AddWithValue("Category", Category);

                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetDiagnosticImage()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetDiagnosticImage_New";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        /////


        public string insertupdateDiagnosticFeatureDetails(int Id, string CategoryName, string SubCategory, string Heading, string Description, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateDiagnosticFeatureDetails_New";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetDiagnosticFeatureDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DiagnosticFeatureDetails_New where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        ///Features Image details
        public string insertudateDiagnosticgallery1(int Id, int Category, int SubCategory, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateDiagnosticFeatureImage_New";
                cmd.Parameters.AddWithValue("Id", Id);

                cmd.Parameters.AddWithValue("Category", Category);
                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetDiagnosticFeatureImage()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DiagnosticFeatureImage_new where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }



        //// Insert Centrifuge details:

        public string insertupdatecentrifugeDetails11(int Id, string CategoryName, string Name, string Description, string EntryBy, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdatecentrifugeDetails";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Heading", Name);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }



        public DataTable GetCentrifugeDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from CentrifugeDetails where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable GetConsumableDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from ConsumableDetails where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string insertupdateLabConsumbleDetails11(int Id, string CategoryName, string SubCategory, string Heading, string Imppoint, string Description, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateLabConsumableDetails_New";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Imppoint", Imppoint);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }


        public DataTable GetLabConsumableDetails11()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LabConsumableDetails_New where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string insertupdatediagnosticDetails11(int Id, string CategoryName, string Name, string Description, string EntryBy, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateDiagnosticDetails_New";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Heading", Name);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }



        public DataTable GetDiagnosticDetailsNew()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DiagnosticDetails_New where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        // School Category
        public string insertupdateSchoolCategory(int Id, string CategoryName, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateSchoolCategory";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }



        public DataTable GetSchoolCategoryDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SchoolLab_category where IsActive=1 ");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        // School Heading 

        public string insertupdateSchoolHeading(int Id, string CategoryName, string Heading, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateSchoolHeading";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetSchoolHeadingDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SchoolLabHeading where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        // School Lab Details
        public string insertupdateschollDetails11(int Id, string CategoryName, string Name, string Description, string EntryBy, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateSchoolLabDetails";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Heading", Name);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }



        public DataTable GetSchoollabDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SchoollabDetails where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }



        // School Sub details

        public string insertupdateSchoolLabDetails(int Id, string CategoryName, string Heading, string Imppoint, string Description, string EntryBy, string Subcategory)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateSchoolSubDetails";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("subcategory", Subcategory);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Imppoint", Imppoint);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetSchoolLabDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SchoolSubdetailsDetails where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        // School Image Details

        public string insertupdateSchoolgallery(int Id, int Category, string Image, int SubCategory)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateSchoolImage";
                cmd.Parameters.AddWithValue("Id", Id);

                cmd.Parameters.AddWithValue("Category", Category);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Subcategory", SubCategory);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetSchoolImageGallery()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetSchoolImage";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }



        //School Lab Features Details

        public string insertupdateSchoolFeatureDetails(int Id, string CategoryName, string Subcategory, string Heading, string Description, string EntryBy)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateSchoolLabFeatureDetails";
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Subcategory", Subcategory);
                cmd.Parameters.AddWithValue("Heading", Heading);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("Entryby", EntryBy);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetSchoolFeatureDetails()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SchoolFeatureDetails_New where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        // School Feature Image

        public string insertupdateSchoolFeaturegallery(int Id, int Category, int SubCategory, string Image)
        {

            string str = "";
            Connection();
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_InsertUpdateSchoolFeatureImage";
                cmd.Parameters.AddWithValue("Id", Id);

                cmd.Parameters.AddWithValue("Category", Category);
                cmd.Parameters.AddWithValue("SubCategory", SubCategory);
                cmd.Parameters.AddWithValue("Image", Image);
                cmd.Parameters.AddWithValue("Msg", "");
                cmd.Parameters["Msg"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["Msg"].Size = 256;
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["Msg"].Value.ToString();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
                trans.Rollback();
            }
            con.Close();
            return str;

        }

        public DataTable GetSchoolLabFeatureImage()
        {
            Connection();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SchoolFeatureImage where IsActive=1");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }


        //shailendra

        public bool CheckFileValidate(HttpPostedFile file)
        {
            bool res = true;
            try
            {
                var supportedTypes = new[] { "doc", "pdf", "docx" };
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    res = false;
                }
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
    }






}