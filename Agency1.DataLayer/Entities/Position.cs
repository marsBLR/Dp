using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency1.DataLayer.Entities
{
   public class Position
    {
        public Position()
        {
            //Applicants = new List<Applicant>();
            //Vacancies = new List<Vacancie>();
        }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        //навигационные свойство
        //public List<Applicant> Applicants { get; set; }
        //public List<Vacancie> Vacancies { get; set; }
    }
}
