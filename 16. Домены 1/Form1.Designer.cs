namespace _16.Домены_1
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
            this.installationServiceButton = new System.Windows.Forms.Button();
            this.uninstallationServiceButton = new System.Windows.Forms.Button();
            this.startServiceButton = new System.Windows.Forms.Button();
            this.stoppingServiceButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // installationServiceButton
            // 
            this.installationServiceButton.Location = new System.Drawing.Point(32, 27);
            this.installationServiceButton.Name = "installationServiceButton";
            this.installationServiceButton.Size = new System.Drawing.Size(140, 77);
            this.installationServiceButton.TabIndex = 0;
            this.installationServiceButton.Text = "Установка службы";
            this.installationServiceButton.UseVisualStyleBackColor = true;
            this.installationServiceButton.Click += new System.EventHandler(this.installationServiceButton_Click);
            // 
            // uninstallationServiceButton
            // 
            this.uninstallationServiceButton.Location = new System.Drawing.Point(224, 27);
            this.uninstallationServiceButton.Name = "uninstallationServiceButton";
            this.uninstallationServiceButton.Size = new System.Drawing.Size(140, 77);
            this.uninstallationServiceButton.TabIndex = 0;
            this.uninstallationServiceButton.Text = "Деинсталляция службы";
            this.uninstallationServiceButton.UseVisualStyleBackColor = true;
            this.uninstallationServiceButton.Click += new System.EventHandler(this.uninstallationServiceButton_Click);
            // 
            // startServiceButton
            // 
            this.startServiceButton.Location = new System.Drawing.Point(425, 27);
            this.startServiceButton.Name = "startServiceButton";
            this.startServiceButton.Size = new System.Drawing.Size(140, 77);
            this.startServiceButton.TabIndex = 0;
            this.startServiceButton.Text = "Старт ";
            this.startServiceButton.UseVisualStyleBackColor = true;
            this.startServiceButton.Click += new System.EventHandler(this.startServiceButton_Click);
            // 
            // stoppingServiceButton
            // 
            this.stoppingServiceButton.Location = new System.Drawing.Point(618, 27);
            this.stoppingServiceButton.Name = "stoppingServiceButton";
            this.stoppingServiceButton.Size = new System.Drawing.Size(140, 77);
            this.stoppingServiceButton.TabIndex = 0;
            this.stoppingServiceButton.Text = "Остановка";
            this.stoppingServiceButton.UseVisualStyleBackColor = true;
            this.stoppingServiceButton.Click += new System.EventHandler(this.stoppingServiceButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(32, 144);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(726, 260);
            this.logTextBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.stoppingServiceButton);
            this.Controls.Add(this.startServiceButton);
            this.Controls.Add(this.uninstallationServiceButton);
            this.Controls.Add(this.installationServiceButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button installationServiceButton;
        private System.Windows.Forms.Button uninstallationServiceButton;
        private System.Windows.Forms.Button startServiceButton;
        private System.Windows.Forms.Button stoppingServiceButton;
        private System.Windows.Forms.TextBox logTextBox;
    }
}

