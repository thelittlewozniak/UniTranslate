using InterpreterSearch.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnASearch.POCO
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public IEnumerable<QuestionAnswer_has_Keyword> KeyWord { get; set; }
    }
}
