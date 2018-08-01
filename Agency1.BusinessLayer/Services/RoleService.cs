using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency1.BusinessLayer.Interfaces;
using Agency1.DataLayer.Entities;
using Agency1.BusinessLayer.Models;
using Agency1.DataLayer.Interfases;
using Agency1.DataLayer.Repositories;
using AutoMapper;
using System.Collections.ObjectModel;

namespace Agency1.BusinessLayer.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork dataBase;
        public RoleService(IUnitOfWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public RoleViewModels Get(int id)
        {
            var roleEntity = dataBase.Roles.Get(id);
            RoleViewModels roleModel = Mapper.Map<RoleViewModels>(roleEntity);
            return roleModel;
        }

        public ObservableCollection<RoleViewModels> GetAll()
        {
            Mapper.Reset();
             Mapper.Initialize(cfg =>
             {
                 cfg.CreateMap<Role, RoleViewModels>();
             });
             var roleModels = Mapper.Map<ObservableCollection<RoleViewModels>>(dataBase.Roles.GetAll());
             return roleModels;
        }
    }
}
