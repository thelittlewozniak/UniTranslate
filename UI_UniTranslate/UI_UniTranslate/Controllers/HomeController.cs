using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace UI_UniTranslate.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    var requestCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>();
        //    //return requestCulture.RequestCulture.Culture.ToString();
        //    return View();
        //}

        public string Index()
        {
            var requestCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            return requestCulture.RequestCulture.Culture.ToString();
            //return View();
        }
    }
}
