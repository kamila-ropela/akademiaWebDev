using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akademia_web_dev.DB;
using akademia_web_dev.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace akademia_web_dev.Controllers
{
    public class RedirectController : Controller
    {
        private ILinkRepository _repository;
        private readonly LinkDBContext _context;


        [HttpGet]
        [Route("/link/{hash}")]
        public IActionResult Index(string hash)
        {
            var url = _context.link.Where(item => item.Hash == hash).FirstOrDefault();
            return Redirect(url.ToString());
        }
    }
}