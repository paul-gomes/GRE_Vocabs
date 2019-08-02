using System;
using System.Windows;
using CefSharp;
using CefSharp.Wpf;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GRE_Vocabs.Database;
using GRE_Vocabs.Models;


namespace GRE_Vocabs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChromiumWebBrowser chromeBrowser;
        private GREVocabsDatabase greDatabase = new GREVocabsDatabase();

        public MainWindow()
        {
            InitializeComponent();
            greDatabase.createDb();

            // Initialize cef with the provided settings
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            LoadVocabularyPage((greDatabase.GetWords("Learning"))[0].Word);

            //Binds GRE vocab collection list comboBox
            BindVocabListComboBox(vocabListComboBox);

            //Binds wordListView
            BindWordGrid(wordListView);
        }


        public void LoadVocabularyPage(string word)
        {

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(String.Format("https://www.vocabulary.com/dictionary/{0}", word.ToLower() ));

            chromeBrowser.FrameLoadEnd += (sender, args) =>
            {
                //Wait for the MainFrame to finish loading
                if (args.Frame.IsMain)
                {
                    args.Frame.ExecuteJavaScriptAsync("var item = document.getElementById('dictionary-upper-ad-right'); item.parentNode.removeChild(item);" +
                                                      "document.querySelector('#dictionary-lower-ad').style.display = 'none';" +
                                                      "document.querySelector('.leaderboard-ad').style.display = 'none';" +
                                                      "document.querySelector('.page-header').style.display = 'none';" +
                                                      "document.querySelector('.fixed-tray').style.display = 'none';" +
                                                      "document.querySelector('#dictionaryNav').style.display = 'none'; " +
                                                      "document.querySelector('.signup-tout').style.display = 'none'; " +
                                                      "document.querySelector('.page-footer').style.display = 'none'");
                }
            };

            // Add it to the form and fill it to the form window.
            vocabView.Children.Add(chromeBrowser);

        }


        //Populates the GRE Vocabulary collection list comboBox
        public void BindVocabListComboBox(ComboBox comboBoxName)
        {
            List<VocabList> vls =  greDatabase.GetVocabList();
            comboBoxName.ItemsSource = vls.ToList();
        }

        //Populates Words grid
        public void BindWordGrid(ListView name)
        {
            List<Words> words = greDatabase.GetWords("Learning");
            name.ItemsSource = words;
        }

        //Loads the vocabulary page for selected word
        private void WordListView_click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            Words word = (Words)item;
            if (item != null)
            {
                LoadVocabularyPage(word.Word);
            }

        }


        private void vocabulary_click(object sender, RoutedEventArgs e)
        {
            
        }

        private void QuestionBank_Click(object sender, RoutedEventArgs e)
        {
            QuestionBank qbWindow = new QuestionBank();
            qbWindow.Show();
        }


    }

}
