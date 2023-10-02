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
        public static Point position;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            const double Step = 10;

            switch (e.Key)
            {
                case Key.Up:
                    position.Y -= (position.Y > 0) ? Step : 0;
                    break;
                case Key.Down:
                    position.Y += (position.Y < Height - square.Height) ? Step : 0;
                    break;
                case Key.Left:
                    position.X -= (position.X > 0) ? Step : 0;
                    break;
                case Key.Right:
                    position.X += (position.X < Width - square.Width) ? Step : 0;
                    break;
            }

            UpdateSquarePosition();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                GameLoader.SaveSquarePosition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSquarePosition()
        {
            Canvas.SetLeft(square, position.X);
            Canvas.SetTop(square, position.Y);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GameLoader.LoadSquarePosition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateSquarePosition();
        }
    }
}
