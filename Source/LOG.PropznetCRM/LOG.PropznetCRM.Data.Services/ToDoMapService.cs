using Common.Data.Interfaces;
using LOG.PropznetCRM.Data.Core;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;
using LOG.PropznetCRM.Data.Model.ToDoMap;
using System;
using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Services
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
        public ToDoMap CreateToDoMap(ToDoMapModel toDOMapModel)
        {
            var toDoMap=new ToDoMap{
                EntityType = toDOMapModel.EntityType,
                ToDoId = toDOMapModel.ToDoId,
                CreatedBy=toDOMapModel.CreatedBy
            };
            var createToDoMap=_toDoMapRepository.Create(toDoMap);
            _iUnitOfWork.Commit();
            return createToDoMap;
        }

        public IList<ToDoMap> GetToDosByUserId(long userId, IList<int> permissionCodes)
        {
            if (PermissionChecker.CheckPermission(permissionCodes, PermissionCodes.ViewAccount))
            {
               return _toDoMapRepository.GetToDosByUserId(userId);
            }
            
            throw new UnauthorizedAccessException();
        }

        public IList<ToDoMap> GetAllToDoMapsByEntityTypeAndUserId(EntityType entityType, long userId)
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