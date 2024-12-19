using System;
using System.Drawing;
using System.Windows.Forms;


namespace Tech
{
    public partial class CaptchaForm : Form
    {
        private string text = String.Empty;

        public CaptchaForm()
        {
            InitializeComponent();
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

            private void CaptchaForm_Load(object sender, EventArgs e)
            {
            }

        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            Bitmap result = new Bitmap(Width, Height);

            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);

            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            Graphics g = Graphics.FromImage((System.Drawing.Image)result);

            g.Clear(Color.White);

            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));

            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }


        private void buttonCaptcha_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (textBoxCaptcha.Text == this.text)
            {
                this.Hide();
                
            }  
            else
                MessageBox.Show("Ошибка! Неправильный ввод символов капчи", "Уведомление");
        }
    }
}
