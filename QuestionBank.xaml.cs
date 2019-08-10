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
        }

        //Populates Words grid
        public void BindQuestionGrid(ListView name)
        {
            List<QuestionsBank> quesBank = greDatabase.GetQuestions();
            name.ItemsSource = quesBank;
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            var ques = question.Text;
            var opt1 = option1.Text;
            var opt2 = option2.Text;
            var opt3 = option3.Text;
            var opt4 = option4.Text;

            if (ques == "")
            {
                MessageBox.Show("Question textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (opt1 == "")
            {
                MessageBox.Show("Option1 textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (opt2 == "")
            {
                MessageBox.Show("option2 textbox can not be empty!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(opt2 == "")
            {
                MessageBox.Show("Option3 textbox can not be empty!.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(opt4 == "")
            {
                MessageBox.Show("Option4 textbox can not be empty!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    MessageBox.Show("Select the correct answer for this question!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                QuestionsBank quesBank = new QuestionsBank();
                quesBank.Question = ques;
                quesBank.Option1 = opt1;
                quesBank.Option2 = opt2;
                quesBank.Option3 = opt3;
                quesBank.Option4 = opt4;
                quesBank.Answer = ans;
                greDatabase.submitQuestion(quesBank);
                BindQuestionGrid(questionListView);
                MessageBox.Show("Successfully added to the question bank!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
                question.Text = "";
                option1.Text = "";
                option2.Text = "";
                option3.Text = "";
                option4.Text = "";


            }

        }
    }
}
