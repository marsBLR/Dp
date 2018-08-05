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
    class ContractRepository : IRepository<Contract>
    {
        Agency1Context context;
        public ContractRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(Contract t)
        {
            context.Contracts.Add(t);
        }

        public void Delete(int id)
        {
            /*var agent = context.Agents.Find(id);
            context.Agents.Remove(agent);*/
            var contract = context.Contracts.Find(id);
            context.Contracts.Remove(contract);
        }

        public IEnumerable<Contract> Find(Func<Contract, bool> predicate)
        {
            /* return context
                .Agents
                //.Include(g => g.Deals)
                .Include(ap => ap.Applicants)
                .Where(predicate)
                .ToList();*/
            return context
            .Contracts
            .Include(g => g.Employer)
            .Include(a => a.Agent)
            .Where(predicate)
            .ToList();
        }

        public Contract Get(int id)
        {
            return context.Contracts.Find(id);
        }

        public IEnumerable<Contract> GetAll()
        {
            /* return context.Agents.Include(ap => ap.Applicants);*/
            return context.Contracts.Include(g => g.Employer).Include(a => a.Agent);
        }

        public void Update(Contract t)
        {
            context.Entry<Contract>(t).State = EntityState.Modified;
        }
    }
}
