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
using System.ComponentModel;

namespace GRE_Vocabs
{
    /// <summary>
    /// Interaction logic for QuestionBank.xaml
    /// </summary>
    public partial class QuestionBank : Window
    {
        private GREVocabsDatabase greDatabase = new GREVocabsDatabase();
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;


        public QuestionBank()
        {
            InitializeComponent();

            Words word = (Words)((MainWindow)Application.Current.MainWindow).wordListView.SelectedValue;
            if (word != null)
            {
                wordIdTextBox.Text = word.WordId.ToString();
                wordTextBox.Text = word.Word;
                quesBelong.IsChecked = false;
            }
            else
            {
                wordIdTextBox.Text = "";
                wordTextBox.Text = "";
                quesBelong.IsChecked = true;
            }
        }

        void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(questionListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }


        private void QuestionTabView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (qListTabItem != null && qListTabItem.IsSelected)
                {
                    List<QuestionsBank> quesBank = greDatabase.GetAllQuestions();
                    questionListView.ItemsSource = quesBank;
                }
            }

        }
        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            var quesId = questionId.Text;
            var ques = question.Text;
            var opt1 = option1.Text;
            var opt2 = option2.Text;
            var opt3 = option3.Text;
            var opt4 = option4.Text;

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
                        if(quesBelong.IsChecked == false)
                        {
                            quesBank.WordId = Convert.ToInt32(wordIdTextBox.Text);
                        }
                        else
                        {
                            Words word = (Words)((MainWindow)Application.Current.MainWindow).wordListView.SelectedValue;
                            wordIdTextBox.Text = word.WordId.ToString();
                            wordTextBox.Text = word.Word;
                        }
                        greDatabase.SubmitQuestion(quesBank);
                        MessageBox.Show("Successfully added to the question bank!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                        questionId.Text = "";
                        question.Text = "";
                        option1.Text = "";
                        option2.Text = "";
                        option3.Text = "";
                        option4.Text = "";
                        answer.SelectedIndex = 0;
                        quesBelong.IsChecked = false;
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
                        if (quesBelong.IsChecked == false)
                        {
                            quesBank.WordId = Convert.ToInt32(wordIdTextBox.Text);
                        }
                        else
                        {
                            Words word = (Words)((MainWindow)Application.Current.MainWindow).wordListView.SelectedValue;
                            wordIdTextBox.Text = word.WordId.ToString();
                            wordTextBox.Text = word.Word;
                        }
                        greDatabase.UpdateQuestion(quesBank);
                        MessageBox.Show("Successfully updated to the question bank!", "QuestionBank", MessageBoxButton.OK, MessageBoxImage.Information);
                        questionId.Text = "";
                        question.Text = "";
                        option1.Text = "";
                        option2.Text = "";
                        option3.Text = "";
                        option4.Text = "";
                        answer.SelectedIndex = 0;
                        quesBelong.IsChecked = false;
                        questionTabView.SelectedIndex = 1;
                        addQuestion.Content = "Add To The Question Bank";
                        cancel.Visibility = Visibility.Hidden;
                    }
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
                List<QuestionsBank> ques = greDatabase.GetAllQuestions();
                questionListView.ItemsSource = ques;
                MessageBox.Show("Successfully deleted from the question bank!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
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
            if (quesBank.Option1 == quesBank.Answer)
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
            if (quesBank.WordId.HasValue && quesBank.WordId != 0)
            {
                Words word = greDatabase.GetWord(quesBank.WordId.Value);
                wordIdTextBox.Text = word.WordId.ToString();
                wordTextBox.Text = word.Word;
                quesBelong.IsChecked = false;
            }
            else
            {
                wordTextBox.Text = "";
                wordIdTextBox.Text = "";
                quesBelong.IsChecked = true;
            }

            addQuestion.Content = "Update question";
            cancel.Visibility = Visibility.Visible;


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            questionId.Text = "";
            question.Text = "";
            option1.Text = "";
            option2.Text = "";
            option3.Text = "";
            option4.Text = "";
            answer.SelectedIndex = 0;
            quesBelong.IsChecked = true;
            questionTabView.SelectedIndex = 1;
            addQuestion.Content = "Add To The Question Bank";
            cancel.Visibility = Visibility.Hidden;
            Words word = (Words)((MainWindow)Application.Current.MainWindow).wordListView.SelectedValue;
            if(word != null)
            {
                wordIdTextBox.Text = word.WordId.ToString();
                wordTextBox.Text = word.Word;
                quesBelong.IsChecked = false;
            }
            else
            {
                wordTextBox.Text = "";
                wordIdTextBox.Text = "";
                quesBelong.IsChecked = true;
            }

        }

        private void QuesBelong_Click(object sender, RoutedEventArgs e)
        {

            if (quesBelong.IsChecked == true)
            {
                wordTextBox.Text = "";
                wordIdTextBox.Text = "";
            }
            else
            {
                Words word = (Words)((MainWindow)Application.Current.MainWindow).wordListView.SelectedValue;
                if (word != null)
                {
                    wordIdTextBox.Text = word.WordId.ToString();
                    wordTextBox.Text = word.Word;
                }

            }
        }


    }
}
