using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class FileWriter
    {
        private readonly object _lockObject = new object();
        private readonly string _outputPath;

        public FileWriter(string outputPath)
        {
            _outputPath = outputPath;
            File.WriteAllText(_outputPath, string.Empty);
        }

        public void WriteLine(string line)
        {
            lock (_lockObject)
            {
                File.AppendAllText(_outputPath, line + Environment.NewLine);
                Console.WriteLine($"Записано: {line.Trim()}");
            }
        }

    }
}
