using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE_Vocabs.Models
{
    public class Result
    {
        public int QuestionId { get; set; }
        public string CorrectAnswer { get; set; }
        public string Answered { get; set; }
        public bool result { get; set; }
    }
}
