namespace WinFormsApp5
{
    partial class updateEmployees
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
            Cancel = new Button();
            ok = new Button();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // Cancel
            // 
            Cancel.Location = new Point(227, 180);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 28;
            Cancel.Text = "Отмена";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += cancel_Click;
            // cancel_Click
            // ok
            // 
            ok.Location = new Point(146, 180);
            ok.Name = "ok";
            ok.Size = new Size(75, 23);
            ok.TabIndex = 27;
            ok.Text = "Ок";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(112, 130);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(190, 23);
            dateTimePicker1.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 136);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 25;
            label4.Text = "Дата принятия: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(112, 101);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(190, 23);
            textBox3.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 104);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 23;
            label3.Text = "Отчество:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(112, 72);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(190, 23);
            textBox2.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 75);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 21;
            label2.Text = "Имя:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(112, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(190, 23);
            textBox1.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 46);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 19;
            label1.Text = "Фамилия:";
            // 
            // updateEmployees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 286);
            Controls.Add(Cancel);
            Controls.Add(ok);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "updateEmployees";
            Text = "updateEmployees";
            Load += updateEmployees_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Cancel;
        private Button ok;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
    }
}