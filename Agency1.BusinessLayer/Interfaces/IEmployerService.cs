using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Agency1.BusinessLayer.Models;

namespace Agency1.BusinessLayer.Interfaces
{
    public interface IEmployerService
    {
        ObservableCollection<EmployerViewModels> GetAll();
        EmployerViewModels Get(int id);
        void AddVacancyToEmployer(int EmployerId, VacancieViewModels vacancie);
        void RemoveEmployerFromVacancy(int employertId, int vacancyId);
        void CreateEmployer(EmployerViewModels employer);
        void DeleteEmployer(int employerId);
        void UpdateEmployer(EmployerViewModels employer);
    }
}
