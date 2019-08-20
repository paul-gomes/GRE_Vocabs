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
using GRE_Vocabs.Models;
using GRE_Vocabs.Database;

namespace GRE_Vocabs
{
    /// <summary>
    /// Interaction logic for QuestionBank.xaml
    /// </summary>
    public partial class QuestionBank : Window
    {
        private GREVocabsDatabase greDatabase = new GREVocabsDatabase();
        public QuestionBank()
        {
            InitializeComponent();
            BindQuestionGrid(questionListView);

            List<Words> allWords = greDatabase.GetAllWords();
            wordFilterView.ItemsSource = allWords;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(wordFilterView.ItemsSource);
            view.Filter = wordFilter;
        }

        //Words filter
        private bool wordFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Words).Word.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(wordFilterView.ItemsSource).Refresh();
        }


        //Populates Words grid
        public void BindQuestionGrid(ListView name)
        {
            List<QuestionsBank> quesBank = greDatabase.GetAllQuestions();
            name.ItemsSource = quesBank;
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            var quesId = questionId.Text;
            var ques = question.Text;
            var opt1 = option1.Text;
            var opt2 = option2.Text;
            var opt3 = option3.Text;
            var opt4 = option4.Text;
            var word = wordFilterView.SelectedItem;

            if (ques == "")
            {
                MessageBox.Show("Question textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (ques.Contains("'"))
            {
                MessageBox.Show("Question can not contain '. Please remove ' and resubmit.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (opt1 == "")
            {
                MessageBox.Show("Option1 textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (opt2 == "")
            {
                MessageBox.Show("option2 textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(opt3 == "")
            {
                MessageBox.Show("Option3 textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(opt4 == "")
            {
                MessageBox.Show("Option4 textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(word == null)
            {
                MessageBox.Show("Select correct answer on the left to link to this question in order to receive word stats.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var ans = answer.SelectedValue.ToString();
                if(ans == "Option1")
                {
                    ans = opt1;
                }
                else if(ans == "Option2")
                {
                    ans = opt2;
                }
                else if(ans == "Option3")
                {
                    ans = opt3;
                }
                else if(ans == "Option4")
                {
                    ans = opt4;
                }
                else
                {
                    MessageBox.Show("Select the correct answer for this question.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                if (MessageBox.Show("Have you selected the right answer for this question?", "GRE Vocabulary List", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (quesId == "")
                    {
                        QuestionsBank quesBank = new QuestionsBank();
                        quesBank.Question = ques;
                        quesBank.Option1 = opt1;
                        quesBank.Option2 = opt2;
                        quesBank.Option3 = opt3;
                        quesBank.Option4 = opt4;
                        quesBank.Answer = ans;
                        quesBank.NumberOfTimeAsked = 0;
                        quesBank.NumOfCorrectAns = 0;
                        quesBank.Accuracy = 0;
                        quesBank.WordId = ((Words)word).WordId;
                        greDatabase.SubmitQuestion(quesBank);
                        BindQuestionGrid(questionListView);
                        MessageBox.Show("Successfully added to the question bank!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                        question.Text = "";
                        option1.Text = "";
                        option2.Text = "";
                        option3.Text = "";
                        option4.Text = "";
                        answer.SelectedIndex = 0;
                        wordFilterView.SelectedItem = null;
                        txtFilter.Text = "";
                    }
                    else
                    {
                        QuestionsBank quesBank = greDatabase.GetQuestion(Convert.ToInt32(quesId));
                        quesBank.Question = ques;
                        quesBank.Option1 = opt1;
                        quesBank.Option2 = opt2;
                        quesBank.Option3 = opt3;
                        quesBank.Option4 = opt4;
                        quesBank.Answer = ans;
                        quesBank.WordId = ((Words)word).WordId;
                        greDatabase.UpdateQuestion(quesBank);
                        BindQuestionGrid(questionListView);
                        MessageBox.Show("Successfully updated to the question bank!", "QuestionBank", MessageBoxButton.OK, MessageBoxImage.Information);
                        question.Text = "";
                        option1.Text = "";
                        option2.Text = "";
                        option3.Text = "";
                        option4.Text = "";
                        answer.SelectedIndex = 0;
                        wordFilterView.SelectedItem = null;
                        txtFilter.Text = "";
                        questionTabView.SelectedIndex = 1;
                        addQuestion.Content = "Add To The Question Bank";
                        cancel.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                }
            }

        }

        //Deltes question from the db
        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the record?", "GRE Vocabulary List", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var item = (sender as Button).DataContext;
                QuestionsBank quesBank = (QuestionsBank)item;
                int quesId = quesBank.QuestionID;
                greDatabase.DeleteQuestion(quesId);
                BindQuestionGrid(questionListView);
                MessageBox.Show("Successfully deleted from the question bank!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //do yes stuff
            }




        }

        private void EditQuestion_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            QuestionsBank quesBank = (QuestionsBank)item;
            questionId.Text = quesBank.QuestionID.ToString();
            question.Text = quesBank.Question;
            option1.Text = quesBank.Option1;
            option2.Text = quesBank.Option2;
            option3.Text = quesBank.Option3;
            option4.Text = quesBank.Option4;
            if(quesBank.Option1 == quesBank.Answer)
            {
                answer.SelectedValue = "Option1";
            }
            else if (quesBank.Option2 == quesBank.Answer)
            {
                answer.SelectedValue = "Option2";
            }
            else if (quesBank.Option3 == quesBank.Answer)
            {
                answer.SelectedValue = "Option3";
            }
            else if (quesBank.Option4 == quesBank.Answer)
            {
                answer.SelectedValue = "Option4";
            }
            questionTabView.SelectedIndex = 0;
            Words word = greDatabase.GetWord(quesBank.WordId);
            wordFilterView.SelectedValue = word.Word;
            addQuestion.Content = "Update question";
            cancel.Visibility = Visibility.Visible;


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            question.Text = "";
            option1.Text = "";
            option2.Text = "";
            option3.Text = "";
            option4.Text = "";
            answer.SelectedIndex = 0;
            wordFilterView.SelectedItem = null;
            questionTabView.SelectedIndex = 1;
            addQuestion.Content = "Add To The Question Bank";
            cancel.Visibility = Visibility.Hidden;
        }
    }
}
