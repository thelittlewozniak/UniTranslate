using QnASearch.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QnASearch.DAL
{
    class Context
    {
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
    }
}
