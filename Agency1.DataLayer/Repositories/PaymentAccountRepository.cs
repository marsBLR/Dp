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
    class PaymentAccountRepository : IRepository<PaymentAccount>
    {
        Agency1Context context;
        public PaymentAccountRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(PaymentAccount t)
        {
            context.PaymentAccounts.Add(t);
        }

        public void Delete(int id)
        {
            var paymentaccount = context.PaymentAccounts.Find(id);
            context.PaymentAccounts.Remove(paymentaccount);
            //var agent = context.Agents.Find(id);
            //context.Agents.Remove(agent);
        }

        public IEnumerable<PaymentAccount> Find(Func<PaymentAccount, bool> predicate)
        {
            /* return context
                .Agents
                //.Include(g => g.Deals)
                .Include(ap => ap.Applicants)
                .Where(predicate)
                .ToList();*/
            return context
            .PaymentAccounts
            .Include(c => c.Contracts)
            .Where(predicate)
            .ToList();
        }

        public PaymentAccount Get(int id)
        {
            return context.PaymentAccounts.Find(id);
        }

        public IEnumerable<PaymentAccount> GetAll()
        {
            return context.PaymentAccounts.Include(c => c.Contracts);
        }

        public void Update(PaymentAccount t)
        {
            context.Entry<PaymentAccount>(t).State = EntityState.Modified;
        }
    }
}
