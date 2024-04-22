
namespace WinFormsApp5
{
    partial class DepartmentForm
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
            treeView1 = new TreeView();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            select = new Button();
            clear = new Button();
            add = new Button();
            upt = new Button();
            del = new Button();
            select_person = new Button();
            info = new Label();
            to = new Button();
            back = new Button();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 61);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(335, 377);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(384, 92);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 1;
            label1.Text = "Фамилия:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(483, 89);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(190, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(483, 118);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(190, 23);
            textBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(384, 121);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 3;
            label2.Text = "Имя:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(483, 147);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(190, 23);
            textBox3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(384, 150);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 5;
            label3.Text = "Отчество:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(384, 182);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 7;
            label4.Text = "Дата принятия: ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(483, 176);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(190, 23);
            dateTimePicker1.TabIndex = 8;
            // Установка свойства Enabled на false для DateTimePicker
            dateTimePicker1.Enabled = false;

            // 
            // select
            // 
            select.Location = new Point(384, 243);
            select.Name = "select";
            select.Size = new Size(75, 23);
            select.TabIndex = 9;
            select.Text = "Выбрать";
            select.UseVisualStyleBackColor = true;
          select.Click += select_person2;
            
            // 
            // clear
            // 
            clear.Location = new Point(465, 243);
            clear.Name = "clear";
            clear.Size = new Size(75, 23);
            clear.TabIndex = 10;
            clear.Text = "Очистить";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clearButton_Click;
           
            // 
            // add
            // 
            add.Image = Properties.Resources.add1;
            add.Location = new Point(65, 14);
            add.Name = "add";
            add.Size = new Size(41, 41);
            add.TabIndex = 11;
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // upt
            // 
            upt.Image = Properties.Resources.upt;
            upt.Location = new Point(112, 14);
            upt.Name = "upt";
            upt.Size = new Size(41, 41);
            upt.TabIndex = 12;
            upt.UseVisualStyleBackColor = true;
            upt.Click += upt_Click;
            // 
            // del
            // 
            del.Image = Properties.Resources.del;
            del.Location = new Point(159, 14);
            del.Name = "del";
            del.Size = new Size(41, 41);
            del.TabIndex = 13;
            del.UseVisualStyleBackColor = true;
            del.Click += del_Click;
            // 
            // select_person
            // 
            select_person.Image = Properties.Resources.oth;
            select_person.Location = new Point(206, 14);
            select_person.Name = "select_person";
            select_person.Size = new Size(41, 41);
            select_person.TabIndex = 15;
            select_person.UseVisualStyleBackColor = true;
            select_person.Click += sel_Click;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Location = new Point(371, 208);
            info.Name = "info";
            info.Size = new Size(0, 15);
            info.TabIndex = 16;
            // 
            // to
            // 
            to.Image = Properties.Resources.to;
            to.Location = new Point(664, 208);
            to.Name = "to";
            to.Size = new Size(28, 22);
            to.TabIndex = 17;
            to.UseVisualStyleBackColor = true;
            to.Click += to_Click;



            // 
            // back
            // 
            back.Image = Properties.Resources.back;
            back.Location = new Point(630, 208);
            back.Name = "back";
            back.Size = new Size(28, 22);
            back.TabIndex = 18;
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // DepartmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(back);
            Controls.Add(to);
            Controls.Add(info);
            Controls.Add(select_person);
            Controls.Add(del);
            Controls.Add(upt);
            Controls.Add(add);
            Controls.Add(clear);
            Controls.Add(select);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(treeView1);
            Name = "DepartmentForm";
            Text = "DepartmentForm";
            Load += DepartmentForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        private EventHandler to_Click(object selectedPosition)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TreeView treeView1;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker1;

        private Button select;
        private Button clear;
        private Button add;
        private Button upt;
        private Button del;
        private Button select_person;
        private Label info;
        private Button to;
        private Button back;
    }
}