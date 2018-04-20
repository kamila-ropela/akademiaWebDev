using System;
using System.Collections.Generic;
using System.Linq;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Repository
{
    public class LinkRepository
    {
        private readonly IHashDecoder _hashDecoder;
        private readonly IHashEncoder _hashEncoder;
        private readonly LinkDbContext _context;

        public LinkRepository(IHashDecoder hashDecoder, IHashEncoder hashEncoder, LinkDbContext context)
        {
            _context = context;
            _hashDecoder = hashDecoder;
            _hashEncoder = hashEncoder;
        }

        public List<Link> GetLinks()
        {
            return _context.Links.ToList();
        }

        public (IEnumerable<Link>, int) GetLinks(int skip, int itemPerPage)
        {
            var linksCount = _context.Links.Count();

            var paginatedLink = _context.Links
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(itemPerPage);

            return (paginatedLink, linksCount);
        }

        public void AddLink(Link link)
        {
            _context.Links.Add(link);
            _context.SaveChanges();
            link.ShortUrl = _hashEncoder.Encode(link.Id);
            _context.SaveChanges();
        }

        public void DeleteLink(int linkId)
        {
            var itemToRemove = _context.Links.SingleOrDefault(element => element.Id == linkId);
            _context.Links.Remove(itemToRemove);
        }

        public string GetFullLink(string shortLink)
        {
            var id = _hashDecoder.Decode(shortLink);
            return _context.Links.SingleOrDefault(link => link.Id == id).FullUrl;
        }

    }
}