﻿using System;
using System.Collections.Generic;

namespace APIUniTranslate.Models
{
    public partial class Interpreter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Ethnic { get; set; }
        public string Clan { get; set; }
        public string Kind { get; set; }
        public string Language { get; set; }
    }
}
