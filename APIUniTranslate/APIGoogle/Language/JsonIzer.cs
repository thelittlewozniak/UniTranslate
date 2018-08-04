using System;
using System.Collections.Generic;
using System.Text;

namespace APIGoogle.Language
{
    class JsonIzer
    {
        public static string Jsonizer(DictionnaryData d)
        {
            var Json = "{ 'encodingType':'" + d.EncodingType + "'," + "'document': { 'type':'" + d.document.type + "'," + "'content':'" + d.document.content + "'}}";
            return Json;
        }
    }
}
