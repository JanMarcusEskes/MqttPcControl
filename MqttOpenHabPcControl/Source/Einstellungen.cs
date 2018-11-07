using System;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

//Jan-Marcus Eskes 2016

namespace MqttOpenHabPcControl.Source
{
    /// <summary>
    /// Speichert Variabelen in einer Datei (.xml) und kann diese wieder laden
    /// </summary>
    public class Einstellungen
    {
        public string mqttBrokerAdress = "";
        public Int16 mqttBrokerPort = 1883;

        public bool mqttNeedLogin = false;
        public string mqttUser = "";
        public string mqttPassword = "";

        public bool mqttProtocol3_1 = false;

        public bool mqttTLS_SSL = false;
        public string mqttPathToCertificate = "";

        public Guid PcGuid = Guid.NewGuid();
        public string PcFrindlyName = Environment.MachineName;
        public string scriptFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);

        public bool autostart = true;

        //Dateiname der Einstellungsdatei
        static string filename = "MqttOpenHabPcControl.xml";
        //Dateipfad der Einstellungsdatei
        private static string filepath
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), filename); }
        }

        /// <summary>
        /// Speichert das Einstellungsobjekt
        /// </summary>
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Einstellungen));
            StreamWriter writer = null;

            try
            {
                writer = File.CreateText(filepath);
                serializer.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Schreiben der Einstellungen:\n" + ex.Message, "Einstellungen speichern", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (writer != null) { writer.Close(); writer.Dispose(); }
            }
        }
        /// <summary>
        /// Läd die gespeicherten Werte ein
        /// </summary>
        /// <returns>Die geladenen Einstellungsobjekt</returns>
        public static Einstellungen Load()
        {
            if (!File.Exists(filepath)) return new Einstellungen();

            XmlSerializer serializer = new XmlSerializer(typeof(Einstellungen));
            using (StreamReader reader = File.OpenText(filepath))
            {
                try
                {
                    return (Einstellungen)serializer.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Laden der Einstellungen:\n" + ex.Message, "Einstellungen laden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
            }
            return new Einstellungen();
        }
    }
}
