using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE_Vocabs.Models
{
    class QuestionsBank
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
        public int? NumberOfTimeAsked { get; set; }
        public int? NumOfCorrectAns { get; set; }
        public decimal? Accuracy { get; set; }

    }
}
