using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;
using System.Collections.ObjectModel;

namespace Agency1.BusinessLayer.Models
{
   public class AgentViewModels
    {
        public int AgentId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string LastNameAgent { get; set; }
        public string NameAgent { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        //навигационные свойство
        //public List<Deal> Deals { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }


        //навигационные свойство
        //public ObservableCollection<DealViewModels> Deals { get; set; }
        public ObservableCollection<ApplicantViewModels> Applicants { get; set; }
    }
}
