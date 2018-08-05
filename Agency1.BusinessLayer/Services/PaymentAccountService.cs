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
    public class PaymentAccountService : IPaymentAccountService
    {
        IUnitOfWork dataBase;
        public PaymentAccountService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public PaymentAccountViewModel Get(int id)
        {
            var paymentAccountEntity = dataBase.PaymentAccounts.Get(id);
            PaymentAccountViewModel paymentAccountModel = Mapper.Map<PaymentAccountViewModel>(paymentAccountEntity);
            return paymentAccountModel;
            
        }

        public ObservableCollection<PaymentAccountViewModel> GetAll()
        {
            
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PaymentAccount, PaymentAccountViewModel>();
                cfg.CreateMap<Contract, ContractViewModel>();

            });
            var paymentAccountModel = Mapper.Map<ObservableCollection<PaymentAccountViewModel>>(dataBase.PaymentAccounts.GetAll());
            return paymentAccountModel;
        }
    }
}
