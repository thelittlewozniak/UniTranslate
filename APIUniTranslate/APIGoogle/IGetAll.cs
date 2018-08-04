using APIGoogle.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGoogle.Detect;

namespace APIUniTranslate.Google
{
    public interface IGetAll
    {
        DetectGoogle Detect(string q);
        TranslateGoogle Translate(string q, string target);
    }
}
