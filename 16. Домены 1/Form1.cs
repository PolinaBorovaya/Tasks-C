using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;

namespace _16.Домены_1
{
    public partial class Form1 : Form
    {
        private string servicePath;

        public Form1()
        {
            InitializeComponent();
            LoadLog();
        }

        private void LoadLog()
        {
            try
            {
                if (string.IsNullOrEmpty(servicePath))
                {
                    logTextBox.Text = "Выберите файл службы";
                    return;
                }

                string logPath = Path.Combine(Path.GetDirectoryName(servicePath), "logs", "log_file.log");

                if (File.Exists(logPath))
                {
                    logTextBox.Text = File.ReadAllText(logPath);
                    logTextBox.SelectionStart = logTextBox.Text.Length;
                    logTextBox.ScrollToCaret();
                }
                else
                {
                    logTextBox.Text = $"Лог не найден:\n{logPath}";
                }
            }
            catch (Exception ex)
            {
                logTextBox.Text = $"Ошибка: {ex.Message}";
            }
        }

        private string GetServicePath()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Служба (*.exe)|*.exe";
                dlg.Title = "Выберите HardDriveMonitoringService.exe";
                return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
            }
        }

        private string GetInstallUtilPath()
        {
            string[] paths = new string[]
            {
                @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe",
                @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe",
                @"C:\Windows\Microsoft.NET\Framework\v2.0.50727\installutil.exe"
            };

            foreach (string path in paths)
            {
                if (File.Exists(path))
                    return path;
            }

            return null;
        }

        private bool IsServiceInstalled()
        {
            foreach (ServiceController sc in ServiceController.GetServices())
                if (sc.ServiceName == "HardDriveMonitoringService") return true;
            return false;
        }

        private bool IsServiceRunning()
        {
            try
            {
                ServiceController sc = new ServiceController("HardDriveMonitoringService");
                return sc.Status == ServiceControllerStatus.Running;
            }
            catch
            {
                return false;
            }
        }

        private void selectServiceButton_Click(object sender, EventArgs e)
        {
            servicePath = GetServicePath();
            if (!string.IsNullOrEmpty(servicePath))
            {
                LoadLog();
                MessageBox.Show($"Выбрано:\n{servicePath}");
            }
        }

        private void installationServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsServiceInstalled())
                {
                    MessageBox.Show("Служба уже установлена");
                    return;
                }

                if (string.IsNullOrEmpty(servicePath))
                    servicePath = GetServicePath();

                if (string.IsNullOrEmpty(servicePath) || !File.Exists(servicePath))
                {
                    MessageBox.Show("Файл службы не выбран");
                    return;
                }

                string installUtil = GetInstallUtilPath();
                if (string.IsNullOrEmpty(installUtil))
                {
                    MessageBox.Show("installutil.exe не найден!");
                    return;
                }

                Process p = new Process();
                p.StartInfo.FileName = installUtil;
                p.StartInfo.Arguments = $"\"{servicePath}\"";
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.Verb = "runas";
                p.Start();
                p.WaitForExit();

                LoadLog();
                MessageBox.Show("Установлено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void uninstallationServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsServiceInstalled())
                {
                    MessageBox.Show("Служба не установлена");
                    return;
                }

                if (IsServiceRunning())
                {
                    ServiceController sc = new ServiceController("HardDriveMonitoringService");
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                }

                if (string.IsNullOrEmpty(servicePath))
                    servicePath = GetServicePath();

                if (string.IsNullOrEmpty(servicePath) || !File.Exists(servicePath))
                {
                    MessageBox.Show("Файл службы не выбран");
                    return;
                }

                string installUtil = GetInstallUtilPath();
                if (string.IsNullOrEmpty(installUtil))
                {
                    MessageBox.Show("installutil.exe не найден!");
                    return;
                }

                Process p = new Process();
                p.StartInfo.FileName = installUtil;
                p.StartInfo.Arguments = $"/u \"{servicePath}\"";
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.Verb = "runas";
                p.Start();
                p.WaitForExit();

                MessageBox.Show("Удалено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void startServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsServiceInstalled())
                {
                    MessageBox.Show("Служба не установлена! Сначала нажмите 'Установить'.");
                    return;
                }

                if (IsServiceRunning())
                {
                    MessageBox.Show("Служба уже запущена");
                    return;
                }

                ServiceController sc = new ServiceController("HardDriveMonitoringService");
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));

                LoadLog();
                MessageBox.Show("Запущено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void stoppingServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsServiceInstalled())
                {
                    MessageBox.Show("Служба не установлена!");
                    return;
                }

                if (!IsServiceRunning())
                {
                    MessageBox.Show("Служба уже остановлена");
                    return;
                }

                ServiceController sc = new ServiceController("HardDriveMonitoringService");
                sc.Stop();  
                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));

                MessageBox.Show("Остановлено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}