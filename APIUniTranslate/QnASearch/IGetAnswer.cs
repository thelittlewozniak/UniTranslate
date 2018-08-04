using QnASearch.POCO;
using QnASearch.DAL;
using System;
using System.Collections.Generic;

namespace QnASearch
{
    public interface IGetAnswer
    {
        QuestionAnswer GetAnswer(string question);
        List<Keyword> GetKeywords(string question);
    }
}
