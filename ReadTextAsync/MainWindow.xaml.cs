using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ReadTextAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource CancellationTokenSource;
        private const string FilePath = "largefile.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource = new CancellationTokenSource();

            try
            {
                string text = await File.ReadAllTextAsync(FilePath, CancellationTokenSource.Token);
                textBox.Text = text;
            }
            catch (OperationCanceledException)
            {
                textBox.Text = "Читання файлу було скасовано";
            }
            catch (Exception ex)
            {
                textBox.Text = ex.Message;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource?.Cancel();
        }
    }
}
