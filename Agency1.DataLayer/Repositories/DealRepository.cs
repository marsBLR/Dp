using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;
using Agency1.DataLayer.EFContext;
using Agency1.DataLayer.Interfases;
using System.Data.Entity;

namespace Agency1.DataLayer.Repositories
{
    class DealRepository : IRepository<Deal>
    {
        Agency1Context context;
        public DealRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(Deal t)
        {
            context.Deals.Add(t);
        }

        public void Delete(int id)
        {
            var deal = context.Deals.Find(id);
            context.Deals.Remove(deal);
        }

        public IEnumerable<Deal> Find(Func<Deal, bool> predicate)
        {
            return context
                .Deals
                .Include(ap => ap.Applicant)
                .Include(v => v.Vacancie)
                .Where(predicate)
                .ToList();
        }

        public Deal Get(int id)
        {
            return context.Deals.Find(id);
        }

        public IEnumerable<Deal> GetAll()
        {
          return context.Deals.Include(a => a.Applicant).Include(v => v.Vacancie);
          //return context.Deals;
        }

        public void Update(Deal t)
        {
            context.Entry<Deal>(t).State = EntityState.Modified;
        }
    }
}
