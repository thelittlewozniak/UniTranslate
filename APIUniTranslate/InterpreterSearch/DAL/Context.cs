using InterpreterSearch.POCO;
using Microsoft.EntityFrameworkCore;
using QnASearch.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterpreterSearch.DAL
{
    public class Context : DbContext
    {
        public static Context instance;
        public DbSet<Interpreter> Interpreter { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<Keyword> Keyword { get; set; }
        public DbSet<QuestionAnswer_has_Keyword> QuestionAnswer_has_Keyword { get; set; }
        public static Context Instance()
        {
            if (instance == null)
            {
                instance = new Context();
            }
            return instance;
        }
        private Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:unitranslate.database.windows.net,1433;Initial Catalog=Interpreters;Persist Security Info=False;User ID=thelittlewozniak;Password=azerty1234@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
