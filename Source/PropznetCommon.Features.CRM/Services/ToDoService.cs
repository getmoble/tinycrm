using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.ToDo;

namespace PropznetCommon.Features.CRM.Services
{
    public class ToDoService : IToDoService
    {
        readonly IToDoRepository _toDoRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public ToDoService(IToDoRepository toDoRepository, IUnitOfWork iUnitOfWork)
        {
            _toDoRepository = toDoRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public CRMToDo CreateToDo(ToDoModel toDoModel)
        {
            if (toDoModel != null)
            {
                var toDo = new CRMToDo
                {
                    DueDate = toDoModel.DueDate,
                    IsRecurring = toDoModel.IsRecurring,
                    Time = toDoModel.Time,
                    Title = toDoModel.Title,
                    EventForId = toDoModel.EventForId,
                    CreatedByUserId = toDoModel.CreatedBy
                };
                var todo = _toDoRepository.Create(toDo);
                _iUnitOfWork.Commit();
                return todo;
            }

            throw new Exception("No value Found");
        }
        public bool UpdateToDo(ToDoModel toDoModel)
        {
            if (toDoModel != null)
            {
                var toDo = _toDoRepository.Get(toDoModel.Id);
                toDo.DueDate = toDoModel.DueDate;
                toDo.IsRecurring = toDoModel.IsRecurring;
                toDo.Time = toDoModel.Time;
                toDo.Title = toDoModel.Title;
                toDo.EventForId = toDoModel.EventForId;
                _toDoRepository.Update(toDo);
                _iUnitOfWork.Commit();
                return true;
            }
            
            throw new Exception("NO value Found");
        }
        public CRMToDo GetToDo(long id)
        {
            var todo = _toDoRepository.Get(id);
            return todo;
        }
        public IList<CRMToDo> GetAllToDos()
        {
            return _toDoRepository.GetAll().ToList();
        }
        public SearchResult<CRMToDo> Search(ToDoSearchFilter searchargument, int pagesize, int count)
        {
            return _toDoRepository.SearchToDo(searchargument, pagesize, count);
        }
        public bool DeleteToDo(long id)
        {
            var todo = _toDoRepository.Get(id);
            {
                todo.DeletedOn = DateTime.UtcNow;
            }
            _iUnitOfWork.Commit();
            return true;
        }
    }
}