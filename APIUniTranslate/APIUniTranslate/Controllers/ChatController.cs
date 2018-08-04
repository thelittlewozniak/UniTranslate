﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIUniTranslate.Google;
using InterpreterSearch;
using InterpreterSearch.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUniTranslate.Controllers
{
    [Produces("application/json")]
    [Route("api/Chat")]
    public class ChatController : Controller
    {
        public string Receive(string q, string lg)
        {
            IGetAll trad = new GetAll();
            q = trad.Translate(q, "en").data.translations[0].translatedText;
            //recherche dans la DB//
            string response="";
            //response = Data de la DB
            if(response.CompareTo("")==0)
            {
                IGetInterpreter interpreter = new DALInterpreters();
                var e = interpreter.GetInterpreters();
                response = trad.Translate("Sorry there's no response for your question, you can contact this interpreter:" + interpreter.GetInterpreter(lg).Email, lg).data.translations[0].translatedText;
            }
            return response;
        }
    }
}