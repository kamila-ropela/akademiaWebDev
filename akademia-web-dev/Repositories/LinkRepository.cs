using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akademia_web_dev.DB;
using akademia_web_dev.Models;
using Microsoft.EntityFrameworkCore;

namespace akademia_web_dev.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly LinkDBContext _context;

        public LinkRepository(LinkDBContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            HyperLinkModel linkEntity = _context.link.Find(id);
            _context.link.Remove(linkEntity);
            _context.SaveChanges();
        }

        public HyperLinkModel Create(HyperLinkModel link)
        {
            //link.Hash = ConvertLinkToHex(link);
            _context.link.Add(link);
            _context.SaveChanges();
            return link;
        }
        public HyperLinkModel Update(HyperLinkModel link)
        {
            _context.link.Attach(link);
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return link;
        }

        public (IEnumerable<HyperLinkModel>, int) Get(string search, int skip)
        {
            var linksFilteredByLinks = search != null ? _context.link
            .Where(x => x.Link.ToLower()
            .Contains(search)) : _context.link;
            var linksCount = linksFilteredByLinks.Count();

            var paginatedLink = linksFilteredByLinks
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(10);

            return (paginatedLink, linksCount);
        }

        public HyperLinkModel Get(int id)
        {
            return _context.link.Find(id);
        }

        public List<HyperLinkModel> GetLinks() => _context.link.ToList();

        public object GetHashCode(string hash)
        {
            throw new NotImplementedException();
        }
    }
}