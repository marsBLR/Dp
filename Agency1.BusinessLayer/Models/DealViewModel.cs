using System;
using System.Collections.ObjectModel;
using Agency1.DataLayer.Entities;
using Agency1.BusinessLayer.Models;

namespace Agency1.BusinessLayer.Models
{
    public class DealViewModels
    {
        public int DealId { get; set; }
        public DateTime DateCompilation { get; set; }
      
        public Paid Paid { get; set; }
        public DateTime DatePaid { get; set; }

        //public int AgentId { get; set; }
        public int ApplicantId { get; set; }

        //public int VacancieId { get; set; }
        public Vacancie Vacancie { get; set; }
        public Applicant Applicant { get; set; }
   
        //public AgentViewModels Aget { get; set; }
     
    }
}