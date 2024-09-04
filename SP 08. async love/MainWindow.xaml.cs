using System.Net;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SP_08._async_love
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient client = new();
        string url = @"https://turbo.az/";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SimpleDownload(object sender, RoutedEventArgs e)
        {
            var txt = client.DownloadString(url);
            contentTextBox.Text = txt;
        }

        private async void DownloadAsync(object sender, RoutedEventArgs e)
        {
            var txt = await client.DownloadStringTaskAsync(url);
            contentTextBox.Text = txt;
        }

        private void DontClick(object sender, RoutedEventArgs e)
        {
            var tsk = client.DownloadStringTaskAsync(url);
            contentTextBox.Text = tsk.Result;
        }

        
        private void TaskDownload(object sender, RoutedEventArgs e)
        {
            var tsk = client
                .DownloadStringTaskAsync(url)
                .ContinueWith(t =>
                {
                    contentTextBox.Text = t.Result;
                }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void TaskContextDownload(object sender, RoutedEventArgs e)
        {
            var context = SynchronizationContext.Current;
            var tsk = client
                .DownloadStringTaskAsync(url)
                .ContinueWith(t =>
                {
                    context!.Send(_ =>
                    {
                        contentTextBox.Text = t.Result;
                    }, null);
                });
        }


        private void ClearTextBlock(object sender, RoutedEventArgs e)
        {
            contentTextBox.Clear();
        }
    }
}