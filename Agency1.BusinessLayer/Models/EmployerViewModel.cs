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
        public string NameEmployer { get; set; }
        public string Industry { get; set; }
        public string AddressEmployer { get; set; }
        public int Phone { get; set; }
        public string FullNameEmployers { get; set; }

        public ObservableCollection<VacancieViewModels> Vacancies { get; set; }
    }
}

