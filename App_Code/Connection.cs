using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.Web;
using System.Linq;
using System;

/// <summary>
/// Summary description for Connection
/// </summary>
namespace stablishconnection
{
    public class Connection
    {
        public Connection()
        {
            //
            // TODO: Add constructor logic here
            //
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

        public string ToSafeFileName(string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("'", "")
                .Replace(" ", "")
                .Replace("|", "");
        }

        //shailendra

        public bool CheckFileValidate(HttpPostedFile file)
        {
            bool res = true;
            try
            {
                var supportedTypes = new[] { "jpg", "jpeg", "png" };
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