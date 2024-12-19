using Library;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tech;

namespace Tech
{
    public partial class EditAppForm : Form
    {
        BD Sql = new BD();
        private int userID; 
        private int requestID;
        ClientForm ClientForm; 
        private static SqlConnection con;
        private SqlCommand command;
        public EditAppForm(ClientForm f, int userID, int requestID, string type, string model, string problem)
        {
            InitializeComponent();
            Connect();
            LoadModels(type);
            comboBoxModelTech.SelectedItem = model;
            textBoxProblem.Text = problem; this.userID = userID;
            this.requestID = requestID;
            ClientForm = f;
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
        private void buttonEditApp_Click(object sender, EventArgs e)
        {
            if (comboBoxModelTech.SelectedItem == null)
            {
                MessageBox.Show("Выберите модель прибора"); return;
            }
            if (string.IsNullOrWhiteSpace(textBoxProblem.Text))
            {
                MessageBox.Show("Опишите проблему"); return;
            }
            try
            {
                BD db = new BD();        // Удаляем вызов db.Con();, так как соединение открывается в EditRequest
                bool isUpdated = db.EditRequest(requestID, comboBoxModelTech.SelectedItem.ToString(), textBoxProblem.Text);
                if (isUpdated)
                {
                    MessageBox.Show("Заявка успешно обновлена!");
                }
                else
                {
                    MessageBox.Show("Не удалось обновить заявку!");
                }
                ClientForm.LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            ClientForm.Show(); 
            this.Close();
        }
    }
}
 