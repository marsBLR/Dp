using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency1.DataLayer.Entities
{
   public class Vacancie
    {
        //public Vacancie()
        //{
        //    Deals = new List<Deal>();
        //}
        public int VacancieId { get; set; }
        public Gender Gender { get; set; }
        public Education Education { get; set; }
        public string DrivingLicence { get; set; }
        public ForeignLanguage ForeignLanguage { get; set; }
        public decimal Salary { get; set; }
        public string WorkingConditions { get; set; }
        public DateTime DateOpen { get; set; }
        public DateTime? DateClose { get; set; }
        public OpenVacancy OpenVacancy { get; set; }

        //навигационные свойства
        public int EmployerId { get; set; }
        public int PositionId { get; set; }
        //[ForeignKey("Deal")]
        //public int? DealId { get; set; }
        public Employer Employer { get; set; }
        public virtual Position Position { get; set; }
        public Deal Deal { get; set; }
        
        //public virtual List<Deal> Deals { get; set; }
    }
    public enum OpenVacancy
    {
        да,
        нет
    }
    public enum ForeignLanguage
    {
        ENGLISH,
        GERMAN,
        FRENCH,
        нет
    } 
}
