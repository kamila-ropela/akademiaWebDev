using Microsoft.AspNetCore.Mvc;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Controllers
{
    [Route("api/Link")]
    public class LinkApiController : Controller
    {
        private readonly ILinkWriter _linkWriter;
        private readonly ILinkReader _linkReader;

        public LinkApiController(ILinkReader linkReader, ILinkWriter linkWriter)
        {
            _linkReader = linkReader;
            _linkWriter = linkWriter;
        }

        [HttpGet]
        public IActionResult Index(int? page = 1)
        {
            var result = _linkReader.GetLinks(page.Value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            _linkWriter.AddLink(link);
            return Ok(link);
        }

        [HttpDelete]
        public IActionResult Delete(int linkId)
        {
            _linkWriter.DeleteLink(linkId);
            return Ok();
        }
    }
}