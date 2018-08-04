using QnASearch.POCO;
using QnASearch.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QnASearch
{
    public interface IGetAnswer
    {
        Task<string> GetAnswerAsync(string question);
    }
}
