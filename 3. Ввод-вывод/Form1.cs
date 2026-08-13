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
            textBox2.ReadOnly = true;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox2.ScrollBars = ScrollBars.Vertical;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите значение для поиска");
                return;
            }

            textBox2.Clear();
            listBox1.Items.Clear();

            var files = new List<string>();

            foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
            {
                if (drive.Name == "C:\\")
                    continue;
                SearchDirectory(drive.RootDirectory, searchText, files);
            }

            if (files.Count == 0) MessageBox.Show("Файлы не надйены");
            else
            {
                foreach (var file in files)
                {
                    listBox1.Items.Add(file);
                }
            }
        }

        private void SearchDirectory(DirectoryInfo dir, string searchText, List<string> result)
        {
            try
            {
                foreach (var file in dir.GetFiles())
                {
                    if (file.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        result.Add(file.FullName);
                }           

                foreach (var subDir in dir.GetDirectories())
                    SearchDirectory(subDir, searchText, result);
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка: { ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(selectedFile)) return;

            try
            {
                using(FileStream fs = new FileStream(selectedFile, FileMode.Open, FileAccess.Read))
                {
                    using(StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        textBox2.Text = sr.ReadToEnd();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selectedFile = listBox1.SelectedItem.ToString();

                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите файл");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!File.Exists(selectedFile)) return;

            try
            {
                string compressed = selectedFile + ".gz";

                using (FileStream fs = new FileStream(selectedFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsc = new FileStream(compressed, FileMode.Create))
                using(GZipStream zs = new GZipStream(fsc, CompressionLevel.Optimal))
                {
                    fs.CopyTo(zs);
                }

                MessageBox.Show("Архив успешно создан");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}");
            }
        }
    }
}
