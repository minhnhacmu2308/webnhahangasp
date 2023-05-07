using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class TypeFoodRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();

        public List<TypeFood> GetAll()
        {
            return myDb.typeFoods.ToList();
        }
    }
}