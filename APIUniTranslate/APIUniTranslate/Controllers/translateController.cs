using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGoogle.Translate;
using APIUniTranslate.Data;
using APIUniTranslate.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIGoogle.Detect;

namespace APIUniTranslate.Controllers
{
    [Produces("application/json")]
    [Route("/Translate")]
    public class TranslateController : Controller
    {
        [HttpGet]
        public Data.Translate Detect(string q,string target)
        {
            IGetAll detectGoogle = new GetAll();
            Translate data = new Translate();
            TranslateGoogle detect = detectGoogle.Translate(q, target);
            data.TranslatedText = detect.data.translations[0].translatedText;
            data.TargetLanguage = target;
            return data;
        }

    }
}