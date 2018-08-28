using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrShop.Data.Infrastructure
{
    public class DbFactory : Disposeable, IDbFactory
    {
        PrShopDbContext dbContext;
        public PrShopDbContext Init()
        {
            return dbContext ?? (dbContext = new PrShopDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null) dbContext.Dispose();
        }
    }
}
