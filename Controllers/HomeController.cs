using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector cnx;
        public HomeController()
        {
            cnx = new DbConnector();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        [Route("/addQuote")]
        public IActionResult AddQuote(string name, string quote) 
        {
            Console.WriteLine(name);
            Console.WriteLine(quote);
            string query = $"INSERT INTO quotes (name, quote) VALUES ('{name}', '{quote}')";
            cnx.Execute(query);
            return RedirectToAction("quotes");
        }
        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            string query = "SELECT * FROM quotes";
            var allQuotes = cnx.Query(query);
            ViewBag.allQuotes = allQuotes;
            return View("quotes");
        }


    }
}
