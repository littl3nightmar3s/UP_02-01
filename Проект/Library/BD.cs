using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library
{
    public class BD
    {
        private SqlConnection con;
        public BD()
        {
            con = new SqlConnection("Data Source=DESKTOP-S2UBJ1D\\SQLEXPRESS; Initial Catalog=YP; Integrated Security=True;");
            //con = new SqlConnection("Data Source=192.168.188.11; Initial Catalog=!!!AMetYP; Integrated Security=True;");
        }

        public void Con()
        {
            con.Open();
        }
        public void closeCon()
        {
            con.Close();
        }

        // логин форма
        public int LoginUser(string username, string password)
        {
            string query = "SELECT employeeID FROM Employees WHERE login = @userlogin AND password = @userpassword";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userlogin", username);
                cmd.Parameters.AddWithValue("@userpassword", password);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();
                if (result != null)
                    return Convert.ToInt32(result);
            }

            query = "SELECT clientID FROM Clients WHERE login = @userlogin AND password = @userpassword";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userlogin", username);
                cmd.Parameters.AddWithValue("@userpassword", password);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public string RoleUser(string username, string password)
        {
            string query = "SELECT type FROM Employees WHERE login = @userlogin AND password = @userpassword";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@userlogin", username);
                cmd.Parameters.AddWithValue("@userpassword", password);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();
                return result != null ? Convert.ToString(result) : "none";
            }
        }

        public void AddFailurePlus(string login)
        {
            int? userId = null;

            using (SqlCommand cmd = new SqlCommand("SELECT clientID FROM Clients WHERE [login] = @login", con))
            {
                cmd.Parameters.AddWithValue("@login", login);
                con.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
                con.Close();
            }

            if (userId.HasValue)
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO login_attmpts (id_user, login_date, failure) VALUES (@id_user, @Date, 1);", con))
                {
                    cmd.Parameters.AddWithValue("@id_user", userId.Value);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("SELECT employeeID FROM Employees WHERE [login] = @login", con))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                    }
                    con.Close();
                }

                if (userId.HasValue)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO login_attmpts (id_user, login_date, failure) VALUES (@id_user, @Date, 1);", con))
                    {
                        cmd.Parameters.AddWithValue("@id_user", userId.Value);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        public void AddFailureMinus(int userId)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO login_attmpts (id_user, login_date, failure) VALUES (@id_user, @Date, 0);", con))
            {
                cmd.Parameters.AddWithValue("@id_user", userId);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // клиент
        public void LoadUserInfo(Label labelFIO, Label labelPhone, int userID)
        {
            Con();
            string userInfoQuery = @"
                SELECT fio, phone
                    FROM Clients 
                    WHERE clientID = @userID";

            try
            {
                using (SqlCommand command = new SqlCommand(userInfoQuery, con))
                {
                    command.Parameters.AddWithValue("@userID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelFIO.Text = reader["fio"].ToString();
                            labelPhone.Text = reader["phone"].ToString();
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Ошибка получения данных о пользователе: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    closeCon();
                }
            }
        }

        // редактирование заявки для клиента
        public bool EditRequest(int requestID, string model, string problem)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Модель не может быть пустой.");
            }
            if (string.IsNullOrWhiteSpace(problem))
            {
                throw new ArgumentException("Проблема не может быть пустой.");
            }

            try
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT techID FROM Tech WHERE model = @model", con))
                {
                    command.Parameters.AddWithValue("@model", model);
                    var result = command.ExecuteScalar();
                    if (result == null)
                    {
                        throw new Exception("Указанная модель не найдена в базе данных!");
                    }
                    int techID = (int)result;

                    command.CommandText = "UPDATE Requests SET techId = @techId, problem = @problem WHERE requestID = @requestID";
                    command.Parameters.Clear(); 
                    command.Parameters.AddWithValue("@techId", techID);
                    command.Parameters.AddWithValue("@problem", problem);
                    command.Parameters.AddWithValue("@requestID", requestID);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Произошла ошибка при обновлении заявки: {ex.Message}");
            }
            finally
            {
                closeCon();
            }
        }
    }
}
