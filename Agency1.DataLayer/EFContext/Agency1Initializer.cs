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
                new Role { RoleName = "user"},
            });
            context.SaveChanges();

            context.Agents.AddRange(new Agent[]
            {
                new Agent { Login = "admin", Password = "admin", RoleId = 2, Phone= 7777777 },
                new Agent { Login = "user1", Password = "user1",RoleId = 3,  LastNameAgent = "Рожков", NameAgent = "Сергей", Phone = 5701266 },
                new Agent { Login = "user2", Password = "user2", RoleId = 3, LastNameAgent = "Алимов", NameAgent = "Денис", Phone = 1562255 },
                new Agent { Login = "super admin", Password = "super", RoleId = 1, LastNameAgent = "директор", Phone = 1111111}

            });
            context.SaveChanges();
            context.Positions.AddRange(new Position[]
            {
                new Position {  PositionName = "Водитель" },              
                new Position {  PositionName = "Няня" },
                new Position {  PositionName = "Воспитатель" },
                new Position {  PositionName = "Повар" },
                new Position {  PositionName = "Помощник по хозяйству" },
                new Position {  PositionName = "Управляющий" },
                new Position {  PositionName = "Репититор" },
                new Position {  PositionName = "Садовник" },
                new Position { PositionName = "Сиделка" },
                new Position { PositionName = "Домработница" }
                //Applicants = new List<Applicant>
                //{
                // new Applicant() { LastNameAp = "Иванов", NameAp = "Иван", PatronymicAp = "Иванович", DateBirth = new DateTime(1986,07,04), Gender = Gender.мужчина, Education = Education.среднее, EstimatedSalary = 600, DateFilling = new DateTime(2018,5,7) }
                //},
             });
            context.SaveChanges();
 
            
            context.Employers.AddRange(new Employer[]
            {
                    new Employer { LastNameEmployer = "Путанов", NameEmployer = "Михаил", PatronymicEmployer = "Николаевич", AddressEmployer = "г.Минск ул.Достоевского 152/25", Phone = 80252231425 },
                    new Employer { LastNameEmployer = "Чигирь", NameEmployer = "Николай", PatronymicEmployer = "Михайлович", AddressEmployer = "г.Минск ул.Дерибасовская 2/2", Phone = 80291475888 },
                    new Employer { LastNameEmployer = "Милунович", NameEmployer = "Борис", PatronymicEmployer = "Федорович", AddressEmployer = "г.Минск ул.Солтонова 14", Phone = 80441452366 },
                    new Employer { LastNameEmployer = "Токарев", NameEmployer = "Олег", PatronymicEmployer = "Петрович", AddressEmployer = "г.Минск ул.Ивановская 256/9", Phone = 80176635896 },
                    new Employer { LastNameEmployer = "Николайчик", NameEmployer = "Михаил", PatronymicEmployer = "Александрович", AddressEmployer = "г.Минск ул.Богдановича 1", Phone = 80445896321 },
                    new Employer { LastNameEmployer = "Грицевич", NameEmployer = "Олег", PatronymicEmployer = "Константинович", AddressEmployer = "г.Минск ул.Балтийская 102/55", Phone = 80336464654},
                    new Employer { LastNameEmployer = "Федорова", NameEmployer = "Екатерина", PatronymicEmployer = "Сергеевна", AddressEmployer = "Минская область г.Смолевичи ул.Дерибасовская 12", Phone = 80295442236 },
                    new Employer { LastNameEmployer = "Макарова", NameEmployer = "Анастасия", PatronymicEmployer = "Михайловна", AddressEmployer = "г.Гомель ул.Барыкина 13", Phone = 80445266321 },
                    new Employer { LastNameEmployer = "Качанова", NameEmployer = "Алеся", PatronymicEmployer = "Владимировна" , AddressEmployer = "г.Минск ул.Разинская 64/51", Phone = 80256322554}
            });
            context.SaveChanges();

            context.Applicants.AddRange(new Applicant[]
            {
                 new Applicant { LastNameAp = "Иванов", NameAp = "Иван", PatronymicAp = "Иванович", DateBirth = new DateTime(1986,07,04), Gender = Gender.мужчина, PositionId = 1, Education = Education.среднее, EstimatedSalary = 600, DateFilling = new DateTime(2018,5,7), AgentId = 2 },
                 new Applicant { LastNameAp = "Петров", NameAp = "Петр", PatronymicAp = "Петрович", DateBirth = new DateTime(1989,05,14), Gender = Gender.мужчина, PositionId = 5, Education = Education.среднее, EstimatedSalary = 350, DateFilling = new DateTime(2018,5,6), AgentId = 3 },
                 new Applicant { LastNameAp = "Сидоров", NameAp = "Семен", PatronymicAp = "Семенович", DateBirth = new DateTime(1990,10,02), Gender = Gender.мужчина, PositionId = 5, Education = Education.средне_специальное, EstimatedSalary = 400, DateFilling = new DateTime(2018,5,5), AgentId = 2 },
                 new Applicant { LastNameAp = "Качанова", NameAp = "Тамара", PatronymicAp = "Сергеевна", DateBirth = new DateTime(1956,01,02), Gender = Gender.женщина, PositionId = 2, Education = Education.высшее, EstimatedSalary = 500, DateFilling = new DateTime(2018,5,4), AgentId = 3 },
                 new Applicant { LastNameAp = "Хачанов", NameAp = "Иван", PatronymicAp = "Николаевич", DateBirth = new DateTime(1990,03,04), Gender = Gender.мужчина, PositionId = 1, Education = Education.средне_специальное, EstimatedSalary = 600, DateFilling = new DateTime(2018,5,3), AgentId = 2 },
                 new Applicant { LastNameAp = "Колинич", NameAp = "Николай", PatronymicAp = "Николаевич", DateBirth = new DateTime(1965,02,05), Gender = Gender.мужчина, PositionId = 8, Education = Education.средне_специальное, EstimatedSalary = 600, DateFilling = new DateTime(2018,5,3), AgentId = 2 },
                 new Applicant { LastNameAp = "Хорошев", NameAp = "Анатолий", PatronymicAp = "Вячеславович", DateBirth = new DateTime(1968,11,12), Gender = Gender.мужчина, PositionId = 8, Education = Education.высшее, EstimatedSalary = 450, DateFilling = new DateTime(2018,6,13), AgentId = 2 },
                 new Applicant { LastNameAp = "Панкевич", NameAp = "Илья", PatronymicAp = "Дмитриевич", DateBirth = new DateTime(1992,08,24), Gender = Gender.мужчина, PositionId = 4, Education = Education.высшее, EstimatedSalary = 850, DateFilling = new DateTime(2018,7,1), AgentId = 2 },
                 new Applicant { LastNameAp = "Любимова", NameAp = "Любовь", PatronymicAp = "Сергеевна", DateBirth = new DateTime(1976,01,02), Gender = Gender.женщина, PositionId = 2, Education = Education.высшее, ForeignLanguage = ForeignLanguage.ENGLISH, EstimatedSalary = 500, DateFilling = new DateTime(2018,5,4), AgentId = 3, OtherInformation = "Репитирор английского языка" },
                 new Applicant { LastNameAp = "Китова", NameAp = "Анастасия", PatronymicAp = "Александровна", DateBirth = new DateTime(1980,11,22), Gender = Gender.женщина, PositionId = 2, Education = Education.высшее,ForeignLanguage = ForeignLanguage.ENGLISH, EstimatedSalary = 600, DateFilling = new DateTime(2018,2,24), AgentId = 2, OtherInformation = "Репитирор английского языка" },
                 new Applicant { LastNameAp = "Тараскина", NameAp = "Надежда", PatronymicAp = "Сергеевна", DateBirth = new DateTime(1976,01,02), Gender = Gender.женщина, PositionId = 2, Education = Education.высшее,ForeignLanguage = ForeignLanguage.ENGLISH, EstimatedSalary = 500, DateFilling = new DateTime(2018,5,4), AgentId = 3, OtherInformation = "Репитирор немецкого,английского,французкого языка" },
                 new Applicant { LastNameAp = "Нигматулин", NameAp = "Иван", PatronymicAp = "Александрович", DateBirth = new DateTime(1980,10,01), Gender = Gender.мужчина, PositionId = 1, Education = Education.среднее, EstimatedSalary = 500, DateFilling = new DateTime(2018,7,13), AgentId = 2 },
                 new Applicant { LastNameAp = "Федоров", NameAp = "Николай", PatronymicAp = "Филиповичвич", DateBirth = new DateTime(1968,05,15), Gender = Gender.мужчина, PositionId = 4, Education = Education.средне_специальное, EstimatedSalary = 600, DateFilling = new DateTime(2018,7,23), AgentId = 3 },
                 new Applicant { LastNameAp = "Лапырев", NameAp = "Илья", PatronymicAp = "Вячеславович", DateBirth = new DateTime(1978,11,02), Gender = Gender.мужчина, PositionId = 5, Education = Education.высшее, EstimatedSalary = 650, DateFilling = new DateTime(2018,6,23), AgentId = 2 },
                 new Applicant { LastNameAp = "Питкович", NameAp = "Сергей", PatronymicAp = "Дмитриевич", DateBirth = new DateTime(1991,08,20), Gender = Gender.мужчина, PositionId = 4, Education = Education.высшее, EstimatedSalary = 750, DateFilling = new DateTime(2018,2,1), AgentId = 3 },
            });
            context.SaveChanges();
            context.Contracts.AddRange(new Contract[]
                {
                    new Contract { DateOfContract =  new DateTime(2018,05,06), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 2, EmployerId = 1},
                    new Contract { DateOfContract =  new DateTime(2018,04,05), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 2, EmployerId = 2},
                    new Contract { DateOfContract =  new DateTime(2018,03,05), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 2, EmployerId = 4},
                    new Contract { DateOfContract =  new DateTime(2018,02,05), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 2, EmployerId = 4},
                    new Contract { DateOfContract =  new DateTime(2018,05,15), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 2, EmployerId = 5},
                    new Contract { DateOfContract =  new DateTime(2018,07,25), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 2, EmployerId = 6},
                    new Contract { DateOfContract =  new DateTime(2018,08,05), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 2, EmployerId = 3},
                    new Contract { DateOfContract =  new DateTime(2018,06,18), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 3, EmployerId = 7},
                    new Contract { DateOfContract =  new DateTime(2018,07,23), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 3, EmployerId = 7},
                    new Contract { DateOfContract =  new DateTime(2018,08,03), StatusContract = StatusContract.открыт, Sum = 100, Сurrency = Currency.BYN, Discount = 0, AgentId = 3, EmployerId = 9},

                });
            context.SaveChanges();
            context.Vacancies.AddRange(new Vacancie[]
           {

                new Vacancie { EmployerId = 1, Gender = Gender.мужчина, PositionId = 5, Education = Education.средне_специальное, DrivingLicence = "B", ForeignLanguage = ForeignLanguage.нет, Salary = 800, DateOpen = new DateTime(2018,05,06), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 2, Gender = Gender.мужчина, PositionId = 1, Education = Education.среднее, DrivingLicence = "B", ForeignLanguage = ForeignLanguage.нет, Salary = 600, DateOpen = new DateTime(2018,04,05), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 3, Gender = Gender.мужчина, PositionId = 1, Education = Education.среднее, DrivingLicence = "B", ForeignLanguage = ForeignLanguage.нет, Salary = 700, DateOpen = new DateTime(2018,08,05), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 4, Gender = Gender.женщина, PositionId = 4, Education = Education.высшее, DrivingLicence = "нет", ForeignLanguage = ForeignLanguage.ENGLISH, Salary = 500, DateOpen = new DateTime(2018,03,05), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 4, Gender = Gender.любой, PositionId = 10, DrivingLicence = "нет", Salary = 500, DateOpen = new DateTime(2018,02,05), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 5, Gender = Gender.женщина, PositionId = 6, Education = Education.высшее, DrivingLicence = "нет", ForeignLanguage = ForeignLanguage.ENGLISH, Salary = 600, DateOpen = new DateTime(2018, 01, 05), OpenVacancy = OpenVacancy.нет},

                new Vacancie { EmployerId = 6, Gender = Gender.любой, PositionId = 7, Education = Education.высшее, ForeignLanguage = ForeignLanguage.ENGLISH, Salary = 800, DateOpen = new DateTime(2018,07,25), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 7, Gender = Gender.мужчина, PositionId = 7, Education = Education.высшее, ForeignLanguage = ForeignLanguage.ENGLISH, Salary = 700, DateOpen = new DateTime(2018,06,18), OpenVacancy = OpenVacancy.да  },
                new Vacancie { EmployerId = 7, Gender = Gender.мужчина, PositionId = 10, ForeignLanguage = ForeignLanguage.нет, Salary = 400, DateOpen = new DateTime(2018,07,23), OpenVacancy = OpenVacancy.нет  },
                new Vacancie { EmployerId = 9, Gender = Gender.женщина, PositionId = 2, Education = Education.высшее, DrivingLicence = "нет", Salary = 600, DateOpen = new DateTime(2018, 08, 03), OpenVacancy = OpenVacancy.да}
       });

            context.SaveChanges();

            context.PaymentAccounts.AddRange(new PaymentAccount[]
            {
                new PaymentAccount { ContractId = 1, DateOfInvoice = new DateTime(2018,05,06), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.оплачен, DateOfPayment = new DateTime(2018,05,06) },
                new PaymentAccount { ContractId = 2, DateOfInvoice = new DateTime(2018,04,05), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.оплачен, DateOfPayment = new DateTime(2018,04,05) },
                new PaymentAccount { ContractId = 3, DateOfInvoice = new DateTime(2018,08,05), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.оплачен, DateOfPayment = new DateTime(2018,08,05),  },
                new PaymentAccount { ContractId = 4, DateOfInvoice = new DateTime(2018,02,05), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.оплачен, DateOfPayment = new DateTime(2018,02,05)},
                new PaymentAccount { ContractId = 4, DateOfInvoice = new DateTime(2018,03,05), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.оплачен, DateOfPayment = new DateTime(2018,03,05)}
                //new PaymentAccount { ContractId = 5, DateOfInvoice = new DateTime(2018,05,15), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.выставлен},
                //new PaymentAccount { ContractId = 6, DateOfInvoice = new DateTime(2018,07,25), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.оплачен, DateOfPayment = new DateTime(2018,07,25)},
                //new PaymentAccount { ContractId = 7, DateOfInvoice = new DateTime(2018,06,18), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.оплачен, DateOfPayment = new DateTime(2018,06,18) },
                //new PaymentAccount { ContractId = 7, DateOfInvoice = new DateTime(2018,07,23), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.выставлен },
                //new PaymentAccount { ContractId = 9, DateOfInvoice = new DateTime(2018,08,03), SumPayment = 100, TypeOfCalculation = TypeOfCalculation.наличный_расчет, StatusPayment = StatusPayment.оплачен, DateOfPayment = new DateTime(2018,08,03)},

            });
            context.SaveChanges();
            

           
           
            
            //context.Deals.AddRange(new Deal[]
            //{
            //   // new Deal { Vacancie  = vac , ApplicantId = 1,DateCompilation = new DateTime(2018,05,07), Commission = 25, Paid = Paid.нет, DatePaid = new DateTime(2018,05,07)}
            //});
            //context.SaveChanges();

        }
    }
}
