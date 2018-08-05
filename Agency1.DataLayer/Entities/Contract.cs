using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency1.DataLayer.Entities
{
    public class Contract
    {
        public Contract()
        {
            PaymentAccounts = new List<PaymentAccount>();
        }
        public int ContractId { get; set; }
        public DateTime DateOfContract { get; set; }
        public StatusContract StatusContract { get; set; }
        public int Sum { get; set; }
        public Currency Сurrency { get; set; }
        public int Discount { get; set; }
        public int AgentId { get; set; }
        public int EmployerId { get; set; }

        public Employer Employer { get; set; }
        public Agent Agent { get; set; }
        public List<PaymentAccount> PaymentAccounts { get; set; }


    }
    public enum StatusContract
    {
        открыт,
        закрыт
    }
    public enum Currency
    {
        BYN/*,RUB,USD,EUR*/
    }
}
