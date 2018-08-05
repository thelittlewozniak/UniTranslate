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
            string rep = null;
            try
            {
                IGetAll trad = new GetAll();
                IGetAnswer answ = new DALAnswers();

                q = trad.Translate(q, "en").data.translations[0].translatedText;

                rep = await answ.GetAnswerAsync(q);

                //recherche dans la DB//

                //response = Data de la DB
                if (rep == null || rep.CompareTo("") == 0)
                {
                    IGetInterpreter interpreter = new DALInterpreters();
                    var e = interpreter.GetInterpreters();
                    rep = trad.Translate("Sorry there's no response for your question, you can contact this interpreter:" + interpreter.GetInterpreter(lg).Email, lg).data.translations[0].translatedText;
                }
                else
                {
                    rep = trad.Translate(rep, lg).data.translations[0].translatedText;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return rep;
        }
    }
}