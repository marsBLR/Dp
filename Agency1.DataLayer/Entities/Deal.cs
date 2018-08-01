using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency1.DataLayer.Entities
{
   public class Deal
    {
        public int DealId { get; set; }
        public DateTime DateCompilation { get; set; }
        public decimal Commission { get; set; }
        public Paid Paid { get; set; }
        public DateTime DatePaid { get; set; }

        //навигационные свойства

        //public int AgentId { get; set; }

        //public Agent Agent { get; set; }

        //public int VacancieId { get; set; }

        public virtual Vacancie Vacancie { get; set; }

        public int ApplicantId { get; set;}
        public Applicant Applicant { get; set; }

      //  public List<Applicant> Applicants { get; set; }
        //public List<Agent> Agents { get; set; }       
    }
        public enum Paid
        {
            да,
            нет
        }  
}
