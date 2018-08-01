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
    public class PositionService : IPositionService
    {
        IUnitOfWork dataBase;
        public PositionService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public void CreatePosition(PositionViewModels positionModel)
        {
            Position positionEntityDB = dataBase.Positions.Get(positionModel.PositionId);
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<PositionViewModels, Position>());
            var positonEntity = Mapper.Map<Position>(positionModel);
            //добавить профессию
            dataBase.Positions.Create(positonEntity);
            //Сохранить изменения
            dataBase.Save();
        }

        public void DeletePosition(int positionId)
        {
            dataBase.Positions.Delete(positionId);
            dataBase.Save();
        }

        public PositionViewModels Get(int id)
        {
            var positionEntity = dataBase.Positions.Get(id);
            PositionViewModels positionModel = Mapper.Map<PositionViewModels>(positionEntity);
            return positionModel;
        }

        public ObservableCollection<PositionViewModels> GetAll()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Position, PositionViewModels>();
              //  cfg.CreateMap<Applicant, ApplicantViewModels>();
            //    cfg.CreateMap<Vacancie, VacancieViewModels>();
            });
            var positionModels = Mapper.Map<ObservableCollection<PositionViewModels>>(dataBase.Positions.GetAll());
            return positionModels;
        }

        public void UpdatePosition(PositionViewModels positionModel)
        {
            Position positionEntityDB = dataBase.Positions.Get(positionModel.PositionId);
            positionEntityDB.PositionName = positionModel.PositionName;
            // Appointment appointmentEntity = Mapper.Map<Appointment>(appointmentModel);          
            dataBase.Positions.Update(positionEntityDB);
            dataBase.Save();
        }
    }
}
