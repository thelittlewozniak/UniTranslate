using APIUniTranslate.Models;
using InterpreterSearch.DAL;
using System;
using System.Collections.Generic;

namespace InterpreterSearch
{
    public interface IGetInterpreter
    {
        IEnumerable<Interpreter> GetInterpreters();
        Interpreter GetInterpreter(string language);
        Interpreter GetInterpreter(string language, string kind);
        Interpreter GetInterpreter(string language, string kind, string clan);
    }
}
