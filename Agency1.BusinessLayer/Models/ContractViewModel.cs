using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;
using System.Collections.ObjectModel;

namespace Agency1.BusinessLayer.Models
{
    public class ContractViewModel
    {       
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
        public ObservableCollection<PaymentAccount> PaymentAccount { get; set; }


    }
 
}

