using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;
using System.Collections.ObjectModel;

namespace Agency1.BusinessLayer.Models
{
    public class PaymentAccountViewModel
    {
        public int PaymentAccountId { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public int SumPayment { get; set; }
        public TypeOfCalculation TypeOfCalculation { get; set; }
        public StatusPayment StatusPayment { get; set; }
        public DateTime? DateOfPayment { get; set; }

        public int ContractId { get; set; }


        public Contract Contracts { get; set; }
    }
}
