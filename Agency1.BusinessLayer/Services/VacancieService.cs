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
    public class VacancieService : IVacancieService
    {
        IUnitOfWork dataBase;
        public VacancieService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public void AddVacancyToDeal(int dealsId, VacancieViewModels vacancy)
        {
            throw new NotImplementedException();
        }

        public void CloseVacancy(DealViewModels dealModel)
        {
            //var v =
            Deal vacancyEntityDB = dataBase.Deals.Get(dealModel.DealId);
            //var v1 = vacancyEntityDB.Vacancie.VacancieId;
            //Vacancie vacancyEntityDB1 = dataBase.Vacancies.Get(v1);
            vacancyEntityDB.Vacancie.OpenVacancy = OpenVacancy.нет;
            vacancyEntityDB.Paid = Paid.да;
            dataBase.Deals.Update(vacancyEntityDB);
            dataBase.Save();
        }

        //Завершение сделки закрытие
        public void CloseVacancy (VacancieViewModels vacancyModel)
        {
            Vacancie vacancyEntityDB = dataBase.Vacancies.Get(vacancyModel.VacancieId);
            vacancyEntityDB.Deal.Paid = Paid.да;
            vacancyEntityDB.OpenVacancy = OpenVacancy.нет;
            dataBase.Vacancies.Update(vacancyEntityDB);
            dataBase.Save();
        }

        public void CreateVacancy(VacancieViewModels vacancyModel)
        {
            var vacancyEntity = Mapper.Map<Vacancie>(vacancyModel);
            //добавить вакансию в сделку 
            dataBase.Vacancies.Create(vacancyEntity);
            //Сохранить изменения
            dataBase.Save();
        }

        public void DeleteVacancy(int vacancyId)
        {
            dataBase.Vacancies.Delete(vacancyId);
            dataBase.Save();

        }

        public VacancieViewModels Get(int id)
        {
            var vacancyEntity = dataBase.Vacancies.Get(id);
            VacancieViewModels vacancyModel = Mapper.Map<VacancieViewModels>(vacancyEntity);
            return vacancyModel;
        }

        public ObservableCollection<VacancieViewModels> GetAll()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employer, EmployerViewModels>();
                cfg.CreateMap<Vacancie, VacancieViewModels>();
                cfg.CreateMap<Position, PositionViewModels>();
                cfg.CreateMap<Deal, DealViewModels>();
            });
            var vacancyModels = Mapper.Map<ObservableCollection<VacancieViewModels>>(dataBase.Vacancies.GetAll());
            return vacancyModels;
        }

        public void RemoveVacancyFromDeal(int vacancyId, int dealsId)
        {
            throw new NotImplementedException();
        }

        public void UpdateVacancy(VacancieViewModels vacancyModel)
        {
            Vacancie vacancyEntityDB = dataBase.Vacancies.Get(vacancyModel.VacancieId);

           // vacancyEntityDB.EmployerId = vacancyModel.EmployerId;// vacancyModel.Employer;
            vacancyEntityDB.Gender = vacancyModel.Gender;
          //  vacancyEntityDB.PositionId = vacancyModel.PositionId;
            vacancyEntityDB.Education = vacancyModel.Education;
            vacancyEntityDB.DrivingLicence = vacancyModel.DrivingLicence;
            vacancyEntityDB.ForeignLanguage = vacancyModel.ForeignLanguage;
            vacancyEntityDB.Salary = vacancyModel.Salary;
            vacancyEntityDB.WorkingConditions = vacancyModel.WorkingConditions;
            vacancyEntityDB.DateFilling = vacancyModel.DateFilling;
            vacancyEntityDB.OpenVacancy = vacancyModel.OpenVacancy;
            



            dataBase.Vacancies.Update(vacancyEntityDB);
            dataBase.Save();
        }
    }
}
