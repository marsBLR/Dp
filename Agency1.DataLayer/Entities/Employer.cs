using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency1.DataLayer.Entities
{
   public class Employer
    {
        public Employer()
        {
            Vacancies = new List<Vacancie>();
            Contracts = new List<Contract>();
        }      
        public int EmployerId { get; set; }
        public string LastNameEmployer { get; set; }
        public string NameEmployer { get; set; }
        public string PatronymicEmployer { get; set; }
     //   public string Industry { get; set; }
        public string AddressEmployer { get; set; }
        public long Phone { get; set; }
     //   public string FullNameEmployers { get; set; }

        //навигационные свойство
        public List<Vacancie> Vacancies { get; set; }
        public List<Contract> Contracts { get; set; }
    }   
}
