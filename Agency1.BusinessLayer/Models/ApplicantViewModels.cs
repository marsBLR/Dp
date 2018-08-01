using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.DataLayer.Entities;
using System.Collections.ObjectModel;

namespace Agency1.BusinessLayer.Models
{
    public class ApplicantViewModels
    {
        public int ApplicantId { get; set; }
        public string LastNameAp { get; set; }
        public string NameAp { get; set; }
        public string PatronymicAp { get; set; }
        public DateTime DateBirth { get; set; }
        public Gender Gender { get; set; }
        public Education Education { get; set; }
        public decimal EstimatedSalary { get; set; }
        public string OtherInformation { get; set; }
        public DateTime DateFilling { get; set; }

        //навигационные свойство
        public int PositionId { get; set; }
        public PositionViewModels Position { get; set; }

        public int AgentId { get; set; }
        public AgentViewModels Agent { get; set; }
        //public Positions Position { get; set; }

        public ObservableCollection<DealViewModels> Deals { get; set; }
     //   public ObservableCollection<AgentViewModels> Agentss { get; set; }
    }
}