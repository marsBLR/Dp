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
    class AgentRepository : IRepository<Agent>
    {
        Agency1Context context;
        public AgentRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(Agent t)
        {
            context.Agents.Add(t);
        }

        public void Delete(int id)
        {
            var agent = context.Agents.Find(id);
            context.Agents.Remove(agent);
        }

        public IEnumerable<Agent> Find(Func<Agent, bool> predicate)
        {           
            return context
                .Agents
                //.Include(g => g.Deals)
                .Include(ap => ap.Applicants)
                .Where(predicate)
                .ToList();
        }

        public Agent Get(int id)
        {
            return context.Agents.Find(id);
        }

        public IEnumerable<Agent> GetAll()
        {
            //тут исправил сделки
           //return context.Agents;
           return context.Agents.Include(ap => ap.Applicants);
        }
      
        public void Update(Agent t)
        {
            context.Entry<Agent>(t).State = EntityState.Modified;
        }
    }
}
