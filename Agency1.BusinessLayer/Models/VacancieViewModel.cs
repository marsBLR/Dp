using System;
using System.Collections.ObjectModel;
using Agency1.DataLayer.Entities;


namespace Agency1.BusinessLayer.Models
{
    public class VacancieViewModels
    {
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

        //gjcktl rjhhjn
        public int EmployerId { get; set; }
        public int PositionId { get; set; }

        public EmployerViewModels Employer { get; set; }
        // public Employers Employer { get; set; }
       
        public virtual PositionViewModels Position { get; set; }
        //  public Positions Position { get; set; }
        //public int? DealId { get; set; }
        public DealViewModels Deal { get; set; }
        //public virtual ObservableCollection<DealViewModels> Deals { get; set; }
    }
}