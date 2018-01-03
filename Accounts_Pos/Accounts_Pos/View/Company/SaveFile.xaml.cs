using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace Accounts_Pos.View.Company
{
    /// <summary>
    /// Interaction logic for SaveFile.xaml
    /// </summary>
    public partial class SaveFile : Window
    {
        string filename = null;
        string filepath = null;
        public SaveFile()
        {
            filename = App.Current.Properties["File_Name"].ToString();
            filepath = App.Current.Properties["File_Path"].ToString();

            InitializeComponent();
            
           
            
            Run run1 = new Run(filename);
            Hyperlink hLink = new Hyperlink(run1);
            hLink.Click += openFile_Click;
            FileNameText.Inlines.Clear();
            FileNameText.Inlines.Add(hLink);
            BrowseRadio.IsChecked = true;
            FolderRadio.IsChecked = false;

        }

        public void openFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(filepath + filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        public void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BrowseRadio.IsChecked == true)
                {
                    System.Diagnostics.Process.Start(filepath + filename);
                }
                else if (FolderRadio.IsChecked == true)
                {
                    System.Diagnostics.Process.Start("explorer.exe", filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SystemCommands.CloseWindow(this);
        }
    }
}
