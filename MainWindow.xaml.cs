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
        private List<VocabList> VList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeChromium();

            greDatabase.createDb();
            DataContext = this;
            VList = greDatabase.GetVocabList();
            vocabListComboBox.ItemsSource = VList;
            //BindVocabListComboBox(vocabListComboBox);
        }


        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://www.vocabulary.com/dictionary/affable");

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

        public void BindVocabListComboBox(ComboBox comboBoxName)
        {
            List<VocabList> vls =  greDatabase.GetVocabList();
            comboBoxName.ItemsSource = vls.ToList();
            comboBoxName.DisplayMemberPath = vls[0].VocabListName.ToString();
            comboBoxName.SelectedValuePath = vls[0].VocabListId.ToString();


        }



        private void vocabulary_click(object sender, RoutedEventArgs e)
        {
            
        }

    }

}
