using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Agency1.BusinessLayer.Models;

namespace Agency1.BusinessLayer.Interfaces
{
    public interface IPositionService
    {
        ObservableCollection<PositionViewModels> GetAll();
        PositionViewModels Get(int id);
        //void AddApplicantToDeal(int dealsId, ApplicantsViewModels applicant);
        //void RemoveApplicantFromDeal(int applicantId, int dealsId);
        void CreatePosition(PositionViewModels position);
        void DeletePosition(int positionId);
        void UpdatePosition(PositionViewModels position);
    }
}
