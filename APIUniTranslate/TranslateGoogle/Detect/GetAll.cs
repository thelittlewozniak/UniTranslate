using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TranslateGoogle.Detect
{
    class GetAll
    {
        private static string key = "AIzaSyCleF3pJqifO6qgaSCOum6IDGrss0QL_8U";

        public DetectGoogle Detect(string q)
        {
            var url = "https://translation.googleapis.com/language/translate/v2/detect?key=" + key;
            var json = new WebClient().DownloadString(url);
            var detect = JsonConvert.DeserializeObject<DetectGoogle>(json);
            return detect;
        }
    }
}
