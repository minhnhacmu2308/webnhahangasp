using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class BranchRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();

        public List<Branch> GetBranches()
        {
            return myDb.branches.ToList();
        }

        public void add(Branch branch)
        {
            myDb.branches.Add(branch);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.branches.FirstOrDefault(x => x.BranchId == id);
            myDb.branches.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(Branch branch)
        {
            var obj = myDb.branches.FirstOrDefault(x => x.BranchId == branch.BranchId);
            obj.Name = branch.Name;
            obj.Address = branch.Address;
            myDb.SaveChanges();
        }

        public Branch getBranch(int id)
        {
            return myDb.branches.FirstOrDefault(x => x.BranchId == id);
        }

        public List<Booking> getBookingBranch(int id)
        {
            return myDb.bookings.Where(x => x.BranchId == id).ToList();
        }
    }
}