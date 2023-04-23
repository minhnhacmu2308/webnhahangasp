using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class BranchRepositpry
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();

        public List<Branch> GetBranches()
        {
            return myDb.branches.ToList();
        }
    }
}