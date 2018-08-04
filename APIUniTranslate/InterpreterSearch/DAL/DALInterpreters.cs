using InterpreterSearch.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterpreterSearch.DAL
{
    public class DALInterpreters:IGetInterpreter
    {
        Context db = new Context();
        public IEnumerable<Interpreter> GetInterpreters()
        {
            return db.Interpreters;
        }
        public Interpreter GetInterpreter(string language)
        {
            var interpreter = db.Interpreters.Where(i => i.language == language).FirstOrDefault();
            return interpreter;
        }
        public Interpreter GetInterpreter(string language,string kind)
        {
            var interpreter = db.Interpreters.Where(i => i.language == language && i.Kind==kind).FirstOrDefault();
            return interpreter;
        }
        public Interpreter GetInterpreter(string language, string kind, string clan)
        {
            var interpreter = db.Interpreters.Where(i => i.language == language && i.Kind==kind && i.Clan==clan).FirstOrDefault();
            return interpreter;
        }
    }
}
