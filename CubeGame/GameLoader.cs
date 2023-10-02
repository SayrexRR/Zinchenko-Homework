using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace CubeGame
{
    public static class GameLoader
    {
        private const string SaveFilePath = "square_posotion.xml";
        private static XmlSerializer serializer = new XmlSerializer(typeof(Point));

        public static void LoadSquarePosition()
        {
            if (File.Exists(SaveFilePath))
            {
                try
                {
                    FileStream file = new FileStream(SaveFilePath, FileMode.Open);
                    MainWindow.position = (Point)serializer.Deserialize(file);
                    file.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MainWindow.position = new Point();
            }
        }

        public static void SaveSquarePosition()
        {
            try
            {
                FileStream file = new FileStream(SaveFilePath, FileMode.Create);
                serializer.Serialize(file, MainWindow.position);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
