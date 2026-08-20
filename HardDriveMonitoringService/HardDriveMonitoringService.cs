using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HardDriveMonitoringService
{
    public partial class HardDriveMonitoringService : ServiceBase
    {
        private string applicationDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private string logFilePath => Path.Combine(applicationDirectory, "logs", "log_file.log");

        public HardDriveMonitoringService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
            WriteToLog($"Служба запущена в {DateTime.Now}");

            DriveMonitoring();
        }

        private void DriveMonitoring()
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                try
                {
                    var watcher = new FileSystemWatcher
                    {
                        Path = drive.Name,
                        IncludeSubdirectories = true,
                        EnableRaisingEvents = true,
                        NotifyFilter = NotifyFilters.FileName
                    };

                    watcher.Deleted += OnFileDeleted;

                    WriteToLog($"Настроен мониторинг для диска {drive.Name}");
                }
                catch (Exception ex)
                {
                    WriteToLog($"Произошла ошибка: {ex.Message}");
                }
            }

        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            WriteToLog($"Файл был удалён: {e.FullPath}"); 

        }

        protected override void OnStop()
        {
            WriteToLog($"Служба остановлена в {DateTime.Now}");
        }

        private void WriteToLog(string message)
        {
            try
            {
                lock (this)
                {
                    File.AppendAllText(logFilePath, message + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry($"Ошибка записи в лог: {ex.Message}",
                                    System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}
