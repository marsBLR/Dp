using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Agency1.BusinessLayer.Models;

namespace Agency1.BusinessLayer.Interfaces
{
    public interface IApplicantService
    {

        ObservableCollection<ApplicantViewModels> GetAll();
        ApplicantViewModels Get(int id);
        void AddApplicantToAgent(int agentId, ApplicantViewModels applicant);
        void RemoveApplicantFromAgent(int applicantId, int agentsId);
        void CreateApplicant(ApplicantViewModels applicant);
        void DeleteApplicant(int applicantId);
        void UpdateApplicant(ApplicantViewModels applicant);
        void AddDeal(ApplicantViewModels applicantmodel, DealViewModels dealmodel, VacancieViewModels vacanciemodel);
    }
}
