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
using GRE_Vocabs.Database;
using GRE_Vocabs.Models;

namespace GRE_Vocabs
{
    /// <summary>
    /// Interaction logic for WordStats.xaml
    /// </summary>
    public partial class WordStats : Window
    {
        private GREVocabsDatabase greDatabase = new GREVocabsDatabase();
        private ListView wordListView = new ListView(); 

        public WordStats(ListView wordList)
        {
            InitializeComponent();
            List<Words> words = greDatabase.GetWordsByStatus("Learning", 1);
            wordStatsView.ItemsSource = words;

            List<VocabList> vls = greDatabase.GetVocabList();
            vocabListComboBox.ItemsSource = vls.ToList();

            wordListView = wordList;
        }

        private void ClassifyReview_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            Words word = (Words)item;
            int wordId = word.WordId;
            greDatabase.ClassifyWord(wordId, "Review");
            List<Words> words = greDatabase.GetWordsByStatus(word.WordStatus, Convert.ToInt32(word.VocabListId));
            wordStatsView.ItemsSource = words;
            wordListView.ItemsSource = words;
            

            
        }


        private void ClassifyFlagged_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            Words word = (Words)item;
            int wordId = word.WordId;
            greDatabase.ClassifyWord(wordId, "Flagged");
            List<Words> words = greDatabase.GetWordsByStatus(word.WordStatus, Convert.ToInt32(word.VocabListId));
            wordStatsView.ItemsSource = words;
            wordListView.ItemsSource = words;

        }

        private void ClassifyMastered_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            Words word = (Words)item;
            int wordId = word.WordId;
            greDatabase.ClassifyWord(wordId, "Mastered");
            List<Words> words = greDatabase.GetWordsByStatus(word.WordStatus, Convert.ToInt32(word.VocabListId));
            wordStatsView.ItemsSource = words;
            wordListView.ItemsSource = words;

        }

        private void ShowLearning_Click(object sender, RoutedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Learning", vocabListId);
            wordStatsView.ItemsSource = words;
            if (words.Count > 0)
            {
                wordStatsView.SelectedValue = words[0];
            }
            else
            {
                MessageBox.Show("No words found under this category!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void ShowReview_Click(object sender, RoutedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Review", vocabListId);
            wordStatsView.ItemsSource = words;
            if (words.Count > 0)
            {
                wordStatsView.SelectedValue = words[0];
            }
            else
            {
                MessageBox.Show("No words found under this category!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void ShowFlagged_Click(object sender, RoutedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Flagged", vocabListId);
            wordStatsView.ItemsSource = words;
            if (words.Count > 0)
            {
                wordStatsView.SelectedValue = words[0];
            }
            else
            {
                MessageBox.Show("No words found under this category!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void ShowMastered_Click(object sender, RoutedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Mastered", vocabListId);
            wordStatsView.ItemsSource = words;
            if (words.Count > 0)
            {
                wordStatsView.SelectedValue = words[0];
            }
            else
            {
                MessageBox.Show("No words found under this category!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        private void VocabListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int vocabListId = Convert.ToInt32(vocabListComboBox.SelectedValue);
            List<Words> words = greDatabase.GetWordsByStatus("Learning", vocabListId);
            wordStatsView.ItemsSource = words;

        }

    }

}
