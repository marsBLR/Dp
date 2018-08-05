using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.BusinessLayer.Interfaces;
using Agency1.DataLayer.Entities;
using Agency1.BusinessLayer.Models;
using Agency1.DataLayer.Interfases;
using Agency1.DataLayer.Repositories;
using AutoMapper;
using System.Collections.ObjectModel;

namespace Agency1.BusinessLayer.Services
{
    public class EmployerService : IEmployerService
    {
        IUnitOfWork dataBase;
        public EmployerService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public void AddVacancyToEmployer(int EmployerId, VacancieViewModels vacancie)
        {
           
            var employer = dataBase.Employers.Get(EmployerId);
            Mapper.Reset();
            // Конфигурировани AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<VacancieViewModels, Vacancie>());
            // Отображение объекта EmployerViewModel на объект Employer
            var e = Mapper.Map<Vacancie>(vacancie);
            //Добавить вакансию
            employer.Vacancies.Add(e);
            // Сохранить изменения
            dataBase.Save();
        }

        public void CreateEmployer(EmployerViewModels employerModel)
        {

            Employer employerEntityDB = dataBase.Employers.Get(employerModel.EmployerId);
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<EmployerViewModels, Employer>());
            var employerEntity = Mapper.Map<Employer>(employerModel);
            //добавить работодателя в вакансию
            dataBase.Employers.Create(employerEntity);
            //Сохранить изменения
            dataBase.Save();
        }

        public void DeleteEmployer(int employerId)
        {
            dataBase.Employers.Delete(employerId);
            dataBase.Save();
        }

        public EmployerViewModels Get(int id)
        {
            var employerEntity = dataBase.Employers.Get(id);
            EmployerViewModels emoloyerModel = Mapper.Map<EmployerViewModels>(employerEntity);
            return emoloyerModel;
        }

        public ObservableCollection<EmployerViewModels> GetAll()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employer, EmployerViewModels>();
                cfg.CreateMap<Vacancie, VacancieViewModels>();
            });
            var employerModels = Mapper.Map<ObservableCollection<EmployerViewModels>>(dataBase.Employers.GetAll());
            return employerModels;
        }

        public void RemoveEmployerFromVacancy(int employertId, int vacancyId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployer(EmployerViewModels employerModel)
        {
            Employer employerEntityDB = dataBase.Employers.Get(employerModel.EmployerId);
            // Appointment appointmentEntity = Mapper.Map<Appointment>(appointmentModel);
            employerEntityDB.LastNameEmployer = employerModel.LastNameEmployer;
            employerEntityDB.NameEmployer = employerModel.NameEmployer;
            employerEntityDB.PatronymicEmployer = employerModel.PatronymicEmployer;
          //  employerEntityDB.Industry = employerModel.Industry;
            employerEntityDB.AddressEmployer = employerModel.AddressEmployer;
            employerEntityDB.Phone = employerModel.Phone;
        //    employerEntityDB.FullNameEmployers = employerModel.FullNameEmployers;
           

            dataBase.Employers.Update(employerEntityDB);
            dataBase.Save();
        }
    }
}
