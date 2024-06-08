using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ConnectionClass
/// </summary>
namespace StablishConnection
{
    public class ConnectionClassNew
    {
        public ConnectionClassNew()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string str = System.Configuration.ConfigurationManager.AppSettings["asthaparadise"].ToString();
        public SqlConnection con;
        public void Connection()
        {
            con = new SqlConnection(str);
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
    }
}