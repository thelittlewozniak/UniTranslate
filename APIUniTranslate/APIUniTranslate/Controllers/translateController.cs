﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUniTranslate.Controllers
{
    [Produces("application/json")]
    [Route("/Translate")]
    public class TranslateController : Controller
    {
    }
}