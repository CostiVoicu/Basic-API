using Project.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public class BaseRepository
    {
        protected PetShopDbContext petShopDbContext { get; set; }

        public BaseRepository(PetShopDbContext petShopDbContext)
        {
            this.petShopDbContext = petShopDbContext;
        }

        public void SaveChanges()
        {
            petShopDbContext.SaveChanges();
        }
    }
}
