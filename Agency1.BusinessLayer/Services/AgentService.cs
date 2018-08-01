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
    public class AgentService : IAgentService
    {
        IUnitOfWork dataBase;
        public AgentService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public void CreateAgent(AgentViewModels agentModel)
        {
            Agent agentEntityDB = dataBase.Agents.Get(agentModel.AgentId);           
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<AgentViewModels, Agent>());
            var agentEntity = Mapper.Map<Agent>(agentModel);
            //добавить агента
            dataBase.Agents.Create(agentEntity);
            //Сохранить изменения
            dataBase.Save();
        }

      
        public void DeleteAgent(int agentId)
        {
            dataBase.Agents.Delete(agentId);
            dataBase.Save();
        }

        public AgentViewModels Get(int id)
        {
            var agentEntity = dataBase.Agents.Get(id);
            AgentViewModels agentsModel = Mapper.Map<AgentViewModels>(agentEntity);
            return agentsModel;
        }

        public ObservableCollection<AgentViewModels> GetAll()
        {
            /* var appointmentModels = Mapper.Map<ObservableCollection<AppointmentViewModel>>(dataBase.Appointments.GetAll());
            return appointmentModels;*/
            // Конфигурирование AutoMapper
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Agent, AgentViewModels>();
                cfg.CreateMap<Role, RoleViewModels>();
                cfg.CreateMap<Applicant, ApplicantViewModels>();
            });
            var agentsModels = Mapper.Map<ObservableCollection<AgentViewModels>>(dataBase.Agents.GetAll());
            return agentsModels;
        }

        public void RemoveAgentFromDeal(int agentId, int dealsId)
        {
            throw new NotImplementedException();
        }

        public void AddAgentToDeal(int dealsId, DealViewModels deal)
        {
            throw new NotImplementedException();
        }
        public void UpdateAgent(AgentViewModels agentModel)
        {
            Agent agentEntityDB = dataBase.Agents.Get(agentModel.AgentId);
            // Appointment appointmentEntity = Mapper.Map<Appointment>(appointmentModel);
            agentEntityDB.LastNameAgent = agentModel.LastNameAgent;
            agentEntityDB.NameAgent = agentModel.NameAgent;
            agentEntityDB.Phone = agentModel.Phone;           

            dataBase.Agents.Update(agentEntityDB);
            dataBase.Save();
        }
    }
}
