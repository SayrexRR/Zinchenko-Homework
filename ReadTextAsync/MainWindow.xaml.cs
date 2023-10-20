using Microsoft.Win32;
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
        private const int BufferSize = 1024;

        private CancellationTokenSource cancellationTokenSource;
        private string cancelMessage = "Читання файлу було скасовано";
        private bool isCanceled;

        public MainWindow()
        {
            InitializeComponent();
            cancellationTokenSource = new CancellationTokenSource();
            isCanceled = false;
        }

        private async void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                textBox.Clear();

                try
                {
                    using (var reader = new StreamReader(dialog.FileName))
                    {
                        char[] buffer = new char[BufferSize];
                        int charsRead;

                        while ((charsRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0 && !isCanceled)
                        {
                            string text = new string(buffer, 0, charsRead);
                            textBox.AppendText(text);
                            await Task.Delay(500);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show(cancelMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    isCanceled = false;
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource?.Dispose();
            isCanceled = true;
            cancellationTokenSource = new CancellationTokenSource();
        }
    }
}
