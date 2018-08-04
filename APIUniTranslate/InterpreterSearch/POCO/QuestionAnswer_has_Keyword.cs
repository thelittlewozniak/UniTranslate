using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterpreterSearch.POCO
{
    public class QuestionAnswer_has_Keyword
    {
        [Key]
        public int QuestionAnswer_Id { get; set; }
        public int Keyword_Id { get; set; }
    }
}
