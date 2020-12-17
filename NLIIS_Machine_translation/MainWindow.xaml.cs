using System;
using System.Windows;
using System.Windows.Media.Imaging;
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
            Sentences.SelectionChanged += BuildSyntaxTree;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Empty, "Help");
        }
        
        private void Authors_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Group 721701:\nSemenikhin Nikita,\nStryzhych Angelika", "Authors");
        }

        private void ProcessDocument(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DocumentToUploadPath.Text))
            {
                SummaryLabel.Content = "Please, specify the filename";

                return;
            }
            
            var text = DocumentService.FromFile(DocumentToUploadPath.Text);
            //var translated = Translator.TranslateText(text);
            var translated = "alles gute".PadLeft(10000, '0');
            
            var saveFilename = $"{text.Substring(0, text.Length < 10 ? text.Length : 10)}__translated";
            var savePath = DocumentService.ToFile(translated, saveFilename);
            SummaryLabel.Content = $"Translation saved to {savePath}";

            TranslatedTextBox.Text = translated;

            Sentences.ItemsSource = DocumentService.GetSentences(text);
        }

        private void UploadTranslations(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DocumentToUploadPath.Text))
            {
                SummaryLabel.Content = "Please, specify the filename";
                
                return;
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

        private void BuildSyntaxTree(object sender, RoutedEventArgs e)
        {
            var buildFrom = (string) Sentences.SelectedItem;
            
            if (string.IsNullOrEmpty(buildFrom))
            {
                return;
            }
            
            SyntaxTreeBuilder.BuildTree(buildFrom);
            
            var bitmap = new BitmapImage();

            try
            {
                TreeImage.Source = null;
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"D:\tree.jpg");
                bitmap.EndInit();
                
                TreeImage.Source = bitmap;
            }
            catch (Exception ex)
            {
                SummaryLabel.Content = $"Something wrong with the image: {ex.Message}";
            }
        }
    }
}
