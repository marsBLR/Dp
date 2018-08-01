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
    class VacancieRepository : IRepository<Vacancie>
    {
        Agency1Context context;
        public VacancieRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(Vacancie t)
        {
            context.Vacancies.Add(t);
        }

        public void Delete(int id)
        {
            var vacancy = context.Vacancies.Find(id);
            context.Vacancies.Remove(vacancy);
        }

        public IEnumerable<Vacancie> Find(Func<Vacancie, bool> predicate)
        {
            return context
                .Vacancies
                .Include(p => p.Position)
                .Include(d => d.Deal)
                .Where(predicate)
                .ToList();
        }

        public Vacancie Get(int id)
        {
            return context.Vacancies.Find(id);
        }

        public IEnumerable<Vacancie> GetAll()
        {
            // return context.Applicants.Include(g => g.Deals).Include(p => p.Position);
            return context.Vacancies.Include(g => g.Employer).Include(p => p.Position).Include(g => g.Deal);
            //return context.Vacancies;
        }

        public void Update(Vacancie t)
        {
            context.Entry<Vacancie>(t).State = EntityState.Modified;
        }
        public void Close(Vacancie t)
        {
            context.Entry<Vacancie>(t).State = EntityState.Modified;
        }

        public void Close(Deal d)
        {
            context.Entry<Deal>(d).State = EntityState.Modified;
        }
    }
}
