namespace Tech
{
    partial class AppAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppAddForm));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSendApp = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.comboBoxTypeTech = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxProblem = new System.Windows.Forms.TextBox();
            this.comboBoxModelTech = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "Создание заявки";
            // 
            // buttonSendApp
            // 
            this.buttonSendApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(151)))), ((int)(((byte)(4)))));
            this.buttonSendApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSendApp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSendApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSendApp.Location = new System.Drawing.Point(377, 539);
            this.buttonSendApp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSendApp.Name = "buttonSendApp";
            this.buttonSendApp.Size = new System.Drawing.Size(193, 60);
            this.buttonSendApp.TabIndex = 6;
            this.buttonSendApp.Text = "Отправить";
            this.buttonSendApp.UseVisualStyleBackColor = false;
            this.buttonSendApp.Click += new System.EventHandler(this.buttonSendApp_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(151)))), ((int)(((byte)(4)))));
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("MingLiU-ExtB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(16, 15);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(63, 46);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.Text = "<";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // comboBoxTypeTech
            // 
            this.comboBoxTypeTech.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTypeTech.FormattingEnabled = true;
            this.comboBoxTypeTech.Location = new System.Drawing.Point(147, 132);
            this.comboBoxTypeTech.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTypeTech.Name = "comboBoxTypeTech";
            this.comboBoxTypeTech.Size = new System.Drawing.Size(664, 33);
            this.comboBoxTypeTech.TabIndex = 8;
            this.comboBoxTypeTech.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeTech_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(143, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Выберите тип прибора";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(143, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Выберите модель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(143, 303);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Опишите проблему";
            // 
            // textBoxProblem
            // 
            this.textBoxProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProblem.Location = new System.Drawing.Point(147, 326);
            this.textBoxProblem.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxProblem.Multiline = true;
            this.textBoxProblem.Name = "textBoxProblem";
            this.textBoxProblem.Size = new System.Drawing.Size(664, 186);
            this.textBoxProblem.TabIndex = 13;
            // 
            // comboBoxModelTech
            // 
            this.comboBoxModelTech.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxModelTech.FormattingEnabled = true;
            this.comboBoxModelTech.Location = new System.Drawing.Point(147, 233);
            this.comboBoxModelTech.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxModelTech.Name = "comboBoxModelTech";
            this.comboBoxModelTech.Size = new System.Drawing.Size(664, 33);
            this.comboBoxModelTech.TabIndex = 14;
            // 
            // AppAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(218)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(963, 614);
            this.Controls.Add(this.comboBoxModelTech);
            this.Controls.Add(this.textBoxProblem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTypeTech);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSendApp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSendApp;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ComboBox comboBoxTypeTech;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxProblem;
        private System.Windows.Forms.ComboBox comboBoxModelTech;
    }
}