using System.Windows;
using Microsoft.Win32;

namespace NLIIS_Machine_translation
{
    public partial class MainWindow : Window
    {
        private readonly OpenFileDialog _openFileDialog;
        
        public MainWindow()
        {
            _openFileDialog = new OpenFileDialog
            {
                DefaultExt = "txt",
                CheckFileExists = true,
                Multiselect = false
            };
            
            InitializeComponent();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }
        
        private void Authors_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Group 721701:\nSemenikhin Nikita,\nStryzhych Angelika", "Authors");
        }

        private void Translate(object sender, RoutedEventArgs e)
        {
            
        }

        private void OpenFileDialog(object sender, RoutedEventArgs e)
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                DocumentToReferPath.Text = _openFileDialog.FileName;
            }
        }
    }
}