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
            //greDatabase.createDb();

            // Initialize cef with the provided settings
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            LoadVocabularyPage((greDatabase.GetWordsByStatus("Learning", 1))[0].Word);

            //Binds GRE vocab collection list comboBox
            BindVocabListComboBox(vocabListComboBox);

            //Binds wordListView
            BindWordGrid(wordListView);
        }


        public void LoadVocabularyPage(string word)
        {

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(String.Format("https://www.vocabulary.com/dictionary/{0}", word.ToLower()));

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
            List<VocabList> vls = greDatabase.GetVocabList();
            comboBoxName.ItemsSource = vls.ToList();
        }

        //Populates Words grid
        public void BindWordGrid(ListView name)
        {
            List<Words> words = greDatabase.GetWordsByStatus("Learning", 1);
            name.ItemsSource = words;
            name.SelectedValue = words[0];
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


        private void ClassifyReview_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            Words word = (Words)item;
            int wordId = word.WordId;
            greDatabase.ClassifyWord(wordId, "Review");
            List<Words> words = greDatabase.GetWordsByStatus(word.WordStatus, Convert.ToInt32(word.VocabListId));
            wordListView.ItemsSource = words;
            if (words.Count > 0)
            {
                wordListView.SelectedValue = words[0];
                LoadVocabularyPage(words[0].Word);

            }
            else
            {
                vocabView.Children.Clear();
            }


        }


        private void ClassifyFlagged_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            Words word = (Words)item;
            int wordId = word.WordId;
            greDatabase.ClassifyWord(wordId, "Flagged");
            List<Words> words = greDatabase.GetWordsByStatus(word.WordStatus, Convert.ToInt32(word.VocabListId));
            wordListView.ItemsSource = words;
            if (words.Count > 0)
            {
                wordListView.SelectedValue = words[0];
                LoadVocabularyPage(words[0].Word);

            }
            else
            {
                vocabView.Children.Clear();
            }


        }

        private void ClassifyMastered_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            Words word = (Words)item;
            int wordId = word.WordId;
            greDatabase.ClassifyWord(wordId, "Mastered");
            List<Words> words = greDatabase.GetWordsByStatus(word.WordStatus, Convert.ToInt32(word.VocabListId));
            wordListView.ItemsSource = words;
            if (words.Count > 0)
            {
                wordListView.SelectedValue = words[0];
                LoadVocabularyPage(words[0].Word);

            }
            else
            {
                vocabView.Children.Clear();
            }

        }

        private void ShowLearning_Click(object sender, RoutedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Learning", vocabListId);
            wordListView.ItemsSource = words;
            selectedCategory.Text = "Learning";
            if (words.Count > 0)
            {
                wordListView.SelectedValue = words[0];
                LoadVocabularyPage(words[0].Word);
            }
            else
            {
                MessageBox.Show("No words found under this category!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                vocabView.Children.Clear();

            }

        }

        private void ShowReview_Click(object sender, RoutedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Review", vocabListId);
            wordListView.ItemsSource = words;
            selectedCategory.Text = "Needs Reviewing";
            if (words.Count > 0)
            {
                wordListView.SelectedValue = words[0];
                LoadVocabularyPage(words[0].Word);
            }
            else
            {
                MessageBox.Show("No words found under this category!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                vocabView.Children.Clear();

            }

        }

        private void ShowFlagged_Click(object sender, RoutedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Flagged", vocabListId);
            wordListView.ItemsSource = words;
            selectedCategory.Text = "Flagged";
            if (words.Count > 0)
            {
                wordListView.SelectedValue = words[0];
                LoadVocabularyPage(words[0].Word);
            }
            else
            {
                MessageBox.Show("No words found under this category!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                vocabView.Children.Clear();

            }

        }

        private void ShowMastered_Click(object sender, RoutedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Mastered", vocabListId);
            wordListView.ItemsSource = words;
            selectedCategory.Text = "Mastered";
            if (words.Count > 0)
            {
                wordListView.SelectedValue = words[0];
                LoadVocabularyPage(words[0].Word);
            }
            else
            {
                MessageBox.Show("No words found under this category!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                vocabView.Children.Clear();

            }

        }

        private void VocabListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Learning", vocabListId);
            wordListView.ItemsSource = words;
            selectedCategory.Text = "Learning";
            if (words.Count > 0)
            {
                wordListView.SelectedValue = words[0];
                LoadVocabularyPage(words[0].Word);
            }
            else
            {
                vocabView.Children.Clear();
            }

        }

        private void Bengali_Click(object sender1, RoutedEventArgs e)
        {
            Words word = (Words) wordListView.SelectedValue;
            if (word != null)
            {
                // Create a browser component
                chromeBrowser = new ChromiumWebBrowser(String.Format("https://translate.google.com/?hl=en&tab=wT1#view=home&op=translate&sl=en&tl=bn&text={0}", word.Word.ToLower()));

                chromeBrowser.FrameLoadEnd += (sender, args) =>
                {
                //Wait for the MainFrame to finish loading
                if (args.Frame.IsMain)
                    {
                        args.Frame.ExecuteJavaScriptAsync("var item = document.querySelector('.input-button-container').style.display = 'none';" +
                                                          "document.querySelector('.gb_Pd').style.display = 'none'");
                    }
                };

                // Add it to the form and fill it to the form window.
                vocabView.Children.Add(chromeBrowser);
            }
            else
            {
                MessageBox.Show("Please select a word.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Vocabulary_Click(object sender1, RoutedEventArgs e)
        {
            Words word = (Words)wordListView.SelectedValue;
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(String.Format("https://www.vocabulary.com/dictionary/{0}", word.Word.ToLower()));

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


        private void QuestionBank_Click(object sender, RoutedEventArgs e)
        {
            QuestionBank qbWindow = new QuestionBank();
            qbWindow.Show();
        }

        private void TestMode_Click(object sender, RoutedEventArgs e)
        {
            List<QuestionsBank> questions = greDatabase.GetAllQuestions();
            if(questions.Count >= 50)
            {
                TestMode tmWindow = new TestMode();
                tmWindow.Show();

            }
            else
            {
                var left = 50 - questions.Count;
                MessageBox.Show(String.Format("You need at least 50 questions ({0} more questions) in the question bank.",left ), "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void WordStats_Click(object sender, RoutedEventArgs e)
        {
            WordStats wsWindow = new WordStats(this.wordListView);
            wsWindow.Show();
        }
    }

}
