using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Agency1.DataLayer.Entities;

namespace Agency1.DataLayer.EFContext
{
    class Agency1Initializer :CreateDatabaseIfNotExists<Agency1Context>
    {
        protected override void Seed(Agency1Context context)
        {
            context.Roles.AddRange(new Role[]
                {
                new Role { RoleName = "super admin"},
                new Role { RoleName = "admin"},
                new Role { RoleName = "user"}
            });
            context.SaveChanges();

            context.Agents.AddRange(new Agent[]
            {
                new Agent {Login = "admin", Password = "admin", RoleId = 2, Phone= 7777777 },
                new Agent { Login = "user1", Password = "user1",RoleId = 3,  LastNameAgent = "Рожков", NameAgent = "Сергей", Phone = 5701266 },
                new Agent { Login = "user2", Password = "user2", RoleId = 3, LastNameAgent = "Алимов", NameAgent = "Денис", Phone = 1562255 }

            });
            context.SaveChanges();
            context.Positions.AddRange(new Position[]
            {
                new Position {  PositionName = "водитель" },
                //Applicants = new List<Applicant>
                //{
                // new Applicant() { LastNameAp = "Иванов", NameAp = "Иван", PatronymicAp = "Иванович", DateBirth = new DateTime(1986,07,04), Gender = Gender.мужчина, Education = Education.среднее, EstimatedSalary = 600, DateFilling = new DateTime(2018,5,7) }
                //},
                new Position {  PositionName = "програмист" },
                new Position {  PositionName = "секретарь" },
                new Position {  PositionName = "бугалтер" },
                new Position {  PositionName = "машинист" },
                new Position {  PositionName = "учитель" },
                new Position {  PositionName = "слесарь" },
                new Position {  PositionName = "механик" }

             });
            context.SaveChanges();
 
            
            context.Employers.AddRange(new Employer[]
            {
                new Employer {  NameEmployer = "МинскТранс", Industry = "Нефть и газ", AddressEmployer = "г.Минск ул.Достоевского 152/25", Phone = 2231425, FullNameEmployers = "Чигирь Иван Иванович" },
                 new Employer { NameEmployer = "МинскВодоканал", Industry = "Водные ресурсы", AddressEmployer = "г.Минск ул.Дерибасовская 2/2", Phone = 1475888, FullNameEmployers = "Милунович Михаил Борисович" },
                  new Employer { NameEmployer = "МинскМаз", Industry = "Тяжелая промышленность", AddressEmployer = "г.Минск ул.Солтонова 14", Phone = 1452366, FullNameEmployers = "Токарев Иван Петрович" },
                   new Employer { NameEmployer = "Беларусь Нефть", Industry = "Нефть и газ", AddressEmployer = "г.Минск ул.Ивановская 256/9", Phone = 6635896, FullNameEmployers = "Тапать Сергей Иванович" },
                    new Employer { NameEmployer = "Школа №15", Industry = "Образование", AddressEmployer = "г.Минск ул.Богдановича 1", Phone = 5896321, FullNameEmployers = "Макаров Макар Макарович" },
            });
            context.SaveChanges();

            var vac = new Vacancie { EmployerId = 5, Gender = Gender.женщина, PositionId = 6, Education = Education.высшее, DrivingLicence = "нет", ForeignLanguage = ForeignLanguage.ENGLISH, Salary = 600, DateFilling = new DateTime(2018, 01, 05), OpenVacancy = OpenVacancy.да};

            context.Vacancies.AddRange(new Vacancie[]
            {
                vac,
                new Vacancie { EmployerId = 1, Gender = Gender.мужчина, PositionId = 5, Education = Education.средне_специальное, DrivingLicence = "B, C, D, E, F", ForeignLanguage = ForeignLanguage.нет, Salary = 900, DateFilling = new DateTime(2018,05,06), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 2, Gender = Gender.мужчина, PositionId = 1, Education = Education.среднее, DrivingLicence = "B", ForeignLanguage = ForeignLanguage.нет, Salary = 600, DateFilling = new DateTime(2018,04,05), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 4, Gender = Gender.женщина, PositionId = 4, Education = Education.высшее, DrivingLicence = "нет", ForeignLanguage = ForeignLanguage.ENGLISH, Salary = 500, DateFilling = new DateTime(2018,03,05), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 4, Gender = Gender.любой, PositionId = 2, Education = Education.высшее, DrivingLicence = "нет", ForeignLanguage = ForeignLanguage.ENGLISH, Salary = 1500, DateFilling = new DateTime(2018,02,05), OpenVacancy = OpenVacancy.да  }
            });

            context.SaveChanges();
            context.Applicants.AddRange(new Applicant[]
             {
                new Applicant { LastNameAp = "Иванов", NameAp = "Иван", PatronymicAp = "Иванович", DateBirth = new DateTime(1986,07,04), Gender = Gender.мужчина, PositionId = 1, Education = Education.среднее, EstimatedSalary = 600, DateFilling = new DateTime(2018,5,7), AgentId = 2 },
                new Applicant { LastNameAp = "Петров", NameAp = "Петр", PatronymicAp = "Петрович", DateBirth = new DateTime(1989,05,14), Gender = Gender.мужчина, PositionId = 7, Education = Education.средне_специальное, EstimatedSalary = 800, DateFilling = new DateTime(2018,5,6), AgentId = 3 },
                new Applicant { LastNameAp = "Сидоров", NameAp = "Семен", PatronymicAp = "Семенович", DateBirth = new DateTime(1990,10,02), Gender = Gender.мужчина, PositionId = 5, Education = Education.средне_специальное, EstimatedSalary = 1000, DateFilling = new DateTime(2018,5,5), AgentId = 2 },
                new Applicant { LastNameAp = "Качанова", NameAp = "Тамара", PatronymicAp = "Сергеевна", DateBirth = new DateTime(1956,01,02), Gender = Gender.женщина, PositionId = 3, Education = Education.высшее, EstimatedSalary = 500, DateFilling = new DateTime(2018,5,4), AgentId = 3 },
                new Applicant {LastNameAp = "Хачанов", NameAp = "Иван", PatronymicAp = "Николаевич", DateBirth = new DateTime(1990,03,04), Gender = Gender.мужчина, PositionId = 1, Education = Education.средне_специальное, EstimatedSalary = 600, DateFilling = new DateTime(2018,5,3), AgentId = 2 }
             });
            context.SaveChanges();

            context.Deals.AddRange(new Deal[]
            {
                new Deal { Vacancie  = vac , ApplicantId = 1,DateCompilation = new DateTime(2018,05,07), Commission = 25, Paid = Paid.нет, DatePaid = new DateTime(2018,05,07)}
            });
            context.SaveChanges();

        }
    }
}
