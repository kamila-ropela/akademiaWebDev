using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using akademia_web_dev.Models;
using akademia_web_dev.Repositories;
using akademia_web_dev.Services;
using Microsoft.AspNetCore.Mvc;

namespace akademia_web_dev.Controllers
{
    public class HyperLinkController : Controller
    {

       // public static List<HyperLinkModel> _links = new List<HyperLinkModel>();
        private readonly ILinkRepository _repository;

        internal ILinkRepository Repository => _repository;

        [HttpGet]
        public IActionResult Index()
        {
            var links = _repository.Get(string.Empty, 0);
            return View(links);
        }

        [HttpPost]
        public IActionResult Create(HyperLinkModel link)
        {
            if (Regex.IsMatch(link.Link, @"[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)"))
            {
                
                _repository.Create(link);
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("Niepoprawny link");
        }
    }
}