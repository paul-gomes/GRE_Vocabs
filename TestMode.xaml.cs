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
using System.Windows.Threading;
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

            List<QuestionsBank> questions = new List<QuestionsBank>();
            questions = questionsForTest();
            if(questions.Count == 10)
            {
                int iteration = 1;
                foreach (var ques in questions)
                {
                    TextBlock textblockNum = (TextBlock)FindName("questionNum" + iteration.ToString());
                    textblockNum.Text = String.Format("{0}. ", iteration);

                    TextBlock textblock = (TextBlock)FindName("question" + iteration.ToString());
                    textblock.Text = String.Format("{0}", ques.Question);

                    TextBlock textblockId = (TextBlock)FindName(String.Format("question{0}Id", iteration.ToString()));
                    textblockId.Text = ques.QuestionID.ToString();

                    //List of all the options for that question
                    List<string> options = new List<string>();
                    options.Add(ques.Option1);
                    options.Add(ques.Option2);
                    options.Add(ques.Option3);
                    options.Add(ques.Option4);

                    ComboBox comboBox = (ComboBox)FindName("answer" + iteration.ToString());
                    comboBox.ItemsSource = options;

                    iteration += 1;

                }

            }
            Countdown(360, TimeSpan.FromSeconds(1), cur => time.Content = string.Format("Time Remaining: {0}:{1:00}", cur / 60, cur % 60));

        }
        private void Countdown(int count, TimeSpan interval, Action<int> ts)
        {
            var dt = new System.Windows.Threading.DispatcherTimer();
            dt.Interval = interval;
            dt.Tick += (_, a) =>
            {
                if (count-- == 0)
                {
                    dt.Stop();
                    foreach (var Window in App.Current.Windows)
                    {
                        if (Window.ToString() == "GRE_Vocabs.TestMode")
                        {
                            List<Result> result = getResult();
                            TestResult trWindow = new TestResult(result);
                            trWindow.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    ts(count);
                }     
            };
            ts(count);
            dt.Start();
        }

        private List<QuestionsBank> questionsForTest()
        {
            List<QuestionsBank> ques = new List<QuestionsBank>();
            List<QuestionsBank> quesionsForTest = new List<QuestionsBank>();
            ques = greDatabase.GetAllQuestions();

            if(ques.Count >= 50)
            {
                List<int> alredayUsedRandNum = new List<int>();
                while (quesionsForTest.Count < 10)
                {
                    //Creating a random number
                    Random random = new Random();
                    int randNum = random.Next(0, ques.Count);
                    if (!alredayUsedRandNum.Contains(randNum))
                    {
                        alredayUsedRandNum.Add(randNum);
                        if (ques[randNum].NumberOfTimeAsked <= 50 || ques[randNum].Accuracy <= 80)
                        {
                            quesionsForTest.Add(ques[randNum]);
                        }

                    }

                }
            }
            return quesionsForTest;
        }

        private List<Result> getResult()
        {

            List<Result> result = new List<Result>();
            for (int i=1; i <=10; i++)
            {
                TextBlock textblockId = (TextBlock)FindName(String.Format("question{0}Id", i.ToString()));
                int quesId = Convert.ToInt32(textblockId.Text);

                ComboBox comboBox = (ComboBox)FindName("answer" + i.ToString());
                var answer = (comboBox.SelectedValue == null) ? "" : comboBox.SelectedValue.ToString();

                QuestionsBank question = greDatabase.GetQuestion(quesId);
                question.NumberOfTimeAsked += 1;

                Words word = greDatabase.GetWord(question.WordId.Value);
                if(word != null)
                {
                    word.NumOfTimeTested += 1;
                }

                Result res = new Result();

                if (answer == question.Answer)
                {
                    if (word != null)
                    {
                        word.NumOfTimeAccurate += 1;
                        word.Accuracy = Math.Round((Convert.ToDecimal((double)word.NumOfTimeAccurate / (double)word.NumOfTimeTested) * 100), 2);
                    }
                    question.NumOfCorrectAns += 1;
                    question.Accuracy = Math.Round((Convert.ToDecimal((double)question.NumOfCorrectAns / (double)question.NumberOfTimeAsked) * 100), 2);
                    res.QuestionId = quesId;
                    res.Question = question.Question;
                    res.CorrectAnswer = question.Answer;
                    res.Answered = answer;
                    res.Correct = true;

                }
                else
                {
                    if (word != null)
                    {
                        word.Accuracy = Math.Round((Convert.ToDecimal((double)word.NumOfTimeAccurate / (double)word.NumOfTimeTested) * 100), 2);
                    }
                    question.Accuracy = Math.Round((Convert.ToDecimal((double)question.NumOfCorrectAns / (double)question.NumberOfTimeAsked) * 100), 2);
                    res.QuestionId = quesId;
                    res.Question = question.Question;
                    res.CorrectAnswer = question.Answer;
                    res.Answered = answer;
                    res.Correct = false;
                }
                result.Add(res);
                greDatabase.UpdateQuestion(question);
                greDatabase.UpdateWord(word);


            }
            return result;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<Result> result = getResult();
            TestResult trWindow = new TestResult(result);
            trWindow.Show();
            this.Close();
        }
    }
}
