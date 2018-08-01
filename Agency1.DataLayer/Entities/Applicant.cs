using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency1.DataLayer.Entities
{
   public class Applicant
    {
        //public Applicant()
        //{
        //    Deals = new List<Deal>();
        //}
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
        public int AgentId { get; set; }     
      
        public Agent Agent { get; set; }
        public Position Position { get; set; }
        public List<Deal> Deals { get; set; }

    }
    public enum Gender
    {
        мужчина,
        женщина,
        любой
    }

    public enum Education
    {
        среднее,
        средне_специальное,
        высшее,
        без_образования
    }
}
