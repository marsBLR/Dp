using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Agency1.BusinessLayer.Models
{
    public class EmployerViewModels
    {
        public int EmployerId { get; set; }
        public string LastNameEmployer { get; set; }
        public string NameEmployer { get; set; }
        public string PatronymicEmployer { get; set; }
        //  public string Industry { get; set; }
        public string AddressEmployer { get; set; }
        public long Phone { get; set; }
     //   public string FullNameEmployers { get; set; }

        public ObservableCollection<VacancieViewModels> Vacancies { get; set; }
    }
}

