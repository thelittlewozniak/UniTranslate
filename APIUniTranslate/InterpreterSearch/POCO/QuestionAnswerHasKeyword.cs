using System;
using System.Collections.Generic;

namespace APIUniTranslate.Models
{
    public partial class QuestionAnswerHasKeyword
    {
        public int QuestionAnswerId { get; set; }
        public int KeywordId { get; set; }

        public QuestionAnswer QuestionAnswer { get; set; }
    }
}
