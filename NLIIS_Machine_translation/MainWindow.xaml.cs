using System.Windows;
using Microsoft.Win32;
using NLIIS_Machine_translation.Services;

namespace NLIIS_Machine_translation
{
    public partial class MainWindow : Window
    {
        private readonly OpenFileDialog _openFileDialog;
        
        public MainWindow()
        {
            MongoDBConnector.CreateSession("nliis");
            
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
            MessageBox.Show(string.Empty);
        }
        
        private void Authors_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Group 721701:\nSemenikhin Nikita,\nStryzhych Angelika", "Authors");
        }

        private void TranslateDocument(object sender, RoutedEventArgs e)
        {
            
        }

        private void UploadTranslations(object sender, RoutedEventArgs e)
        {
            DictionaryService.AddFromFile(DocumentToUploadPath.Text);
        }

        private void OpenFileDialog(object sender, RoutedEventArgs e)
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                DocumentToUploadPath.Text = _openFileDialog.FileName;
            }
        }
    }
}