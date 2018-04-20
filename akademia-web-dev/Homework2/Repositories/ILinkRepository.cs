using akademia_web_dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace akademia_web_dev.Repositories
{
    interface ILinkRepository
    {
        (IEnumerable<HyperLinkModel>, int) Get(string search, int page);
        HyperLinkModel Get(int id);
        HyperLinkModel Create(HyperLinkModel link);
        HyperLinkModel Update(HyperLinkModel link);
        List<HyperLinkModel> GetLinks();
        void Delete(int id);
        object GetHashCode(string hash);
    }

}
