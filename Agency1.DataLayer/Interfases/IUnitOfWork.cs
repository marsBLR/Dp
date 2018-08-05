using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;

namespace Agency1.DataLayer.Interfases
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<Agent> Agents { get; }
        IRepository<Applicant> Applicants { get; }
        IRepository<Deal> Deals { get; }
        IRepository<Employer> Employers { get; }
        IRepository<Position> Positions { get; }
        IRepository<Vacancie> Vacancies { get; }
        IRepository<Role> Roles { get; }
        IRepository<Contract> Contracts { get; }
        IRepository<PaymentAccount> PaymentAccounts { get; }

        void Save();

    
    }
}
