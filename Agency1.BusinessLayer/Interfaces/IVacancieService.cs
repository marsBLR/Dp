using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Agency1.BusinessLayer.Models;

namespace Agency1.BusinessLayer.Interfaces
{
    public interface IVacancieService
    {
        ObservableCollection<VacancieViewModels> GetAll();
        VacancieViewModels Get(int id);
        void AddVacancyToDeal(int dealsId, VacancieViewModels vacancy);
        void RemoveVacancyFromDeal(int vacancyId, int dealsId);
        void CreateVacancy(VacancieViewModels vacancy);
        void DeleteVacancy(int vacancyId);
        void CloseVacancy(VacancieViewModels vacancy);
        void UpdateVacancy(VacancieViewModels vacancy);
        void CloseVacancy(DealViewModels dealModel);
    }
}
