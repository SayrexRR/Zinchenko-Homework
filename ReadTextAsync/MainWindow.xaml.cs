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
        private readonly CancellationTokenSource cancellationTokenSource;
        private const string FilePath = "largefile.txt";
        private string cancelMessage = "Читання файлу було скасовано";

        public MainWindow()
        {
            InitializeComponent();
            cancellationTokenSource = new CancellationTokenSource();
        }

        private async void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = await File.ReadAllTextAsync(FilePath, cancellationTokenSource.Token);
                textBox.Text = text;
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show(cancelMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
