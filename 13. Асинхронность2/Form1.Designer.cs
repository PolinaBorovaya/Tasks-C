namespace _13.Асинхронность2
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
            this.isCompleteButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.callbackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // isCompleteButton
            // 
            this.isCompleteButton.Location = new System.Drawing.Point(174, 128);
            this.isCompleteButton.Name = "isCompleteButton";
            this.isCompleteButton.Size = new System.Drawing.Size(147, 55);
            this.isCompleteButton.TabIndex = 0;
            this.isCompleteButton.Text = "IsComplete";
            this.isCompleteButton.UseVisualStyleBackColor = true;
            this.isCompleteButton.Click += new System.EventHandler(this.isCompleteButton_Click);
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(322, 253);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(147, 55);
            this.endButton.TabIndex = 0;
            this.endButton.Text = "End";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // callbackButton
            // 
            this.callbackButton.Location = new System.Drawing.Point(459, 128);
            this.callbackButton.Name = "callbackButton";
            this.callbackButton.Size = new System.Drawing.Size(147, 55);
            this.callbackButton.TabIndex = 0;
            this.callbackButton.Text = "Callback";
            this.callbackButton.UseVisualStyleBackColor = true;
            this.callbackButton.Click += new System.EventHandler(this.callbackButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.callbackButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.isCompleteButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button isCompleteButton;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button callbackButton;
    }
}

