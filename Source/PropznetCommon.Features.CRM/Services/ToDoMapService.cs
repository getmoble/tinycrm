using System;
using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.ToDoMap;

namespace PropznetCommon.Features.CRM.Services
{
    public class ToDoMapService:IToDoMapService
    {
        readonly IToDoMapRepository _toDoMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public ToDoMapService(IToDoMapRepository toDoMapRepository, IUnitOfWork iUnitOfWork)
        {
            _toDoMapRepository = toDoMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public CRMToDoMap CreateToDoMap(ToDoMapModel toDOMapModel)
        {
            var toDoMap=new CRMToDoMap{
                EntityType = toDOMapModel.EntityType,
                ToDoId = toDOMapModel.ToDoId,
                CreatedByUserId=toDOMapModel.CreatedBy
            };
            var createToDoMap=_toDoMapRepository.Create(toDoMap);
            _iUnitOfWork.Commit();
            return createToDoMap;
        }
        public IList<CRMToDoMap> GetToDosByUserId(long userId, IList<int> permissionCodes)
        {
     
               return _toDoMapRepository.GetToDosByUserId(userId);
    
        }
        public IList<CRMToDoMap> GetAllToDoMapsByEntityTypeAndUserId(CRMEntityType entityType, long userId)
        {
            return _toDoMapRepository.GetAllToDoMapsByEntityTypeAndUserId(entityType, userId);
        }
        public bool DeleteTodoMap(long id)
        {
            _toDoMapRepository.Delete(id);
            return true;
        }
    }
}