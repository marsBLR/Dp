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
    public class DealService : IDealService
    {
        IUnitOfWork dataBase;
        public DealService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public void CreateDeal(DealViewModels dealModel)
        {
             //throw new NotImplementedException();
            Deal dealEntityDB = dataBase.Deals.Get(dealModel.DealId);
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<DealViewModels, Deal>());
            var dealEntity = Mapper.Map<Deal>(dealModel);
            //добавить deal
            dataBase.Deals.Create(dealEntity);
            //Сохранить изменения
            dataBase.Save();
        }

        public void DeleteDeal(int dealsId)
        {
            dataBase.Deals.Delete(dealsId);
            dataBase.Save();
            
        }

        public DealViewModels Get(int id)
        {
            var dealEntity = dataBase.Deals.Get(id);
            DealViewModels dealModel = Mapper.Map<DealViewModels>(dealEntity);
            return dealModel;
        }

        public ObservableCollection<DealViewModels> GetAll()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Deal, DealViewModels>();
                cfg.CreateMap<Applicant, ApplicantViewModels>();
                cfg.CreateMap<Vacancie, VacancieViewModels>();
                //cfg.CreateMap<Position, PositionViewModels>();
            });

            var dealModels = Mapper.Map<ObservableCollection<DealViewModels>>(dataBase.Deals.GetAll());
            return dealModels;
        }

        public void UpdateDeal(DealViewModels dealModel)
        {
            Deal dealEntityDB = dataBase.Deals.Get(dealModel.DealId);
          //  dealEntityDB.ApplicantId = dealModel.ApplicantId;
         ///   dealEntityDB.VacancyId = dealModel.Vaca;
          //  dealEntityDB.AgentId = dealModel.AgentId;
            dealEntityDB.DateCompilation = dealModel.DateCompilation;
            dealEntityDB.Commission = dealModel.Commission;
            dealEntityDB.Paid = dealModel.Paid;
            dealEntityDB.DatePaid = dealModel.DatePaid;

            dataBase.Deals.Update(dealEntityDB);
            dataBase.Save();
        }
    }
}
