using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TranslateGoogle;

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

    }
}
