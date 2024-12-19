using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Tech.master
{
    public partial class EditForMaster : Form
    {

        private int employeeID;
        private int requestID;
        MasterForm MasterForm;
        private static SqlConnection con;
        private SqlCommand command;
        public EditForMaster(MasterForm f, int employeeID, int requestID)
        {
            InitializeComponent();
            Connect();
            this.employeeID = employeeID;
            this.requestID = requestID;
            MasterForm = f;
            LoadStatuses(); 
            LoadRequestDetails();
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
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
            }
        }

        private void LoadStatuses()
        {
            try
            {
                Connect();
                command = new SqlCommand("SELECT StatusID, [status] FROM RequestStatus", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxStatus.Items.Add(new
                    {
                        Text = reader["status"].ToString(),
                        Value = reader["StatusID"]
                    });
                }

                comboBoxStatus.DisplayMember = "Text";
                comboBoxStatus.ValueMember = "Value";

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке статусов: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        private void LoadRequestDetails()
        {
            try
            {
                Connect();
                command = new SqlCommand("SELECT statusId, completionDate, repairParts FROM Requests WHERE requestID = @requestID", con);
                command.Parameters.AddWithValue("@requestID", requestID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBoxStatus.SelectedValue = reader["statusId"];
                        dateTimePickerCompletionDate.Value = reader["completionDate"] != DBNull.Value ? Convert.ToDateTime(reader["completionDate"]) : DateTime.Now;
                        textBoxRepairParts.Text = reader["repairParts"]?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных заявки: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close(); 
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MasterForm.Show();
            this.Close();
        }

        private void buttonEditApp_Click(object sender, EventArgs e)
        {
            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус заявки");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxRepairParts.Text))
            {
                MessageBox.Show("Укажите замененные детали");
                return;
            }

            try
            {
                con.Open();

                command = new SqlCommand("UPDATE Requests SET statusId = @statusId, completionDate = @completionDate, repairParts = @repairParts WHERE requestID = @requestID", con);
                command.Parameters.AddWithValue("@statusId", ((dynamic)comboBoxStatus.SelectedItem).Value);
                command.Parameters.AddWithValue("@completionDate", dateTimePickerCompletionDate.Value);
                command.Parameters.AddWithValue("@repairParts", textBoxRepairParts.Text);
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

                MasterForm.LoadRequests();
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
