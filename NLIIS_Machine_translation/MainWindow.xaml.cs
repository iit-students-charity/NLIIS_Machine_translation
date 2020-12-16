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
            MessageBox.Show(string.Empty, "Help");
        }
        
        private void Authors_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Group 721701:\nSemenikhin Nikita,\nStryzhych Angelika", "Authors");
        }

        private void TranslateDocument(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DocumentToUploadPath.Text))
            {
                SummaryLabel.Content = "Please, specify the filename";
            }
            
            var text = DocumentService.FromFile(DocumentToUploadPath.Text);
            //var translated = Translator.TranslateText(text);
            var translated = "alles gute".PadLeft(10000, '0');
            var saveFilename = $"{text.Substring(0, text.Length < 10 ? text.Length : 10)}__translated";
            
            var savePath = DocumentService.ToFile(translated, saveFilename);
            SummaryLabel.Content = $"Translation saved to {savePath}";

            TranslatedTextBox.Text = translated;
        }

        private void UploadTranslations(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DocumentToUploadPath.Text))
            {
                SummaryLabel.Content = "Please, specify the filename";
            }
            
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