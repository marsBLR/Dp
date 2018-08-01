using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Agency1.BusinessLayer.Models;

namespace Agency1.BusinessLayer.Interfaces
{
    public interface IRoleService
    {
        ObservableCollection<RoleViewModels> GetAll();
        RoleViewModels Get(int id);
        
    }
}
