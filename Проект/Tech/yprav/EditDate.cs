using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Tech.yprav
{
    public partial class EditDate : Form
    {
        ManagerForm oper;
        private static SqlConnection con;
        private SqlCommand command;
        private int requestID;
        public EditDate(ManagerForm f, int requestID)
        {
            InitializeComponent();
            LoadDate("Мастер");
            this.requestID = requestID;
            oper = f;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            oper.Show();
            this.Close();
        }

        private static void Connect()
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-S2UBJ1D\\SQLEXPRESS; Initial Catalog=YP; Integrated Security=True;");
                //con = new SqlConnection("Data Source=192.168.188.11; Initial Catalog=!!!AMetYP; Integrated Security=True;");

                con.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Ошибка подключения к базе данных: {ex.Message}");
            }
        }

        private void LoadDate(string type)
        {
            try
            {
                Connect();

                command = new SqlCommand("SELECT completionDate FROM Requests WHERE requestID = @requestID", con);
                command.Parameters.AddWithValue("@requestID", requestID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dateTimePickerCompletionDate.Value = reader["completionDate"] != DBNull.Value ? Convert.ToDateTime(reader["completionDate"]) : DateTime.Now;
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке: " + ex.Message);
            }
        }

        private void buttonEditApp_Click(object sender, EventArgs e)
        {
            try
            {
                Connect();

                command = new SqlCommand("UPDATE Requests SET completionDate = @completionDate WHERE requestID = @requestID", con);
                command.Parameters.AddWithValue("@completionDate", dateTimePickerCompletionDate.Value);
                command.Parameters.AddWithValue("@requestID", requestID);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Заявка успешно обновлена!");
                }
                else
                {
                    MessageBox.Show("Не удалось обновить заявку!");
                }

                oper.LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при обновлении даты заявки: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
