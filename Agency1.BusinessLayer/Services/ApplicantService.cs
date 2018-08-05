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
    public class ApplicantService : IApplicantService
    {
        IUnitOfWork dataBase;
        public ApplicantService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public void DeleteApplicant(int applicantId)
        {
            dataBase.Applicants.Delete(applicantId);
            dataBase.Save();
        }

        public ApplicantViewModels Get(int id)
        {
            var applicantEntity = dataBase.Applicants.Get(id);
            ApplicantViewModels applicantsModel = Mapper.Map<ApplicantViewModels>(applicantEntity);
            return applicantsModel;
        }

        public ObservableCollection<ApplicantViewModels> GetAll()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Applicant, ApplicantViewModels>();
                cfg.CreateMap<Position, PositionViewModels>();
                cfg.CreateMap<Agent, AgentViewModels>();
                cfg.CreateMap<Deal, DealViewModels>();
            });
            var applicantsModels = Mapper.Map<ObservableCollection<ApplicantViewModels>>(dataBase.Applicants.GetAll());
            return applicantsModels;
        }
        public void UpdateApplicant(ApplicantViewModels applicantModel)
        {
            Applicant applicantEntityDB = dataBase.Applicants.Get(applicantModel.ApplicantId);
            // Appointment appointmentEntity = Mapper.Map<Appointment>(appointmentModel);
            applicantEntityDB.LastNameAp = applicantModel.LastNameAp;
            applicantEntityDB.NameAp = applicantModel.NameAp;
            applicantEntityDB.PatronymicAp = applicantModel.PatronymicAp;
            applicantEntityDB.DateBirth = applicantModel.DateBirth;
            applicantEntityDB.Gender = applicantModel.Gender;
            applicantEntityDB.Education = applicantModel.Education;
            applicantEntityDB.ForeignLanguage = applicantModel.ForeignLanguage;
            applicantEntityDB.EstimatedSalary = applicantModel.EstimatedSalary;
            applicantEntityDB.OtherInformation = applicantModel.OtherInformation;
            applicantEntityDB.DateFilling = applicantModel.DateFilling;
            // вторичный ключ обновление ???

            applicantEntityDB.PositionId = applicantModel.PositionId;

            dataBase.Applicants.Update(applicantEntityDB);
            dataBase.Save();
        }
      
       
        public void AddApplicantToDeal(int dealsId, ApplicantViewModels applicant)
        {
            //var deal = dataBase.Applicants.Get(dealsId);
            //// Конфигурирование AutoMapper
            //Mapper.Initialize(cfg => cfg.CreateMap<ApplicantViewModels, Applicant>());
            //// Отображение обьекта ApplicantsViewModels на обьект Applicants
            //var appl = Mapper.Map<Applicant>(applicant);

            ///*/----------*/
            //dataBase.Save();
            throw new NotImplementedException();
 
        }

        public void AddDeal(ApplicantViewModels applicantmodel, DealViewModels dealmodel, VacancieViewModels vacanciemodel)
        {
            //throw new NotImplementedException();
            Applicant app = dataBase.Applicants.Get(applicantmodel.ApplicantId);
            Vacancie vac = dataBase.Vacancies.Get(vacanciemodel.VacancieId);
            dealmodel.Applicant = app;
            dealmodel.Vacancie = vac;
            Deal dealEntityDB = dataBase.Deals.Get(dealmodel.DealId);
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<DealViewModels, Deal>());
            var dealEntity = Mapper.Map<Deal>(dealmodel);
            //добавить deal
            dataBase.Deals.Create(dealEntity);
            //Сохранить изменения
            dataBase.Save();
        }

        public void AddApplicantToAgent(int agentId, ApplicantViewModels applicant)
        {
            throw new NotImplementedException();
        }

        public void RemoveApplicantFromAgent(int applicantId, int agentsId)
        {
            throw new NotImplementedException();
        }

        public void CreateApplicant(ApplicantViewModels applicantModel)
        {
            //throw new NotImplementedException();
            Applicant aplicantEntityDB = dataBase.Applicants.Get(applicantModel.ApplicantId);
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<ApplicantViewModels, Applicant>());
            var applicantsEntity = Mapper.Map<Applicant>(applicantModel);
            //добавить запись на прием
            dataBase.Applicants.Create(applicantsEntity);
            //Сохранить изменения
            dataBase.Save();
        }
    }
    
}

