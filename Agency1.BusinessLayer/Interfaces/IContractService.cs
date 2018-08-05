using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Agency1.BusinessLayer.Models;

namespace Agency1.BusinessLayer.Interfaces
{
    public interface IContractService
    {
        ObservableCollection<ContractViewModel> GetAll();
        ContractViewModel Get(int id);
        void CreateContract(ContractViewModel contract);
        void DeleteContract(int contractId);
        void UpdateContract(ContractViewModel contract);
        void CreatePaymentAccount(int ContractId, PaymentAccountViewModel paymentaccount);
        void DeletePaymentAccount(int paymentaccount);
        void UpdatePaymentAccount(PaymentAccountViewModel paymentaccount);
        //ObservableCollection<AgentViewModels> GetAll();
        //COntractViewModels Get(int id);
        //void AddAgentToDeal(int dealsId, DealViewModels deal);
        //void RemoveAgentFromDeal(int agentId, int dealsId);
        //void CreateAgent(AgentViewModels agent);
        //void DeleteAgent(int agentId);
        //void UpdateAgent(AgentViewModels agent);
    }
}
