using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Data.SqlClient;
using Library;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private BD db;
        [TestMethod]
        public void TestMethod1()
        {
            string login = "login2";
            string pass = "pass2";
            int userid = 1;
            BD sql = new BD();
            int userid_query = sql.LoginUser(login, pass);
            Assert.AreEqual(userid_query, userid);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string login = "perinaAD";
            string pass = "250519";
            BD sql = new BD();
            string role = "Оператор";
            string role_query = sql.RoleUser(login, pass);
            Assert.AreEqual(role_query, role);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string login = "perinaAD";
            string pass = "250519";
            BD sql = new BD();
            string role = "Менеджер";
            string role_query = sql.RoleUser(login, pass);
            Assert.AreNotEqual(role_query, role);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string login = "login2";
            string pass = "250519";
            int userid = 2;
            BD sql = new BD();
            int userid_query = sql.LoginUser(login, pass);
            Assert.AreNotEqual(userid_query, userid);
        }


        [TestMethod]
        public void TestMethod5()
        {
            BD sql = new BD();
            int requestID = 1; 
            string newModel = "Ладомир ТА112 белый"; 
            string newProblem = "Не включается"; 

            bool isUpdated = sql.EditRequest(requestID, newModel, newProblem);

            Assert.IsTrue(isUpdated, "Заявка не была обновлена.");

            string query = "SELECT problem FROM Requests WHERE requestID = @requestID";
            using (SqlConnection con = new SqlConnection("Data Source=192.168.188.11; Initial Catalog=!!!AMetYP; Integrated Security=True;"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@requestID", requestID);
                    var result = cmd.ExecuteScalar();
                    Assert.AreEqual(newProblem, result.ToString(), "Проблема не была обновлена в базе данных.");
                }
            }
        }
    }
}
