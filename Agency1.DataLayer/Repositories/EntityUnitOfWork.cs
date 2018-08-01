using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;
using Agency1.DataLayer.Interfases;
using Agency1.DataLayer.EFContext;

namespace Agency1.DataLayer.Repositories
{
   public class EntityUnitOfWork : IUnitOfWork
    {
        Agency1Context context;
        AgentRepository agetsRepository;
        ApplicantRepository applicantsRepository;
        DealRepository dealsRepository;
        EmployerRepository employersRepository;
        PositionRepository positionsRepository;
        VacancieRepository vacanciesRepository;
        RoleRepository rolesRepository;

        public EntityUnitOfWork(string name)
        {
            context = new Agency1Context(name);
        }

        public IRepository<Agent> Agents
        {
            get
            {
                if (agetsRepository == null)
                    agetsRepository = new AgentRepository(context);
                return agetsRepository;
            }
        }

        public IRepository<Applicant> Applicants
        {
            get
            {
                if (applicantsRepository == null)
                    applicantsRepository = new ApplicantRepository(context);
                return applicantsRepository;
            }
        }

        public IRepository<Deal> Deals
        {
            get
            {
                if (dealsRepository == null)
                    dealsRepository = new DealRepository(context);
                return dealsRepository;
            }
        }

        public IRepository<Employer> Employers
        {
            get
            {
                if (employersRepository == null)
                    employersRepository = new EmployerRepository(context);
                return employersRepository;
            }
        }

        public IRepository<Position> Positions
        {
            get
            {
                if (positionsRepository == null)
                    positionsRepository = new PositionRepository(context);
                return positionsRepository;
            }
        }

        public IRepository<Vacancie> Vacancies
        {
            get
            {
                if (vacanciesRepository == null)
                    vacanciesRepository = new VacancieRepository(context);
                return vacanciesRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (rolesRepository == null)
                    rolesRepository = new RoleRepository(context);
                return rolesRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
