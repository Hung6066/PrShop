using PrShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PrShop.Data.Infrastructure;

namespace ProShop.Data.Repositories
{
    public interface IContactDetailRepository :  IRepository<ContactDetail>  
    {

    }
    public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

      
    }
}
