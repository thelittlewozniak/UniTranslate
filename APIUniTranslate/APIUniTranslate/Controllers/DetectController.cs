using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIGoogle.Detect;
using APIUniTranslate.Data;
using APIUniTranslate.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIUniTranslate.Controllers
{
    [Produces("application/json")]
    [Route("/Detect")]
    public class DetectController : Controller
    {
        [HttpGet]
        public Detect Detect(string q)
        {
            IGetAll detectGoogle = new GetAll();
            Detect data= new Detect();
            double temp = 0;
            DetectGoogle detect = detectGoogle.Detect(q);
            for(int i=0;i<detect.data.detections.Count;i++)
            {
                for(int j=0;j<detect.data.detections[i].Count;j++)
                {
                    if (temp <= detect.data.detections[i][j].confidence)
                    {
                        temp = detect.data.detections[i][j].confidence;
                        data.language = detect.data.detections[i][j].language;
                    }
                }
            }
            return data;
        }
    }
}