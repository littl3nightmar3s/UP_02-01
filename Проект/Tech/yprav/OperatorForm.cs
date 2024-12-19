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
using Tech.yprav;

namespace Tech
{
    public partial class OperatorForm : Form
    {
        private static SqlConnection con;
        private SqlCommand command;
        public int EmployeeID { get; set; }

        public OperatorForm(int EmployeeID)
        {
            InitializeComponent();
            this.EmployeeID = EmployeeID;
            countRequests();
            LoadRequests();
            Connect();
            LoadUserInfo();
            Pass();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.Show();
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

        private void LoadUserInfo()
        {
            Connect();

            string userInfoQuery = @"
                SELECT fio, type
                    FROM Employees 
                    WHERE employeeID = @EmployeeID";

            try
            {
                using (command = new SqlCommand(userInfoQuery, con))
                {
                    command.Parameters.AddWithValue("@EmployeeID", this.EmployeeID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelFIO.Text = reader["fio"].ToString();
                            labelEmployee.Text = reader["type"].ToString();
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
                    con.Close();
                }
            }
        }

        public void LoadRequests(string filter = "")
        {
            Connect();

            string requestsQuery = @"
    SELECT 
        r.requestID AS RequestID, 
        r.startDate AS StartDate, 
        t.type AS TechType, 
        t.model AS Model, 
        r.problem AS ProblemDescription, 
        s.status AS RequestStatus, 
        r.repairParts AS RepairParts, 
        r.completionDate AS CompletionDate, 
        e.fio AS Master
    FROM 
        Requests r
    LEFT JOIN 
        Tech t ON r.techId = t.techID
    LEFT JOIN 
        RequestStatus s ON r.statusId = s.StatusID
    LEFT JOIN 
        Employees e ON r.employeeId = e.employeeID
    AND (
        r.requestID LIKE @Filter OR
        r.startDate LIKE @Filter OR
        t.type LIKE @Filter OR
        t.model LIKE @Filter OR
        r.problem LIKE @Filter OR
        s.status LIKE @Filter OR 
        r.repairParts LIKE @Filter OR 
        r.completionDate LIKE @Filter OR
        e.fio LIKE @Filter )";

            try
            {
                using (var command = new SqlCommand(requestsQuery, con))
                {
                    command.Parameters.AddWithValue("@EmployeeID", this.EmployeeID);
                    command.Parameters.AddWithValue("@Filter", "%" + filter + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();

                        dataTable.Columns.Add("Номер");
                        dataTable.Columns.Add("Дата начала"); 
                        dataTable.Columns.Add("Тип техники");
                        dataTable.Columns.Add("Модель"); 
                        dataTable.Columns.Add("Описание проблемы");
                        dataTable.Columns.Add("Статус"); 
                        dataTable.Columns.Add("Запчасти"); 
                        dataTable.Columns.Add("Дата завершения");
                        dataTable.Columns.Add("Мастер"); 

                        while (reader.Read())
                        {
                            DataRow row = dataTable.NewRow();
                            row["Номер"] = reader["RequestID"].ToString();
                            row["Дата начала"] = Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd");
                            row["Тип техники"] = reader["TechType"].ToString();
                            row["Модель"] = reader["Model"].ToString();
                            row["Описание проблемы"] = reader["ProblemDescription"].ToString();
                            row["Статус"] = reader["RequestStatus"].ToString();
                            row["Запчасти"] = reader["RepairParts"]?.ToString();
                            row["Дата завершения"] = reader["CompletionDate"] != DBNull.Value ? Convert.ToDateTime(reader["CompletionDate"]).ToString("yyyy-MM-dd") : "Не завершено";
                            row["Мастер"] = reader["Master"]?.ToString();

                            dataTable.Rows.Add(row);
                        }

                        dataGridView1.DataSource = dataTable;

                        int totalRecords = dataTable.Rows.Count;
                        label4.Text = $"Количество записей: {totalRecords}";
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Ошибка получения данных заявок: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void countRequests()
        {
            Connect();
            SqlCommand commandKolvo = new SqlCommand("SELECT COUNT(*) FROM Requests", con);
            int totalRows = Convert.ToInt32(commandKolvo.ExecuteScalar());
            label5.Text = $"из {totalRows}";
            con.Close();
        }

        private void buttonAddMaster_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dataGridView1.SelectedRows.Count;
                if (row > 0 && dataGridView1.SelectedCells[0].Value != null)
                {
                    int requestID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                    EditMaster frm = new EditMaster(this, requestID);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Выберите заявку для выбора мастера!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }


        private void Pass()
        {
            Connect();
            string query = @"
SELECT   
    la.login_date, 
    CASE 
        WHEN e.employeeID IS NOT NULL THEN e.login 
        ELSE c.login 
    END AS login, 
    la.failure,
    la.id_user
FROM login_attmpts la
LEFT JOIN Employees e ON la.id_user = e.employeeID
LEFT JOIN Clients c ON la.id_user = c.clientID;";

            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            int successCount = 0;
            int failureCount = 0;

            dataGridView3.Columns.Clear(); 
            dataGridView3.Columns.Add("LoginDate", "Дата входа");
            dataGridView3.Columns.Add("Login", "Логин");
            dataGridView3.Columns.Add("Status", "Статус");
            dataGridView3.Columns.Add("UserId", "ID пользователя");

            while (reader.Read())
            {
                int failureValue = Convert.ToInt32(reader["failure"]);
                bool isSuccess = failureValue == 0;

                if (isSuccess)
                    successCount++;
                else
                    failureCount++;

                object userIdValue = reader["id_user"];
                string userId = userIdValue == DBNull.Value ? "Unknown" : userIdValue.ToString();

                string login = reader["login"] == DBNull.Value ? "Неверный логин" : reader["login"].ToString();

                string[] rowData = new string[4];
                rowData[0] = Convert.ToDateTime(reader["login_date"]).ToString();
                rowData[1] = login;
                rowData[2] = isSuccess ? "Успешно" : "Ошибка входа";
                rowData[3] = userId;

                data.Add(rowData);
            }
            reader.Close();

            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();

            foreach (string[] s in data)
                dataGridView3.Rows.Add(s);
        }
    }
}
