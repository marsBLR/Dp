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
    class PositionRepository : IRepository<Position>
    {
        Agency1Context context;
        public PositionRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(Position t)
        {
            context.Positions.Add(t);
        }

        public void Delete(int id)
        {
            var position = context.Positions.Find(id);
            context.Positions.Remove(position);
        }

        public IEnumerable<Position> Find(Func<Position, bool> predicate)
        {
            return context
                .Positions
                //.Include(g => g.Vacancies)
                .Where(predicate)
                .ToList();
        }

        public Position Get(int id)
        {
            return context.Positions.Find(id);
        }

        public IEnumerable<Position> GetAll()
        {
            return context.Positions;
            //return context.Positions/*.Include(g => g.Applicants)*/.Include(g => g.Vacancies);
        }

        public void Update(Position t)
        {
            context.Entry<Position>(t).State = EntityState.Modified;
        }
    }
}
