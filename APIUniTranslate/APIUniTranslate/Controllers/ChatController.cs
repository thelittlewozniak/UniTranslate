using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIUniTranslate.Google;
using InterpreterSearch;
using InterpreterSearch.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QnASearch;
using QnASearch.DAL;

namespace APIUniTranslate.Controllers
{
    [Produces("application/json")]
    [Route("api/Chat")]
    public class ChatController : Controller
    {
        public async Task<string> ReceiveAsync(string q, string lg)
        {
            IGetAll trad = new GetAll();
            IGetAnswer answ = new DALAnswers();
            
            q = trad.Translate(q, "en").data.translations[0].translatedText;

            string rep = await answ.GetAnswerAsync(q);

            //recherche dans la DB//
            string response="";
            var r =await trad.GetKeywords(q);
            //response = Data de la DB
            if(response.CompareTo("")==0)
            {
                Console.WriteLine(e.Message);
            }
            return response;
        }
    }
}