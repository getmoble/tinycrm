using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Manager;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.Services
{
    public class ManagerService : IManagerService
    {
        readonly IManagerRepository _managerRepopsitory;
        readonly ICommunicationDetailRepository _communicationDetailRepository;
        readonly IPersonRepository _personRepositry;
        readonly IUnitOfWork _iUnitOfWork;
        public ManagerService(IManagerRepository managerRepopsitory,
            ICommunicationDetailRepository communicationDetailRepository,
            IPersonRepository personRepositry,
            IUnitOfWork iUnitOfWork)
        {
            _managerRepopsitory = managerRepopsitory;
            _communicationDetailRepository = communicationDetailRepository;
            _personRepositry = personRepositry;
            _iUnitOfWork = iUnitOfWork;
        }
        public IList<Manager> GetAllManagers()
        {
            return _managerRepopsitory.GetAllManagers().ToList();
        }
        public IList<Manager> GetAllManagersById(IList<long> managerId)
        {
            return _managerRepopsitory.GetAllManagersById(managerId);
        }
        public Manager GetManagerById(long managerId)
        {
            return _managerRepopsitory.GetManager(managerId);
        }
        public Manager CreateManager(ManagerModel ManagerModel)
        {
            var person = new Person
            {
                Address = ManagerModel.Address,
                CountryId=ManagerModel.CountryId,
                City=ManagerModel.City,
                State=ManagerModel.State,
                FirstName = ManagerModel.FirstName,
                Email = ManagerModel.Email,
                LastName = ManagerModel.LastName,
                PhoneNo = ManagerModel.Phone,
                Zip = ManagerModel.Zip,
            };
            var createdPerson = _personRepositry.Create(person);
            _iUnitOfWork.Commit();
            var manager = new Manager
            {
                Mobile=ManagerModel.Mobile,
                RoleId = ManagerModel.RoleId,
                PersonId = createdPerson.Id
            };
            var createdManager= _managerRepopsitory.Create(manager);
            _iUnitOfWork.Commit();
            return createdManager;
        }
        public Manager UpdateManager(ManagerModel managerModel)
        {
            var person = _personRepositry.GetPersonById(managerModel.PersonId);
            person.Address = managerModel.Address;
            person.Zip = managerModel.Zip;
            person.UpdatedOn = DateTime.UtcNow;
            person.CountryId = managerModel.CountryId;
            person.City = managerModel.City;
            person.State = managerModel.State;
            person.Email = managerModel.Email;
            person.FirstName = managerModel.FirstName;
            person.LastName = managerModel.LastName;
            person.PhoneNo = managerModel.Phone;
            _personRepositry.Update(person);
            _iUnitOfWork.Commit();

            var manager = _managerRepopsitory.Get(managerModel.Id);
            manager.PersonId = person.Id;
            manager.Mobile = managerModel.Mobile;
            manager.RoleId = managerModel.RoleId;
            manager.UpdatedOn = DateTime.UtcNow;
            _managerRepopsitory.Update(manager);
            _iUnitOfWork.Commit();
            return manager;
        }
        public bool DeleteManager(long managerId)
        {
            var result = _managerRepopsitory.DeleteManager(managerId);
            _iUnitOfWork.Commit();
            return result;
        }
        public SearchResult<Manager> SearchManagers(ManagerSearchFilter searchFilter, int pagesize, int count, long userId)
        {
            throw new NotImplementedException();
        }
    }
}