using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ввод_вывод
{
    public partial class Form1 : Form
    {
        private string selectedFile = "";
        public Form1()
        {
            InitializeComponent();
            fileContents.ReadOnly = true;
            openFileButton.Enabled = false;
            gzipFileButton.Enabled = false;
            fileContents.ScrollBars = ScrollBars.Vertical;
        }

        private List<string> GetFilesInDirectory(DirectoryInfo dir, string searchText)
        {
            var result = new List<string>(); 

            try
            {
                foreach (var file in dir.GetFiles())
                {
                    if (file.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        result.Add(file.FullName);
                }           
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка: { ex.Message}");
            }

            return result;
        }

        private List<string> GetResultDirectories(DirectoryInfo dir, string searchText)
        {
            var results = new List<string>();

            try
            {
                results.AddRange(GetFilesInDirectory(dir, searchText));

                foreach (var subDir in dir.GetDirectories())
                {
                    results.AddRange(GetResultDirectories(subDir, searchText));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обходе папки: {ex.Message}");
            }

            return results;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            string searchText = fileName.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите значение для поиска");
                return;
            }

            fileContents.Clear();
            fileListBox.Items.Clear();

            var files = new List<string>();

            foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
            {
                if (drive.Name == Constants.ExcludedDrive)
                    continue;
                files.AddRange(GetResultDirectories(drive.RootDirectory, searchText));
            }

            if (files.Count == 0) MessageBox.Show("Файлы не найдены");
            else
            {
                foreach (var file in files)
                {
                    fileListBox.Items.Add(file);
                }
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(selectedFile)) return;

            try
            {
                using (FileStream fs = new FileStream(selectedFile, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    fileContents.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}");
            }
        }

        private void gzipFileButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(selectedFile)) return;

            try
            {
                string compressed = selectedFile + ".gz";

                using (FileStream fs = new FileStream(selectedFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsc = new FileStream(compressed, FileMode.Create))
                using (GZipStream zs = new GZipStream(fsc, CompressionLevel.Optimal))
                {
                    fs.CopyTo(zs);
                }

                MessageBox.Show("Архив успешно создан");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}");
            }
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileListBox.SelectedItem != null)
            {
                selectedFile = fileListBox.SelectedItem.ToString();

                openFileButton.Enabled = true;
                gzipFileButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите файл");
            }
        }
    }
}
