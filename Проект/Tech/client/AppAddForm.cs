using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Library;

namespace Tech
{
    
    public partial class AppAddForm : Form
    {
        private static SqlConnection con;
        private SqlCommand command;
        private int userID;
        ClientForm ClientForm;
        public AppAddForm(ClientForm f, int userID)
        {
            InitializeComponent();
            Connect();
            LoadTechTypes();
            this.userID = userID;
            ClientForm = f;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            
            ClientForm.Show();
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

        private void LoadTechTypes()
        {
            try
            {
                Connect();
                comboBoxTypeTech.Items.Clear();

                command = new SqlCommand("SELECT DISTINCT [type] FROM Tech", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxTypeTech.Items.Add(reader["type"].ToString());
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке типов приборов: " + ex.Message);
            }
        }

        private void LoadModels(string type)
        {
            try
            {
                Connect();
                comboBoxModelTech.Items.Clear();

                command = new SqlCommand("SELECT model FROM Tech WHERE [type] = @type", con);
                command.Parameters.AddWithValue("@type", type);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxModelTech.Items.Add(reader["model"].ToString());
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке моделей: " + ex.Message);
            }
        }

        private void comboBoxTypeTech_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxTypeTech.SelectedItem != null)
            {
                LoadModels(comboBoxTypeTech.SelectedItem.ToString());
            }
        }

        private void buttonSendApp_Click(object sender, EventArgs e)
        {
            if (comboBoxTypeTech.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип прибора");
                return;
            }

            if (comboBoxModelTech.SelectedItem == null)
            {
                MessageBox.Show("Выберите модель прибора");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxProblem.Text))
            {
                MessageBox.Show("Опишите проблему");
                return;
            }

            try
            {
                Connect();

                command = new SqlCommand("SELECT techID FROM Tech WHERE [type] = @type AND model = @model", con);
                command.Parameters.AddWithValue("@type", comboBoxTypeTech.SelectedItem.ToString());
                command.Parameters.AddWithValue("@model", comboBoxModelTech.SelectedItem.ToString());

                var result = command.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Указанный прибор не найден в базе данных.");
                    return;
                }
                int techID = (int)result;

                command = new SqlCommand("SELECT StatusID FROM RequestStatus WHERE [status] = 'Новая заявка'", con);
                int statusID = (int)command.ExecuteScalar();

                command = new SqlCommand("INSERT INTO Requests (startDate, techId, problem, statusId, completionDate, repairParts, employeeId, clientId) " +
                                          "VALUES (@startDate, @techId, @problem, @statusId, @completionDate, @repairParts, @employeeId, @clientId)", con);

                command.Parameters.AddWithValue("@startDate", DateTime.Now);
                command.Parameters.AddWithValue("@techId", techID);
                command.Parameters.AddWithValue("@problem", textBoxProblem.Text);
                command.Parameters.AddWithValue("@statusId", statusID);
                command.Parameters.AddWithValue("@completionDate", DBNull.Value);
                command.Parameters.AddWithValue("@repairParts", DBNull.Value);
                command.Parameters.AddWithValue("@employeeId", DBNull.Value); 
                command.Parameters.AddWithValue("@clientId", userID);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Заявка успешно создана!", "Поздравляем!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClientForm.LoadRequests(); 
                }
                else
                {
                    MessageBox.Show("Не удалось создать заявку!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении заявки: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
        }
    }
}


