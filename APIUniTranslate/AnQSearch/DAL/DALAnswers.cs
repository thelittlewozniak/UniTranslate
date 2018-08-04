using QnASearch.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QnASearch.DAL
{
    public class DALAnswers : IGetAnswer
    {
        Context db = new Context();

        public string GetAnswer(string question)
        {
            IGetAll = new GetAll();
            List<Keyword> DBkeywords = new List<Keyword>();
            List<Keyword> keywords = GetKeywords(question);  // LISTE DES KEYWORDS DE LA QUESTION QUE L'UTILISATEUR POSE

            // Liste complète des Keywords correspondants à tous les keywords de la question de l'utilisateur
            for(int i = 0;i<keywords.Count;i++)
                DBkeywords.Add(db.Keywords.Where(key => key.Text.CompareTo(keywords[i].Text) == 0 && key.Type.CompareTo(keywords[i].Type) == 0).FirstOrDefault());

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

            KeywordsID.ForEach(id =>
            {
                db.QuestionAnswers.ToList().ForEach(q =>
                {
                    cpt = q.KeyWords.Select(k => new AnswerByCount() { Answer = q.Answer, Count = q.KeyWords.Count(key => key.Id == id) }).ToList();
                });
            });

            return answer = cpt.Max().Answer;
        }
    }
}
