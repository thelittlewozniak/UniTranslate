using APIGoogle.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGoogle.Detect;
using APIGoogle.Language;

namespace APIUniTranslate.Google
{
    public interface IGetAll
    {
        DetectGoogle Detect(string q);
        TranslateGoogle Translate(string q, string target);
        Task<KeywordGoogle> GetKeywords(string q);
    }
}
