using Microsoft.Win32;
using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MqttOpenHabPcControl
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            txtBrokerAdress.Text = Program.einstellungen.mqttBrokerAdress;
            nudBrokerPort.Value = decimal.Parse(Program.einstellungen.mqttBrokerPort.ToString());
            rdbMqttProtocol3_1.Checked = Program.einstellungen.mqttProtocol3_1;

            ckbLoginRequired.Checked = Program.einstellungen.mqttNeedLogin;
            txtUser.Text = Program.einstellungen.mqttUser;
            txtPassword.Text = Program.einstellungen.mqttPassword;

            ckbTLS_SSL.Checked = Program.einstellungen.mqttTLS_SSL;
            txtPathToCertificate.Text = Program.einstellungen.mqttPathToCertificate;

            txtGuid.Text = Program.einstellungen.PcGuid.ToString();
            txtFriendlyName.Text = Program.einstellungen.PcFrindlyName;

            txtScriptFolder.Text = Program.einstellungen.scriptFolder;
            ckbAutostart.Checked = Program.einstellungen.autostart;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Choose X509 Certificate",
                CheckFileExists = true,
                FileName = txtPathToCertificate.Text,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(openFileDialog.FileName))
                {
                    MessageBox.Show("An error has occurred!\nMessage: The file you chose didn't exist", openFileDialog.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Program.einstellungen.mqttPathToCertificate = openFileDialog.FileName;
                txtPathToCertificate.Text = openFileDialog.FileName;
            }
        }

        private void ckbLoginRequired_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = ckbLoginRequired.Checked;
            txtPassword.Enabled = ckbLoginRequired.Checked;
        }

        private void ckbTLS_SSL_CheckedChanged(object sender, EventArgs e)
        {
            txtPathToCertificate.Enabled = ckbTLS_SSL.Checked;
            btnSearch.Enabled = ckbTLS_SSL.Checked;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Int16 port = Int16.Parse(nudBrokerPort.Value.ToString());

            if (txtBrokerAdress.Text == String.Empty || !Program.PingHost(txtBrokerAdress.Text, port))
            {
                if (DialogResult.No == MessageBox.Show("An error has occurred!\nMessage: You didn't enter a valid Broker-Adress or port!\nDo you want to leave without saving?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                    e.Cancel = true;
                return;
            }

            if (ckbLoginRequired.Checked && (txtUser.Text == String.Empty || txtPassword.Text == String.Empty))
            {
                if (DialogResult.No == MessageBox.Show("An error has occurred!\nMessage: You didn't enter a valid username and/or password!\nDo you want to leave without saving?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                    e.Cancel = true;
                return;
            }

            if (ckbTLS_SSL.Checked && (txtPathToCertificate.Text == String.Empty || !File.Exists(txtPathToCertificate.Text)))
            {
                if (DialogResult.No == MessageBox.Show("An error has occurred!\nMessage: You didn't enter a valid path to the X.509 cretificate!\nDo you want to leave without saving?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                    e.Cancel = true;
                return;
            }

            if (txtFriendlyName.Text == String.Empty)
            {
                if (DialogResult.No == MessageBox.Show("An error has occurred!\nMessage: You didn't enter a valid frindly name for this PC!\nDo you want to leave without saving?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                    e.Cancel = true;
                return;
            }

            Program.einstellungen.mqttBrokerAdress = txtBrokerAdress.Text;
            Program.einstellungen.mqttBrokerPort = port;
            Program.einstellungen.mqttProtocol3_1 = rdbMqttProtocol3_1.Checked;
            Program.einstellungen.mqttNeedLogin = ckbLoginRequired.Checked;
            Program.einstellungen.mqttUser = txtUser.Text;
            Program.einstellungen.mqttPassword = txtPassword.Text;
            Program.einstellungen.mqttTLS_SSL = ckbTLS_SSL.Checked;
            Program.einstellungen.mqttPathToCertificate = txtPathToCertificate.Text;
            Program.einstellungen.PcFrindlyName = txtFriendlyName.Text;
            Program.einstellungen.scriptFolder = txtScriptFolder.Text;
            Program.einstellungen.autostart = ckbAutostart.Checked;

            Program.einstellungen.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearchScript_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
                Description = "Choose the directory, where the scripts are get loaded from",
                ShowNewFolderButton = true
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    MessageBox.Show("An error has occurred!\nMessage: The file you chose didn't exist", "Choose Script folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Program.einstellungen.mqttPathToCertificate = folderBrowserDialog.SelectedPath;
                txtScriptFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ckbAutostart_CheckedChanged(object sender, EventArgs e)
        {
                Program.RegisterInStartup(ckbAutostart.Checked);
        }
    }
}
