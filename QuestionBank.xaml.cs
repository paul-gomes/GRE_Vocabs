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

namespace GRE_Vocabs
{
    /// <summary>
    /// Interaction logic for QuestionBank.xaml
    /// </summary>
    public partial class QuestionBank : Window
    {
        public QuestionBank()
        {
            InitializeComponent();
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            var ques = question.Text;
            if(ques == "")
            {
                MessageBox.Show("Question textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            var opt1 = option1.Text;
            if(opt1 == "")
            {
                MessageBox.Show("Option1 textbox can not be empty.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            var opt2 = option2.Text;
            if(opt2 == "")
            {
                MessageBox.Show("option2 textbox can not be empty!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            var opt3 = option3.Text;
            if(opt2 == "")
            {
                MessageBox.Show("Option3 textbox can not be empty!.", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            var opt4 = option4.Text;
            if(opt4 == "")
            {
                MessageBox.Show("Option4 textbox can not be empty!", "GRE Vocabulary List", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            var ans = answer.SelectedItem.ToString();
           


        }
    }
}
