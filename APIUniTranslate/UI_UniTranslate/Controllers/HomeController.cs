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
        public IActionResult Index()
        {
            return RedirectToAction("IndexAsync");
        }

        public async Task<IActionResult> IndexAsync()
        {
            var requestCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            string cultureFull = requestCulture.RequestCulture.Culture.ToString();

            int hyphenIndex = cultureFull.IndexOf('-');
            string culture = cultureFull.Substring(0, hyphenIndex);

            string ph = "Say Hello in your language";

            ph = await TranslateAsync(ph, culture);

            ViewBag.lg = culture;
            ViewBag.Ph = ph;

            return View("Index");
        }
        public async Task<string> DetectAsync(string text, string lg)
        {
            Detect detect = null;
            string ph = "Say Hello in your language";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64203/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("Detect?q=" + text);
            if (response.IsSuccessStatusCode)
            {
                detect = await response.Content.ReadAsAsync<Detect>();
            }

            if(!detect.Language.Equals(lg))
                ph = await TranslateAsync(ph, detect.Language);

            return ph;
        }

        public async Task<string> ChatAsync(string text, string lang)
        {
            string answer = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64203/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Chat?q=" + text + "&lg=" + lang);
            if (response.IsSuccessStatusCode)
            {
                answer = await response.Content.ReadAsAsync<string>();
            }

            return answer;
        }

        public async Task<string> TranslateAsync(string text, string lang)
        {
            Translate answer = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64203/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("Translate?q=" + text + "&target=" + lang);
            if (response.IsSuccessStatusCode)
            {
                answer = await response.Content.ReadAsAsync<Translate>();
            }

            return answer.TranslatedText;
        }
    }
}
