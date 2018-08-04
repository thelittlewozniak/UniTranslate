using System;
using System.Collections.Generic;
using System.Text;

namespace APIGoogle.Language
{
    class DataDocument
    {
        public string type { get; set; }
        public string content { get; set; }
        public DataDocument(string type,string content)
        {
            this.type = type;
            this.content = content;
        }
    }
}
