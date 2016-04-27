using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Shortcut_Virus_Vaccine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private BackgroundWorker bw = new BackgroundWorker();
        private bool isProcessRunning = false;
        private string temp;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            progress.Value = 0;
            FolderBrowserDialog browser = new FolderBrowserDialog();
            //browser.RootFolder = Environment.SpecialFolder.System;
            browser.ShowNewFolderButton = false;

            System.Windows.Forms.DialogResult result = browser.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {

                 temp = browser.SelectedPath;
                drive.Text = temp[0] + @":\";
            }
            else
            {
                MessageBox.Show("No drive was selected!");
            }
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void clean()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "attrib -h -r -s /s /d " + drive.Text + "*.*";
                process.StartInfo = startInfo;
                process.Start();
 
               
            }));
          
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (isProcessRunning)
            {
                MessageBox.Show("Already in progress");
            }
            else
            {
                bw.WorkerReportsProgress = true;
                bw.DoWork += delegate
                {
                    clean();
                };
                bw.ProgressChanged += bw_ProgressChanged;
                
                bw.RunWorkerCompleted += (object send, RunWorkerCompletedEventArgs ee) =>
                {
                    progress.Value = 100;
                    MessageBox.Show("Your flashdrive is now squeaky clean!");
                };
               
                bw.RunWorkerAsync();

            }
        }
    }
}
