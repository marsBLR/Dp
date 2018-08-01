using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;
using System.Collections.ObjectModel;

namespace Agency1.BusinessLayer.Models
{
   public class PositionViewModels
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        //навигационные свойство
        //public ObservableCollection<ApplicantViewModels> Applicants { get; set; }
        //public ObservableCollection<VacancieViewModels> Vacancies { get; set; }
    }
}
