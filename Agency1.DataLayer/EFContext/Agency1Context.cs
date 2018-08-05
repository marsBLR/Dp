using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;
using System.Data.Entity;

namespace Agency1.DataLayer.EFContext
{
   public class Agency1Context : DbContext
    {
        public Agency1Context(string name) :base (name)
        {
            Database.SetInitializer(new Agency1Initializer());
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Vacancie> Vacancies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Deal>()
                           .HasRequired(b => b.Vacancie)
                           .WithOptional(t => t.Deal)
                           .Map(k => k.MapKey("VacancieId"));

            // Аналогичная настройка


            // место для вызовов Entity Framework Fluent API
        }

    }
}
