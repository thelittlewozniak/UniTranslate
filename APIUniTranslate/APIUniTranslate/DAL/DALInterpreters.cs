using InterpreterSearch.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterpreterSearch.DAL
{
    public class DALInterpreters:IGetInterpreter
    {
        Context db = Context.Instance();
        public IEnumerable<Interpreter> GetInterpreters()
        {
            return db.Interpreter;
        }
        public Interpreter GetInterpreter(string language)
        {
            var interpreter = db.Interpreter.Where(i=>i.Language==language).FirstOrDefault();
            return interpreter;
        }
        public Interpreter GetInterpreter(string language,string kind)
        {
            var interpreter = db.Interpreter.Where(i => i.Language == language && i.Kind==kind).FirstOrDefault();
            return interpreter;
        }
        public Interpreter GetInterpreter(string language, string kind, string clan)
        {
            var interpreter = db.Interpreter.Where(i => i.Language == language && i.Kind==kind && i.Clan==clan).FirstOrDefault();
            return interpreter;
        }
    }
}
