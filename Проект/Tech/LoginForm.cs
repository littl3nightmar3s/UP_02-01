using System;
using System.Drawing;
using System.Windows.Forms;
using Library;
using QRCoder;

namespace Tech
{
    public partial class LoginForm : Form
    {
        BD Sql = new BD();
        private int attempts = 0;
        private bool captchaRequare = false;
        private Timer timer;


        public LoginForm()
        {
            InitializeComponent();

            // Настройка таймера для блокировки
            timer = new Timer
            {
                Interval = 180000 // 3 минуты
            };
            timer.Tick += Timer_Tick;
            QR();
        }

        private void QR()
        {
            string url = "https://vk.com/littlenightmaresss";

            if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);

                        pictureBoxQR.Image = qrCodeImage;
                    }
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            if (attempts >= 2)
            {
                Block();
                return;
            }

            int userID = Sql.LoginUser(login, password);
            string role = "Клиент";

            if (attempts == 1)
            {
                try
                {
                    CaptchaForm captchaForm = new CaptchaForm();
                    captchaForm.ShowDialog();
                    if (MessageBox.Show("Верно!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if (userID != -1)
                        {
                            if (checkBoxEmployees.Checked == true)
                                role = Sql.RoleUser(login, password);
                            switch (role)
                            {
                                case "Клиент":
                                    ClientForm clientf = new ClientForm(userID);
                                    clientf.Show();
                                    break;
                                case "Оператор":
                                    OperatorForm operatorf = new OperatorForm(userID);
                                    operatorf.Show();
                                    break;
                                case "Мастер":
                                    MasterForm masterf = new MasterForm(userID);
                                    masterf.Show();
                                    break;
                                case "Менеджер":
                                    MasterForm masterf1 = new MasterForm(userID);
                                    masterf1.Show();
                                    break;
                                default:
                                    MessageBox.Show("Запись роли пользователя не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            attempts++;
                            Sql.AddFailurePlus(login);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    attempts++;
                    Sql.AddFailurePlus(login);
                }
            }
            else if (attempts == 0)
            {
                try
                {
                    if (checkBoxEmployees.Checked == true)
                        role = Sql.RoleUser(login, password);
                    if (userID != -1)
                    {
                        Form userForm;
                        switch (role)
                        {
                            case "Клиент":
                                userForm = new ClientForm(userID);
                                break;
                            case "Оператор":
                                userForm = new OperatorForm(userID);
                                break;
                            case "Мастер":
                                userForm = new MasterForm(userID);
                                break;
                            case "Менеджер":
                                userForm = new ManagerForm(userID);
                                break;
                            default:
                                userForm = null;
                                MessageBox.Show("Запись роли пользователя не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                        }
                        if (userForm != null)
                        {
                            Sql.AddFailureMinus(userID);
                            userForm.Show();
                            Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        attempts++;
                        Sql.AddFailurePlus(login);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка!");
                    attempts++;
                    Sql.AddFailurePlus(login);
                }
            }
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked)
                textBoxPassword.PasswordChar = '\0';
            else
                textBoxPassword.PasswordChar = '*';
        }

        private void Block()
        {
            buttonLogin.Enabled = false;
            timer.Start();
            MessageBox.Show("Вы не можете вводить логин и пароль 3 минуты из-за превышения количества попыток", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            int remainingTime = timer.Interval / 1000; 
            labelTimer.Text = $"Заблокировано на {remainingTime} секунд";

            Timer countdownTimer = new Timer
            {
                Interval = 1000
            };
            countdownTimer.Tick += (s, e) =>
            {
                remainingTime--;
                labelTimer.Text = $"Заблокировано на {remainingTime} секунд";

                if (remainingTime <= 0)
                {
                    countdownTimer.Stop();
                    labelTimer.Text = "Кнопка разблокирована";
                    buttonLogin.Enabled = true;
                }
            };
            countdownTimer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            attempts = 0;
        }
    }
}
