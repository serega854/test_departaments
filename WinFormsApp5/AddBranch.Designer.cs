namespace WinFormsApp5
{
    partial class AddBranch
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
            label1 = new Label();
            label2 = new Label();
            ok = new Button();
            Cancel = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 36);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Тип ветки:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 66);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "Наименование:";
            // 
            // ok
            // 
            ok.Location = new Point(161, 125);
            ok.Name = "ok";
            ok.Size = new Size(75, 23);
            ok.TabIndex = 2;
            ok.Text = "Ок";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(242, 125);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 3;
            Cancel.Text = "Отмена";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            
            // 
            // textBox1
            // 
            textBox1.Location = new Point(136, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Подразделение", "Должность" });
            comboBox1.Location = new Point(136, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // UpdateBranch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 215);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(Cancel);
            Controls.Add(ok);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateBranch";
            Text = "UpdateBranch";
            Load += UpdateBranch_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button ok;
        private Button Cancel;
        private TextBox textBox1;
        private ComboBox comboBox1;
    }
}