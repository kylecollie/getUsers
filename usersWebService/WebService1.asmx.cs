using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using usersWebService.Model;

namespace usersWebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string HiKyle()
        {
            return "Hi Kyle!";
        }

        [WebMethod]
        public User[] GetUsers()
        {
            List<User> users = new List<Model.User>();
            using (SqlConnection sqlcon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Dev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                using (SqlCommand cmd = new SqlCommand("users_s", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            users.Add(new User((int)row["Id"], row["Firstname"].ToString(), row["Lastname"].ToString(), row["Username"].ToString(), row["FavColor"].ToString()));
                        }
                    }
                }
            }
            return users.ToArray();
        }
    }
}
