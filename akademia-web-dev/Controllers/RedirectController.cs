using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace akademia_web_dev.Controllers
{
    public class RedirectController : Controller
    {
        [HttpGet]
        [Route("/link/{hash}")]
        public IActionResult Index(string hash)
        {
            var url = HyperLinkController._links.First(l => l.Hash == hash).Link;
            return Redirect(url);
        }
    }
}