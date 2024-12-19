using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tech.yprav
{
    public partial class EditMaster : Form
    {
        OperatorForm oper;
        private static SqlConnection con;
        private SqlCommand command;
        private int requestID;


        public EditMaster(OperatorForm f, int request)
        {
            InitializeComponent();
            LoadMaster("Мастер");
            this.requestID = request;
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

        private void LoadMaster(string type)
        {
            try
            {
                Connect();
                comboBoxMaster.Items.Clear(); 

                command = new SqlCommand("SELECT fio FROM Employees WHERE [type] = @type", con);
                command.Parameters.AddWithValue("@type", type);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxMaster.Items.Add(reader["fio"].ToString());
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
            if (comboBoxMaster.SelectedItem == null)
            {
                MessageBox.Show("Выберите мастера");
                return;
            }
            try
            {
                Connect();

                command = new SqlCommand("SELECT employeeId FROM Employees WHERE fio = @fio AND type = @type", con);
                command.Parameters.AddWithValue("@fio", comboBoxMaster.SelectedItem.ToString());
                command.Parameters.AddWithValue("@type", "Мастер");

                var result = command.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Указанный мастер не найден в базе данных!");
                    return;
                }
                int employeeID = (int)result;

                command = new SqlCommand("UPDATE Requests SET employeeId = @employeeID WHERE requestId = @requestid", con);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.Parameters.AddWithValue("@requestid", requestID);

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
                MessageBox.Show($"Произошла ошибка при обновлении заявки: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
        }

    }
}
