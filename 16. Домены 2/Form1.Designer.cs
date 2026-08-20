namespace _16.Домены_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectAssemblyButton = new System.Windows.Forms.Button();
            this.pathFileTextBox = new System.Windows.Forms.TextBox();
            this.privilegeCheckBox = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // selectAssemblyButton
            // 
            this.selectAssemblyButton.Location = new System.Drawing.Point(419, 39);
            this.selectAssemblyButton.Name = "selectAssemblyButton";
            this.selectAssemblyButton.Size = new System.Drawing.Size(130, 58);
            this.selectAssemblyButton.TabIndex = 0;
            this.selectAssemblyButton.Text = "Выбрать сборку";
            this.selectAssemblyButton.UseVisualStyleBackColor = true;
            this.selectAssemblyButton.Click += new System.EventHandler(this.selectAssemblyButton_Click);
            // 
            // pathFileTextBox
            // 
            this.pathFileTextBox.Location = new System.Drawing.Point(32, 39);
            this.pathFileTextBox.Name = "pathFileTextBox";
            this.pathFileTextBox.Size = new System.Drawing.Size(365, 22);
            this.pathFileTextBox.TabIndex = 1;
            // 
            // privilegeCheckBox
            // 
            this.privilegeCheckBox.AutoSize = true;
            this.privilegeCheckBox.Location = new System.Drawing.Point(32, 77);
            this.privilegeCheckBox.Name = "privilegeCheckBox";
            this.privilegeCheckBox.Size = new System.Drawing.Size(188, 20);
            this.privilegeCheckBox.TabIndex = 2;
            this.privilegeCheckBox.Text = "Ограничить привилегии";
            this.privilegeCheckBox.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(32, 169);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(517, 59);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Запустить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(32, 257);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(517, 168);
            this.logTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.privilegeCheckBox);
            this.Controls.Add(this.pathFileTextBox);
            this.Controls.Add(this.selectAssemblyButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectAssemblyButton;
        private System.Windows.Forms.TextBox pathFileTextBox;
        private System.Windows.Forms.CheckBox privilegeCheckBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox logTextBox;
    }
}

