namespace Ввод_вывод
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
            this.fileName = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.gzipFileButton = new System.Windows.Forms.Button();
            this.fileContents = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(29, 23);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(239, 22);
            this.fileName.TabIndex = 0;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(309, 21);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(212, 24);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Искать";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 16;
            this.fileListBox.Location = new System.Drawing.Point(29, 66);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(492, 148);
            this.fileListBox.TabIndex = 2;
            this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(29, 220);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(212, 24);
            this.openFileButton.TabIndex = 1;
            this.openFileButton.Text = "Открыть";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // gzipFileButton
            // 
            this.gzipFileButton.Location = new System.Drawing.Point(309, 220);
            this.gzipFileButton.Name = "gzipFileButton";
            this.gzipFileButton.Size = new System.Drawing.Size(212, 24);
            this.gzipFileButton.TabIndex = 1;
            this.gzipFileButton.Text = "Сжать";
            this.gzipFileButton.UseVisualStyleBackColor = true;
            this.gzipFileButton.Click += new System.EventHandler(this.gzipFileButton_Click);
            // 
            // fileContents
            // 
            this.fileContents.BackColor = System.Drawing.Color.White;
            this.fileContents.Location = new System.Drawing.Point(29, 272);
            this.fileContents.Multiline = true;
            this.fileContents.Name = "fileContents";
            this.fileContents.Size = new System.Drawing.Size(492, 305);
            this.fileContents.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 601);
            this.Controls.Add(this.fileContents);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.gzipFileButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.fileName);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button gzipFileButton;
        private System.Windows.Forms.TextBox fileContents;
    }
}

