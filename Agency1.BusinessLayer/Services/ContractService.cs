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
    public class ContractService : IContractService
    {
        IUnitOfWork dataBase;
        public ContractService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public void CreateContract(ContractViewModel contractModel)
        {           
            Contract contractEntityDB = dataBase.Contracts.Get(contractModel.ContractId);
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<ContractViewModel, Contract>());
            var contractEntity = Mapper.Map<Contract>(contractModel);
            dataBase.Contracts.Create(contractEntity);
            dataBase.Save();           
        }

        public void CreatePaymentAccount(int ContractId, PaymentAccountViewModel paymentaccount)
        {
            var contract = dataBase.Contracts.Get(ContractId);
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<PaymentAccountViewModel, PaymentAccount>());
            var c = Mapper.Map<PaymentAccount>(paymentaccount);
            contract.PaymentAccounts.Add(c);
            dataBase.Save();
            /* var employer = dataBase.Employers.Get(EmployerId);
            Mapper.Reset();
            // Конфигурировани AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<VacancieViewModels, Vacancie>());
            // Отображение объекта EmployerViewModel на объект Employer
            var e = Mapper.Map<Vacancie>(vacancie);
            //Добавить вакансию
            employer.Vacancies.Add(e);
            // Сохранить изменения
            dataBase.Save();*/
        }

        public void DeleteContract(int contractId)
        {          
            dataBase.Contracts.Delete(contractId);
            dataBase.Save();
        }

        public void DeletePaymentAccount(int paymentaccount)
        {
            throw new NotImplementedException();
        }

        public ContractViewModel Get(int id)
        {
            var contractEntity = dataBase.Contracts.Get(id);
            ContractViewModel contractModel = Mapper.Map<ContractViewModel>(contractEntity);
            return contractModel;
        }

        public ObservableCollection<ContractViewModel> GetAll()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Contract, ContractViewModel>();
                cfg.CreateMap<Employer, EmployerViewModels>();
                cfg.CreateMap<Agent, AgentViewModels>();
                cfg.CreateMap<PaymentAccount, PaymentAccountViewModel>();
            });
            var contractModel = Mapper.Map<ObservableCollection<ContractViewModel>>(dataBase.Contracts.GetAll());
            return contractModel;
        }

        public void UpdateContract(ContractViewModel contract)
        {
            throw new NotImplementedException();
        }

        public void UpdatePaymentAccount(PaymentAccountViewModel paymentaccount)
        {
            throw new NotImplementedException();
        }
    }
}
