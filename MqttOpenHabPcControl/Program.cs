using Microsoft.Win32;
using MqttOpenHabPcControl.Source;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttOpenHabPcControl
{
    static class Program
    {
        public static Einstellungen einstellungen = Einstellungen.Load();
        public static bool locked = false;
        private static MqttClient client;
        readonly static string computerState = "Computer/" + einstellungen.PcFrindlyName + "/state";
        readonly static string computerCommand = "Computer/" + einstellungen.PcFrindlyName + "/command";
        readonly static string allCommand = "Computer/ALL/command";
        readonly static string allState = "Computer/ALL/state";
        public static bool customRetain = false;

        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(false, "Global\\" + einstellungen.PcGuid);
            if (!mutex.WaitOne(0, false))
            {
                MessageBox.Show("Instance already running");
                return;
            }

            Initialize();

            if (einstellungen.mqttBrokerAdress == String.Empty || !PingHost(einstellungen.mqttBrokerAdress, einstellungen.mqttBrokerPort))
            {
                locked = true;
                Settings settings = new Settings();
                settings.ShowDialog();
                locked = false;
            }

            if (einstellungen.mqttBrokerAdress == String.Empty)
            {
                return;
            }

            if (einstellungen.mqttTLS_SSL)
            {
                //client = new MqttClient(einstellungen.mqttBrokerAdress, einstellungen.mqttBrokerPort, true, new System.Security.Cryptography.X509Certificates.X509Certificate(einstellungen.mqttPathToCertificate),null, null);
            }
            else
                client = new MqttClient(einstellungen.mqttBrokerAdress, einstellungen.mqttBrokerPort, false, MqttSslProtocols.None, null, null);

            if (einstellungen.mqttProtocol3_1)
                client.ProtocolVersion = MqttProtocolVersion.Version_3_1;

            byte code;
            if (einstellungen.mqttNeedLogin)
                code = client.Connect(einstellungen.PcGuid.ToString(), einstellungen.mqttUser, einstellungen.mqttPassword, true, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true, computerState, "shutdown", true, 60);
            else
                code = client.Connect(einstellungen.PcGuid.ToString(), null, null, true, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true, computerState, "shutdown", true, 60);

            switch (code)
            {
#if DEBUG
                case 0:
                    MessageBox.Show("Connection established", "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
#endif
                case 1:
                    MessageBox.Show("An error has occurred!\nMessage: Connection refused, unacceptable protocol version!", "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 2:
                    MessageBox.Show("An error has occurred!\nMessage: Connection refused, identifier rejected!", "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 3:
                    MessageBox.Show("An error has occurred!\nMessage: Connection refused, server unavailable!", "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 4:
                    MessageBox.Show("An error has occurred!\nMessage: Connection refused, bad user name or password!", "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 5:
                    MessageBox.Show("An error has occurred!\nMessage: Connection refused, not authorized!", "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                default:
                    break;
            }

            client.MqttMsgPublished += MqttMsgPublished;
            client.MqttMsgPublishReceived += MqttMsgReceived;
            client.ConnectionClosed += MqttConnectionClosed;

            client.Publish(computerState, Encoding.UTF8.GetBytes("online"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);

            client.Subscribe(new string[] { computerCommand, allCommand }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });


            Application.Run();

            if (!customRetain)
                client.Publish(computerState, Encoding.UTF8.GetBytes("shutdown"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);

            client.ConnectionClosed -= MqttConnectionClosed;
            client.Disconnect();

            mutex.Close();
        }

        public static void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("MQTTPcControl", Application.ExecutablePath, RegistryValueKind.String);
            }
            else
            {
                try
                {
                    registryKey.DeleteValue("MQTTPcControl");
                }
                catch (Exception)
                {

                }
            }
        }

        public static bool PingHost(string hostUri, Int16 portNumber)
        {
            try
            {
                using (var client = new TcpClient(hostUri, portNumber))
                    return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        private static void MqttConnectionClosed(object sender, EventArgs e)
        {
            MessageBox.Show("An error has occurred!\nMessage: The connection to the broker is interrupted", "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private static void MqttMsgReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String message = Encoding.UTF8.GetString(e.Message);
            String topic = e.Topic;
            String answerTopic = e.Topic.Equals(computerCommand) ? computerState : allState;
            String command = einstellungen.scriptFolder != String.Empty ? einstellungen.scriptFolder + "\\" + message : message;

#if DEBUG
                    MessageBox.Show(e.Topic + "\n" + message, "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
            switch (message)
            {
                case "WhosThere":
                    client.Publish(answerTopic, Encoding.UTF8.GetBytes(einstellungen.PcFrindlyName), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    break;
                case "lock":
                    client.Publish(computerState, Encoding.UTF8.GetBytes("lock"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    Process.Start("RunDll32.exe", "user32.dll, LockWorkStation");
                    break;
                case "reboot":
                    client.Publish(computerState, Encoding.UTF8.GetBytes("reboot"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
                    customRetain = true;
                    Process.Start("shutdown.exe", "-r -t 00");
                    break;
                case "sleep":
                    client.Publish(computerState, Encoding.UTF8.GetBytes("sleep"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
                    Process.Start("shutdown.exe", "-h");
                    break;
                case "shutdown":
                    client.Publish(computerState, Encoding.UTF8.GetBytes("shutdown"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
                    Process.Start("shutdown.exe", "-s -t 00");
                    break;
                default:
                    break;
            }



            if (File.Exists(command + ".cmd"))
                Process.Start(command + ".cmd");
            else if (File.Exists(command + ".bat"))
                Process.Start(command + ".bat");
            else if (File.Exists(command + ".exe"))
                Process.Start(command + ".exe");
            else if (File.Exists(command + ".lnk"))
                Process.Start(command + ".lnk");
        }

        private static void MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
#if DEBUG
            MessageBox.Show(e.MessageId + "\nIsPublished = " + e.IsPublished, "MQTT PC Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
        }

        static void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                //I returned to my desk
                client.Publish(computerState, Encoding.UTF8.GetBytes("online"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
            }
        }


        static void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            ToolStripMenuItem tsmiBeenden = new ToolStripMenuItem()
            {
                Name = "beendenToolStripMenuItem",
                Size = new System.Drawing.Size(152, 22),
                Text = "Exit"
            };
            tsmiBeenden.Click += new EventHandler(tsmiBeenden_Click);
            ToolStripMenuItem tsmiSettings = new ToolStripMenuItem()
            {
                Name = "settingsToolStripMenuItem",
                Size = new System.Drawing.Size(152, 22),
                Text = "Settings"
            };
            tsmiSettings.Click += new EventHandler(tsmiSettings_Click);

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip()
            {
                Name = "ContextMenutrip",
                Size = new System.Drawing.Size(153, 48)
            };

            contextMenuStrip.Items.AddRange(new ToolStripItem[] { tsmiSettings, tsmiBeenden });

            NotifyIcon notifyIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.mqtt,
                Visible = true
            };

            notifyIcon.ContextMenuStrip = contextMenuStrip;

            RegisterInStartup(einstellungen.autostart);

        }

        private static void tsmiSettings_Click(object sender, EventArgs e)
        {
            if (!locked)
            {
                locked = true;
                Settings settings = new Settings();
                settings.ShowDialog();
                locked = false;
            }
        }

        private static void tsmiBeenden_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
