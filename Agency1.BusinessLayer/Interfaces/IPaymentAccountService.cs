using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Agency1.BusinessLayer.Models;

namespace Agency1.BusinessLayer.Interfaces
{
    public interface IPaymentAccountService
    {
        /* ObservableCollection<AgentViewModels> GetAll();
        AgentViewModels Get(int id);
        void AddAgentToDeal(int dealsId, DealViewModels deal);
        void RemoveAgentFromDeal(int agentId, int dealsId);
        void CreateAgent(AgentViewModels agent);
        void DeleteAgent(int agentId);
        void UpdateAgent(AgentViewModels agent);*/
        ObservableCollection<PaymentAccountViewModel> GetAll();
        PaymentAccountViewModel Get(int id);
        //void CreatePaymentAccount(PaymentAccountViewModel paymentaccount);
        //void DeletePaymentAccount(int paymentaccount);
        //void UpdatePaymentAccount(PaymentAccountViewModel paymentaccount);
    }
}
