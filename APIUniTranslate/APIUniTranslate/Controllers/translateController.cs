using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUniTranslate.Controllers
{
    [Produces("application/json")]
    [Route("/Translate")]
    public class TranslateController : Controller
    {
        [HttpGet]
        public Translate Detect(string q)
        {
            IGetAll detectGoogle = new GetAll();
            Detect data = new Detect();
            double temp = 0;
            DetectGoogle detect = detectGoogle.Detect(q);
            for (int i = 0; i < detect.data.detections.Count; i++)
            {
                for (int j = 0; j < detect.data.detections[i].Count; j++)
                {
                    if (temp < detect.data.detections[i][j].confidence)
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