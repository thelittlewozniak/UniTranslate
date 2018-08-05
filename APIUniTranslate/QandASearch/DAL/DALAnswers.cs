using APIUniTranslate.Google;
using QnASearch.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InterpreterSearch.DAL;
using InterpreterSearch;
using APIUniTranslate.Models;

namespace QnASearch.DAL
{
    public class DALAnswers : IGetAnswer
    {
        Context db = new Context();

        public async Task<string> GetAnswerAsync(string question)
        {
            IGetAll api = new GetAll();
            List<APIGoogle.Language.Keyword> r = await api.GetKeywords(question);
            List<Keyword> keywords = new List<Keyword>();  // LISTE DES KEYWORDS DE LA QUESTION QUE L'UTILISATEUR POSE
            for (int i=0;i<r.Count;i++)
            {
                keywords.Add(new Keyword { Text = r[i].Text, Type = r[i].Type });
            }
            List<Keyword> DBkeywords = new List<Keyword>();
            var l = db.Keyword.ToList();
            // Liste complète des Keywords correspondants à tous les keywords de la question de l'utilisateur
            for(int i = 0;i<keywords.Count;i++)
                DBkeywords.Add(db.Keyword.Where(key => key.Text.CompareTo(keywords[i].Text) == 0 && key.Type.CompareTo(keywords[i].Type) == 0).FirstOrDefault());

            // Tri en arbre par type de keyword
            List<Keyword> ADV = new List<Keyword>();
            List<Keyword> VERB = new List<Keyword>();
            List<Keyword> NOUN = new List<Keyword>();
            List<Keyword> X = new List<Keyword>();
            List<Keyword> keyword = new List<Keyword>();
            List<QuestionAnswer> f = new List<QuestionAnswer>();
            foreach (Keyword i in DBkeywords)
            {
                if(i?.Type=="ADV")
                {
                    ADV.Add(i);
                }
                if(i?.Type=="VERB")
                {
                    VERB.Add(i);
                }
                if(i?.Type=="NOUN")
                {
                    NOUN.Add(i);
                }
                if (i?.Type == "X")
                {
                    X.Add(i);
                }
            }
            foreach (Keyword adv in ADV)
            {
                keyword.Add(adv);
            }
            foreach (Keyword verb in VERB)
            {
                keyword.Add(verb);
            }
            foreach (Keyword noun in NOUN)
            {
                keyword.Add(noun);
            }
            foreach (Keyword x in X)
            {
                keyword.Add(x);
            }
            bool pass1 =false, pass2=false, pass3 = false, pass4 = false;
            foreach (Keyword e in keyword)
            {
                switch (e.Type)
                {
                    case "ADV":
                        if (pass1)
                        {
                            f = GetGoodAnswers(f, e);
                            DBkeywords.Remove(e);
                        }
                        if (pass1 == false)
                        {
                            f = GetAnswers(e);
                            pass1 = true;
                            DBkeywords.Remove(e);
                        }
                        break;
                    case "VERB":
                        if (pass2)
                        {
                            f = GetGoodAnswers(f, e);
                            DBkeywords.Remove(e);
                        }
                        if (pass2 == false)
                        {
                            f = GetAnswers(e);
                            DBkeywords.Remove(e);
                            pass2 = true;
                        }
                        break;
                    case "NOUN":
                        if (pass3)
                        {
                            f = GetGoodAnswers(f, e);
                            DBkeywords.Remove(e);
                            pass3 = true;
                        }
                        if (pass3 == false)
                        {
                            f = GetAnswers(e);
                            DBkeywords.Remove(e);
                            pass3 = true;
                        }
                        break;
                    case "X":
                        if (pass4)
                        {
                            f = GetGoodAnswers(f, e);
                            DBkeywords.Remove(e);
                            pass4 = true;
                        }
                        if (pass4 == false)
                        {
                            f = GetAnswers(e);
                            DBkeywords.Remove(e);
                            pass4 = true;
                        }
                        break;
                }
            }
            return f?.FirstOrDefault()?.Answer;
        }
        public List<QuestionAnswer> GetGoodAnswers(List<QuestionAnswer> questionAnswers,Keyword e)
        {
            Keyword k = GetKeyword(e);
            List<QuestionAnswer> good = new List<QuestionAnswer>();
            List<QuestionAnswerHasKeyword> l = db.QuestionAnswerHasKeyword.ToList();
            foreach (QuestionAnswer item in questionAnswers)
            {
                var m = l.Where(ee => ee.QuestionAnswerId == item.Id);
                foreach (var i in m)
                {
                    if(i.KeywordId==k.Id)
                    {
                        good.Add(item);
                    }
                }
            }
            return good;
        }
        public List<QuestionAnswer> GetAnswers(Keyword e)
        {
            List<QuestionAnswer> resp = new List<QuestionAnswer>();
            List<QuestionAnswerHasKeyword> l = db.QuestionAnswerHasKeyword.ToList();
            foreach (QuestionAnswer i in db.QuestionAnswer)
            {
                Keyword k = GetKeyword(e);
                var m = l.Where(ee => ee.QuestionAnswerId == i.Id);
                foreach (QuestionAnswerHasKeyword key in m)
                {
                    if (key.KeywordId == k.Id)
                    {
                        resp.Add(i);
                    }
                }
            }
            return resp;
        }

        public Keyword GetKeyword(Keyword e)
        {
            return db.Keyword.Where(i => i.Text == e.Text && i.Type == e.Type).FirstOrDefault();
        }
    }
}
