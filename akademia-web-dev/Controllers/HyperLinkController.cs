using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using akademia_web_dev.Models;
using akademia_web_dev.Services;
using Microsoft.AspNetCore.Mvc;

namespace akademia_web_dev.Controllers
{
    public class HyperLinkController : Controller
    {

        public static List<HyperLinkModel> _links = new List<HyperLinkModel>();

        public IActionResult Index()
        {
            return View(_links);
        }

        [HttpPost]
        public IActionResult Create(string link)
        {
            if (Regex.IsMatch(link, @"[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)"))
            {
                var hash = new HashService().GenerateHash(_links.Count);
                _links.Add(new HyperLinkModel() { Id = _links.Count, Link = link, Hash = hash });
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("Niepoprawny link");
        }
    }
}