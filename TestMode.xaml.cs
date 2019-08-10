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
    /// Interaction logic for TestMode.xaml
    /// </summary>
    public partial class TestMode : Window
    {
        private GREVocabsDatabase greDatabase = new GREVocabsDatabase();

        public TestMode()
        {
            InitializeComponent();

            List<QuestionsBank> quesions = new List<QuestionsBank>();
            quesions = greDatabase.GetQuestions();
            int count = 1;
            foreach(var ques in quesions)
            {
                TextBlock textblock = (TextBlock) FindName("question" + count.ToString());
                textblock.Text = String.Format("{0}. {1}", count, ques.Question);
                
                //List of all the options for that question
                List<string> options = new List<string>();
                options.Add(ques.Option1);
                options.Add(ques.Option2);
                options.Add(ques.Option3);
                options.Add(ques.Option4);

                ComboBox comboBox = (ComboBox)FindName("answer" + count.ToString());
                comboBox.ItemsSource = options;

                count += 1;

            }
        } 
    }
}
