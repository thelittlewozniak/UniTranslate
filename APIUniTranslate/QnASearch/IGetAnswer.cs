using QnASearch.POCO;
using QnASearch.DAL;
using System;
using System.Collections.Generic;

namespace QnASearch
{
    public interface IGetAnswer
    {
        string GetAnswer(string question);
        List<Keyword> GetKeywords(string question);
    }
}
