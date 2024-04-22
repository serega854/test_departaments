namespace WinFormsApp5
{
    partial class EmployeesForm
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
            dataGridView1 = new DataGridView();
            del = new Button();
            upt = new Button();
            add = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(55, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(803, 147);
            dataGridView1.TabIndex = 0;
            // 
            // del
            // 
            del.Image = Properties.Resources.del;
            del.Location = new Point(149, 3);
            del.Name = "del";
            del.Size = new Size(41, 41);
            del.TabIndex = 16;
            del.UseVisualStyleBackColor = true;
            del.Click += delButton_Click;

            
            // 
            // upt
            // 
            upt.Image = Properties.Resources.upt;
            upt.Location = new Point(102, 3);
            upt.Name = "upt";
            upt.Size = new Size(41, 41);
            upt.TabIndex = 15;
            upt.UseVisualStyleBackColor = true;
            upt.Click += uptButton_Click;
            // 
            // add
            // 
            add.Image = Properties.Resources.add1;
            add.Location = new Point(55, 3);
            add.Name = "add";
            add.Size = new Size(41, 41);
            add.TabIndex = 14;
            add.UseVisualStyleBackColor = true;

            add.Click += addButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(124, 212);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 23);
            textBox1.TabIndex = 17;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 215);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 18;
            label1.Text = "Фамилия:";
//            label1.Click += this.label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(312, 215);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 20;
            label2.Text = "Имя:";
            label2.Click += label2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(352, 212);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(148, 23);
            textBox2.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(516, 215);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 22;
            label3.Text = "Отчество:";
            label3.Click += label3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(583, 212);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(148, 23);
            textBox3.TabIndex = 21;
            // 
            // button1
            // 
            button1.Location = new Point(766, 212);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 23;
            button1.Text = "Найти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += search_Click;
            
            // 
            // Empliyees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 373);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(del);
            Controls.Add(upt);
            Controls.Add(add);
            Controls.Add(dataGridView1);
            Name = "Empliyees";
            Text = "Empliyees";
            Load += Empliyees_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button del;
        private Button upt;
        private Button add;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Button button1;
    }
}