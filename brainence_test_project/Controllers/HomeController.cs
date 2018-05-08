using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using brainence_test_project.Models;
using brainence_test_project.Models.Data;
using Microsoft.AspNetCore.Http;

namespace brainence_test_project.Controllers
{
    public class HomeController : Controller
    {
        private SentenceContext _context;

        public HomeController(SentenceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Sentences = GetSavedSentences();
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, string word)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var fileContent = reader.ReadToEnd();
                var sentences = fileContent.Split('.');
                foreach (var s in sentences)
                {
                    if (s.Contains(word))
                    {
                        var count = s.Split(' ').Count(x => x == word);

                        Sentence sentanceToAdd = new Sentence
                        {
                            Count = count,
                            SentenceInRevert = RevertHelper.Revert(s),
                            Word = word
                        };

                        _context.Add(sentanceToAdd);
                    }
                }

                _context.SaveChanges();
                ViewBag.Sentences = GetSavedSentences();
                return View();
            }
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private List<string> GetSavedSentences()
        {
            List<string> sentances = new List<string>();
            var sentencesInDb = _context.Sentences.Select(x => x.SentenceInRevert).ToList();
            foreach (var item in sentencesInDb)
            {
                sentances.Add(RevertHelper.Revert(item));
            }

            return sentances;
        }
    }
}