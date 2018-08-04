using InterpreterSearch.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnASearch.POCO
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public List<QuestionAnswer_has_Keyword> Answers { get; set; }
    }
}
