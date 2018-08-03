using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIUniTranslate.Data;
using APIUniTranslate.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TranslateGoogle;

namespace APIUniTranslate.Controllers
{
    [Produces("application/json")]
    [Route("/Detect")]
    public class DetectController : Controller
    {
        private static string key = "";
        [HttpGet]
        public Detect Detect(string q)
        {
            IGetAll detectGoogle = new GetAll();
            Detect data = new Detect();
            List<DetectGoogle> detect = detectGoogle.Detect(q);
            data.language = detect.FirstOrDefault().data.detections.FirstOrDefault().language;
            return data;
        }
    }
}