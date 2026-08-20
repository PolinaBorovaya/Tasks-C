namespace _15.Async_Await
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
            this.dbInfoTextBox = new System.Windows.Forms.TextBox();
            this.connectToDbButton = new System.Windows.Forms.Button();
            this.disconnectToDbButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dbInfoTextBox
            // 
            this.dbInfoTextBox.Location = new System.Drawing.Point(152, 158);
            this.dbInfoTextBox.Multiline = true;
            this.dbInfoTextBox.Name = "dbInfoTextBox";
            this.dbInfoTextBox.Size = new System.Drawing.Size(479, 225);
            this.dbInfoTextBox.TabIndex = 0;
            // 
            // connectToDbButton
            // 
            this.connectToDbButton.Location = new System.Drawing.Point(106, 31);
            this.connectToDbButton.Name = "connectToDbButton";
            this.connectToDbButton.Size = new System.Drawing.Size(207, 78);
            this.connectToDbButton.TabIndex = 1;
            this.connectToDbButton.Text = "Подключиться к базе данных";
            this.connectToDbButton.UseVisualStyleBackColor = true;
            this.connectToDbButton.Click += new System.EventHandler(this.connectToDbButton_Click);
            // 
            // disconnectToDbButton
            // 
            this.disconnectToDbButton.Location = new System.Drawing.Point(470, 31);
            this.disconnectToDbButton.Name = "disconnectToDbButton";
            this.disconnectToDbButton.Size = new System.Drawing.Size(207, 78);
            this.disconnectToDbButton.TabIndex = 1;
            this.disconnectToDbButton.Text = "Отключиться от базы данных";
            this.disconnectToDbButton.UseVisualStyleBackColor = true;
            this.disconnectToDbButton.Click += new System.EventHandler(this.disconnectToDbButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.disconnectToDbButton);
            this.Controls.Add(this.connectToDbButton);
            this.Controls.Add(this.dbInfoTextBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dbInfoTextBox;
        private System.Windows.Forms.Button connectToDbButton;
        private System.Windows.Forms.Button disconnectToDbButton;
    }
}

