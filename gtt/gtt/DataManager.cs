using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

namespace gtt
{
    /// <summary>
    /// Klasa STATYCZNA zarządzająca zapisem danych do telefonu i odczytem.
    /// </summary>
    /// 
    public static class DataManager
    {

        /// <summary>
        /// Zmienna stała, jest nazwą pliku do którego będą zapisane dane usera.
        /// </summary>
        private const string FILENAME = "PlayerData.xml";

        /// <summary>
        /// Flaga mówiąca o tym, czy należy stworzyć playera
        /// </summary>
        public static bool CreatePlayer;









        /// <summary>
        /// Szuka danych playera
        /// </summary>
        public static void SeekForPlayerData()
        {
            // Otwieramy pamięc izolowaną
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();

            if (file.FileExists(FILENAME))
            {
                // Jezeli plik istnieje nie ma potrzeby tworzenia usera
                CreatePlayer =  false;
            }

            // Jeżeli nie ma pliku należy stworzyć usera
            CreatePlayer = true;
            
        }

        /// <summary>
        /// Funkcja zapisuje dane w postaci XML do pliku.
        /// </summary>
        /// <param name="name"></param>
        public static void SaveUserData(string name, uint score = 0)
        {
            // Otwieramy dostęp do izolowanej pamięci
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();

            // Otwieramy plik, lub tworzymy go jeżeli go nie ma.
            IsolatedStorageFileStream stream = file.OpenFile(FILENAME, System.IO.FileMode.OpenOrCreate);

            // Tworzymy zapisywacz do pliku xml.
            XmlWriter writer = XmlWriter.Create(stream);

            // Zapisywanie danych do xmla
            writer.WriteStartDocument();
                writer.WriteStartElement("player");
                    writer.WriteElementString("name", name);
                    writer.WriteElementString("score", name);
                writer.WriteEndElement();
            writer.WriteEndDocument();

            // Write the XML to the file.
            writer.Flush();

            // Zamknięcie strumienia
            stream.Close();

            temporary();
        }

        /// <summary>
        /// Chwilowa funkcja do sprawdzenia danych xml
        /// </summary>
        private static void temporary()
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();

            if (file.FileExists(FILENAME))
            {
                IsolatedStorageFileStream stream = file.OpenFile(FILENAME,System.IO.FileMode.Open);

                System.IO.StreamReader filestreamReader = new System.IO.StreamReader(stream);

                XElement _xml = XElement.Parse(filestreamReader.ReadToEnd());

                XAttribute name = _xml.Attribute("name");

            }
            else
            {
                var b = "prawda";
            }

        }

        public static List<string> ExtractPlayerXmlData(List<string> attributes)
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();

            if (file.FileExists(FILENAME))
            {
                IsolatedStorageFileStream stream = file.OpenFile(FILENAME, System.IO.FileMode.Open);

                System.IO.StreamReader filestreamReader = new System.IO.StreamReader(stream);

                XElement _xml = XElement.Parse(filestreamReader.ReadToEnd());

                XAttribute name = _xml.Attribute("player");

                List<string> bla = new List<string>();
                bla.Add(name.Value);
                return bla;



            }
            else return new List<string>();


        }
    }
}
