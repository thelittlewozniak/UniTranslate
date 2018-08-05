using System;
using System.Collections.Generic;

namespace APIUniTranslate.Models
{
    public partial class QuestionAnswer
    {
        public QuestionAnswer()
        {
            QuestionAnswerHasKeyword = new HashSet<QuestionAnswerHasKeyword>();
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public ICollection<QuestionAnswerHasKeyword> QuestionAnswerHasKeyword { get; set; }
    }
}
