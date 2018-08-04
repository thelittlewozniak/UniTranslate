using APIGoogle.Translate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIGoogle.Detect;
using System.Net.Http;
using APIGoogle.Language;
using System.Text;

namespace APIUniTranslate.Google
{
    public class GetAll:IGetAll
    {
        private static readonly HttpClient client = new HttpClient();
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
        public async Task<List<Keyword>> GetKeywords(string q)
        {
            DictionnaryData data = new DictionnaryData("UTF8", q);
            JsonSerializer serializer = new JsonSerializer();
            string json = JsonIzer.Jsonizer(data);
            var response = await client.PostAsync("https://language.googleapis.com/v1/documents:analyzeSyntax?key=AIzaSyBy_fZcr1Pgy74vdHCWJwhrwZpW8LoDp08", new StringContent(json, Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            var d = JsonConvert.DeserializeObject<KeywordGoogle>(responseString);
            var keywords = new List<Keyword>();
            for(int i=0;i<d.tokens.Count;i++)
            {
                keywords.Add(new Keyword { Text = d.tokens[i].text.content,Type = d.tokens[i].partOfSpeech.tag });
            }
            return keywords;
        }
    }
}
