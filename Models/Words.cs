using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE_Vocabs.Models
{
    class Words
    {
        public int WordId { get; set; }
        public string Word { get; set; }
        public string WordStatus { get; set; }
        public int NumOfTimeTested { get; set; }
        public int? NumOfTimeAccurate { get; set; }
        public decimal? Accuracy { get; set; }
        public int VocabListId { get; set; }
        public virtual VocabList VocabList { get; set; }
    }
}
