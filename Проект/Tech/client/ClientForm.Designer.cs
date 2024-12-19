namespace Tech
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelKolvo = new System.Windows.Forms.Label();
            this.buttonEditApp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCreateApp = new System.Windows.Forms.Button();
            this.requestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.____AMetYPDataSet = new Tech.____AMetYPDataSet();
            this.aMetYPDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.techBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.techTableAdapter = new Tech.____AMetYPDataSetTableAdapters.TechTableAdapter();
            this.requestsTableAdapter = new Tech.____AMetYPDataSetTableAdapters.RequestsTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.____AMetYPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aMetYPDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.techBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 479);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(218)))), ((int)(((byte)(184)))));
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.labelPhone);
            this.tabPage1.Controls.Add(this.labelFIO);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.buttonExit);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(856, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Главная";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(331, 251);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Телефон: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(331, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "ФИО: ";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPhone.Location = new System.Drawing.Point(469, 251);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(14, 20);
            this.labelPhone.TabIndex = 9;
            this.labelPhone.Text = "!";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.Location = new System.Drawing.Point(469, 207);
            this.labelFIO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(14, 20);
            this.labelFIO.TabIndex = 8;
            this.labelFIO.Text = "!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(335, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(151)))), ((int)(((byte)(4)))));
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(335, 332);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(193, 55);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(218)))), ((int)(((byte)(184)))));
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.labelKolvo);
            this.tabPage2.Controls.Add(this.buttonEditApp);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.buttonCreateApp);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(856, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Мои заявки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 318);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 260);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Поиск:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 260);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 22);
            this.textBox1.TabIndex = 21;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelKolvo
            // 
            this.labelKolvo.AutoSize = true;
            this.labelKolvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKolvo.Location = new System.Drawing.Point(19, 290);
            this.labelKolvo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKolvo.Name = "labelKolvo";
            this.labelKolvo.Size = new System.Drawing.Size(14, 20);
            this.labelKolvo.TabIndex = 20;
            this.labelKolvo.Text = "!";
            // 
            // buttonEditApp
            // 
            this.buttonEditApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(151)))), ((int)(((byte)(4)))));
            this.buttonEditApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditApp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonEditApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditApp.Location = new System.Drawing.Point(645, 361);
            this.buttonEditApp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEditApp.Name = "buttonEditApp";
            this.buttonEditApp.Size = new System.Drawing.Size(175, 62);
            this.buttonEditApp.TabIndex = 19;
            this.buttonEditApp.Text = "Редактировать заявку";
            this.buttonEditApp.UseVisualStyleBackColor = false;
            this.buttonEditApp.Click += new System.EventHandler(this.buttonEditApp_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(840, 226);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonCreateApp
            // 
            this.buttonCreateApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(151)))), ((int)(((byte)(4)))));
            this.buttonCreateApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateApp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonCreateApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateApp.Location = new System.Drawing.Point(23, 361);
            this.buttonCreateApp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateApp.Name = "buttonCreateApp";
            this.buttonCreateApp.Size = new System.Drawing.Size(175, 62);
            this.buttonCreateApp.TabIndex = 18;
            this.buttonCreateApp.Text = "Создать заявку";
            this.buttonCreateApp.UseVisualStyleBackColor = false;
            this.buttonCreateApp.Click += new System.EventHandler(this.buttonCreateApp_Click);
            // 
            // requestsBindingSource
            // 
            this.requestsBindingSource.DataMember = "Requests";
            this.requestsBindingSource.DataSource = this.____AMetYPDataSet;
            // 
            // ____AMetYPDataSet
            // 
            this.____AMetYPDataSet.DataSetName = "____AMetYPDataSet";
            this.____AMetYPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aMetYPDataSetBindingSource
            // 
            this.aMetYPDataSetBindingSource.DataSource = this.____AMetYPDataSet;
            this.aMetYPDataSetBindingSource.Position = 0;
            // 
            // techBindingSource
            // 
            this.techBindingSource.DataMember = "Tech";
            this.techBindingSource.DataSource = this.____AMetYPDataSet;
            // 
            // techTableAdapter
            // 
            this.techTableAdapter.ClearBeforeFill = true;
            // 
            // requestsTableAdapter
            // 
            this.requestsTableAdapter.ClearBeforeFill = true;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(218)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(895, 507);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.Text = "Профиль клиента";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.____AMetYPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aMetYPDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.techBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCreateApp;
        private System.Windows.Forms.Button buttonEditApp;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelKolvo;
        private System.Windows.Forms.BindingSource aMetYPDataSetBindingSource;
        private ____AMetYPDataSet ____AMetYPDataSet;
        private System.Windows.Forms.BindingSource techBindingSource;
        private ____AMetYPDataSetTableAdapters.TechTableAdapter techTableAdapter;
        private System.Windows.Forms.BindingSource requestsBindingSource;
        private ____AMetYPDataSetTableAdapters.RequestsTableAdapter requestsTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}