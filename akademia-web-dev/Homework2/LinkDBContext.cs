using akademia_web_dev.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace akademia_web_dev.DB
{
    public class LinkDBContext : DbContext
    {
        public LinkDBContext(DbContextOptions<LinkDBContext> options) : base(options)
        {

        }

        public DbSet<HyperLinkModel> link { get; set; }
    }
}
