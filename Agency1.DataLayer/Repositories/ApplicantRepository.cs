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
    class ApplicantRepository : IRepository<Applicant>
    {
        Agency1Context context;
        public ApplicantRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(Applicant t)
        {
            context.Applicants.Add(t);
        }

        public void Delete(int id)
        {
            var applicant = context.Applicants.Find(id);
            context.Applicants.Remove(applicant);
        }

        public IEnumerable<Applicant> Find(Func<Applicant, bool> predicate)
        {
            return context
                .Applicants
                .Include(g => g.Deals)
                .Where(predicate)
                .ToList();
        }

        public Applicant Get(int id)
        {
            return context.Applicants.Find(id);
        }

        public IEnumerable<Applicant> GetAll()
        {
            //return context.Applicants;
            return context.Applicants.Include(a => a.Agent).Include(p => p.Position).Include(d => d.Deals);
        }

        public void Update(Applicant t)
        {
            context.Entry<Applicant>(t).State = EntityState.Modified;
        }
    }
}
