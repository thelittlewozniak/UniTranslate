using APIGoogle.Translate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIGoogle.Detect;

namespace APIUniTranslate.Google
{
    public class GetAll:IGetAll
    {
        public static string key = "AIzaSyCleF3pJqifO6qgaSCOum6IDGrss0QL_8U";
        public DetectGoogle Detect(string q)
        {
            var url = "https://translation.googleapis.com/language/translate/v2/detect?key=" + key + "&q=" + q;
            var json = new WebClient().DownloadString(url);
            var data = JsonConvert.DeserializeObject<DetectGoogle>(json);
            return data;
        }
        public TranslateGoogle Translate(string q, string target)
        {
            var url = "https://translation.googleapis.com/language/translate/v2?key=" + key + "&q=" + q + "&target=" + target;
            var json = new WebClient().DownloadString(url);
            var data = JsonConvert.DeserializeObject<TranslateGoogle>(json);
            return data;
        }
    }
}
