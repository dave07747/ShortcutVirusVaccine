using System;
using System.Collections.Generic;
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

        private bool isProcessRunning = false;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            progress.Value = 0;
            FolderBrowserDialog browser = new FolderBrowserDialog();
            //browser.RootFolder = Environment.SpecialFolder.System;
            browser.ShowNewFolderButton = false;

            System.Windows.Forms.DialogResult result = browser.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {

                string temp = browser.SelectedPath;
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

           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (isProcessRunning)
            {
                MessageBox.Show("Already in progress");
            }
            else
            {
             

               
                    
                for (int i = 0; i < 99; ++i)
                {
                    progress.Value = i;
                    
                    Thread.Sleep(100);
                }
                

                clean();
                progress.Value = 100;
                
                
                MessageBox.Show("Vaccine complete!");

            }
        }
    }
}
