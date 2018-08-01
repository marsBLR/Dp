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
    class RoleRepository : IRepository<Role>
    {
        Agency1Context context;
        public RoleRepository(Agency1Context context)
        {
            this.context = context;
        }
        public void Create(Role t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return context
               .Roles
               //.Include(g => g.Vacancies)
               .Where(predicate)
               .ToList();
        }

        public Role Get(int id)
        {
            return context.Roles.Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Roles;
        }

        public void Update(Role t)
        {
            throw new NotImplementedException();
        }
    }
}
