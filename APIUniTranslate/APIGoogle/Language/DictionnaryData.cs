using System;
using System.Collections.Generic;
using System.Text;

namespace APIGoogle.Language
{
    class DictionnaryData
    {
        public string EncodingType { get; set; }
        public DataDocument document { get; set; }
        public DictionnaryData(string encodingType,string q)
        {
            EncodingType = encodingType;
            document = new DataDocument("PLAIN_TEXT", q);
        }
    }
}
