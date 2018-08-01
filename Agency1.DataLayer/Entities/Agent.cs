using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Agency1.DataLayer.Entities
{
   public class Agent
    {
        public Agent()
        {
            //Deals = new List<Deal>();
            Applicants = new List<Applicant>();
        }
       
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
        public List<Applicant> Applicants { get; set; }
    }
}
