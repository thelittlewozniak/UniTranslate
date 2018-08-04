using InterpreterSearch.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterSearch.DAL
{
    class Context:DbContext
    {
        public DbSet<Interpreter> Interpreter { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:unitranslate.database.windows.net,1433;Initial Catalog=Interpreters;Persist Security Info=False;User ID=thelittlewozniak;Password=azerty1234@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
