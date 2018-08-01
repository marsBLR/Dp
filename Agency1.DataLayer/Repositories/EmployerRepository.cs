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
    class EmployerRepository : IRepository<Employer>
    {
        Agency1Context context;
        public EmployerRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(Employer t)
        {
            context.Employers.Add(t);
        }

        public void Delete(int id)
        {
            var employer = context.Employers.Find(id);
            context.Employers.Remove(employer);
        }

        public IEnumerable<Employer> Find(Func<Employer, bool> predicate)
        {
            return context
                .Employers
                .Include(g => g.Vacancies)
                .Where(predicate)
                .ToList();
        }

        public Employer Get(int id)
        {
            return context.Employers.Find(id);
        }

        public IEnumerable<Employer> GetAll()
        {
           //return context.Employers;
           return context.Employers.Include(g => g.Vacancies);
        }

        public void Update(Employer t)
        {
            context.Entry<Employer>(t).State = EntityState.Modified;
        }
    }
}
