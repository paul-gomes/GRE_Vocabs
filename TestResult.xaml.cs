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

namespace GRE_Vocabs
{
    /// <summary>
    /// Interaction logic for TestResult.xaml
    /// </summary>
    public partial class TestResult : Window
    {
        public TestResult(List<Result> result)
        {
            InitializeComponent();
            resultView.ItemsSource = result;

            int totalPoints = 0;

            foreach(var res in result)
            {
                if (res.Correct)
                {
                    totalPoints++;
                }
            }
            totalScore.Text = String.Format("You scored {0} out of 10", totalPoints);
        }
    }
}
