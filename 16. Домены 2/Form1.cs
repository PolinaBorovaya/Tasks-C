using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16.Домены_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectAssemblyButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pathFileTextBox.Text = ofd.FileName;
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(pathFileTextBox.Text))
            {
                MessageBox.Show("Выберите сборку");
            }

            AppDomain domain = null;

            try
            {
                if (privilegeCheckBox.Checked)
                {
                    PermissionSet permissionSet = new PermissionSet(System.Security.Permissions.PermissionState.None);
                    permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
                    permissionSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read, pathFileTextBox.Text));

                    Evidence evidence = new Evidence();
                    evidence.AddHostEvidence(new Zone(SecurityZone.Internet));

                    domain = AppDomain.CreateDomain(
                        "RestrictedDomain",
                        evidence,
                        new AppDomainSetup
                        {
                            ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                        },
                        permissionSet
                    );
                }
                else
                {
                    domain = AppDomain.CreateDomain("FullTrustDomain");
                }

                Log($"Сборка: {pathFileTextBox.Text}");
                Log($"Ограничения: {(privilegeCheckBox.Checked ? "вкл" : "выкл")}");

                domain.ExecuteAssembly(pathFileTextBox.Text);
                Log("Сборка завершена успешно");

                AppDomain.Unload(domain);
                Log("Домен выгружен");

            }catch(Exception ex)
            {
                Log(ex.Message);
            }
        }

        public void Log(string message)
        {
            logTextBox.AppendText($"{DateTime.Now} - {message}");
        }
    }
}
