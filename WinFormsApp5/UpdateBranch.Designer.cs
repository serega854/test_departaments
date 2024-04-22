namespace WinFormsApp5
{
    partial class UpdateBranch
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            Cancel = new Button();
            ok = new Button();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Подразделение", "Должность" });
            comboBox1.Location = new Point(114, 43);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 23);
            comboBox1.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(114, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 10;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(220, 140);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 9;
            Cancel.Text = "Отмена";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            ok.Location = new Point(139, 140);
            ok.Name = "ok";
            ok.Size = new Size(75, 23);
            ok.TabIndex = 8;
            ok.Text = "Ок";
            ok.UseVisualStyleBackColor = true;

            ok.Click += okButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 7;
            label2.Text = "Наименование:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 51);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 6;
            label1.Text = "Тип ветки:";
            // 
            // UpdateBranch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 229);
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

        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button Cancel;
        private Button ok;
        private Label label2;
        private Label label1;
    }
}