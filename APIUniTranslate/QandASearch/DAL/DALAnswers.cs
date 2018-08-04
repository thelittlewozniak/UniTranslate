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
namespace QnASearch.DAL
{
    public class DALAnswers : IGetAnswer
    {
        Context db = Context.Instance();

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
            DBkeywords = DBkeywords.Where(key => key.Type.CompareTo("ADV") == 0).ToList();
            DBkeywords = DBkeywords.Where(key => key.Type.CompareTo("VERB") == 0).ToList();
            DBkeywords = DBkeywords.Where(key => key.Type.CompareTo("NOUN") == 0).ToList();

            // Liste des ID des keyword filtrés
            List<int> KeywordsID = new List<int>();
            foreach(Keyword key in DBkeywords)
                KeywordsID.Add(key.Id);

            // Liste des 
            List<AnswerByCount> cpt = new List<AnswerByCount>();

            string answer = null;

            //KeywordsID.ForEach(id =>
            //{
            //    db.QuestionAnswer.ToList().ForEach(q =>
            //    {
            //        cpt = q.KeyWord.Select(k => new AnswerByCount() { Answer = q.Answer, Count = q.KeyWord.Count(key => key.Id == id) }).ToList();
            //    });
            //});

            return answer = cpt.Max().Answer;
        }
    }
}
