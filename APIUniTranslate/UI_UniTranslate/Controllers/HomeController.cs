using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using UI_UniTranslate.Models;

namespace UI_UniTranslate.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            var requestCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            string cultureFull = requestCulture.RequestCulture.Culture.ToString();

            int hyphenIndex = cultureFull.IndexOf('-');
            string culture = cultureFull.Substring(0, hyphenIndex);

            // Return translated values

            return RedirectToAction("Test", new { lg = culture });
        }

        public IActionResult Test(string lg)
        {
            return View();
        }

        public async Task<string> DetectAsync(string text)
        {
            Detect detect = null;
            string ph = "Say Hello in your language";
            client.BaseAddress = new Uri("http://localhost:64203/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("Detect?q=" + text);
            if (response.IsSuccessStatusCode)
            {
                detect = await response.Content.ReadAsAsync<Detect>();
            }

            ph = await ChatAsync(ph, detect.Language);

            return ph;
        }

        public async Task<string>ChatAsync(string text, string lang)
        {
            string answer = null;

            HttpResponseMessage response = await client.GetAsync("api/Chat?q=" + text + "&lg=" + lang);
            if (response.IsSuccessStatusCode)
            {
                answer = await response.Content.ReadAsAsync<string>();
            }

            return answer;
        }
    }
}
