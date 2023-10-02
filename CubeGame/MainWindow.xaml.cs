using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CubeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string SaveFilePath = "square_posotion.xml";
        private SquarePosition squarePosition;

        public MainWindow()
        {
            InitializeComponent();
            LoadSquarePosition();
            UpdateSquarePosition();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            const double Step = 10;

            switch (e.Key)
            {
                case Key.Up:
                    squarePosition.Top -= (squarePosition.Top > 0) ? Step : 0;
                    break;
                case Key.Down:
                    squarePosition.Top += (squarePosition.Top < Height - square.Height) ? Step : 0;
                    break;
                case Key.Left:
                    squarePosition.Left -= (squarePosition.Left > 0) ? Step : 0;
                    break;
                case Key.Right:
                    squarePosition.Left += (squarePosition.Left < Width - square.Width) ? Step : 0;
                    break;
            }

            UpdateSquarePosition();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSquarePosition();
        }

        private void LoadSquarePosition()
        {
            if (File.Exists(SaveFilePath))
            {
                try
                {
                    FileStream file = new FileStream(SaveFilePath, FileMode.Open);
                    XmlSerializer serializer = new XmlSerializer(typeof(SquarePosition));
                    squarePosition = serializer.Deserialize(file) as SquarePosition;
                    file.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                squarePosition = new SquarePosition();
            }
        }

        private void SaveSquarePosition()
        {
            try
            {
                FileStream file = new FileStream(SaveFilePath, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(SquarePosition));
                serializer.Serialize(file, squarePosition);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSquarePosition()
        {
            Canvas.SetLeft(square, squarePosition.Left);
            Canvas.SetTop(square, squarePosition.Top);
        }
    }
}
