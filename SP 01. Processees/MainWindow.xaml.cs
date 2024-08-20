using System.Diagnostics;
using System.Windows;


namespace SP_01._Processees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Process.Start("cmd");
            //Process.Start("calc");
            //Process.Start("mspaint");
            //Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");

            //procTextBox.Text = Process.GetCurrentProcess().ProcessName;
            //procTextBox.Text = Process.GetCurrentProcess().Id.ToString();
            //var process = Process.GetProcessById(7612);
            //process.Kill();

            //var processes = Process.GetProcessesByName("CalculatorApp");
            ////processes[0].Kill();
            //foreach (var process in processes)
            //{
            //    process.Kill();
            //}

            //var proc = Process.GetProcesses().ToList();
            //foreach(var p  in proc)
            //{
            //    procListBox.Items.Add($"{p.Id} {p.ProcessName}");
            //}

            //ProcessStartInfo startInfo = new ProcessStartInfo("calc");
            //Process.Start(startInfo);
        }
    }
}