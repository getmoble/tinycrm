using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.Services
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
        public ToDo CreateToDo(ToDoModel toDoModel)
        {
            if (toDoModel != null)
            {
                var toDo = new ToDo
                {
                    DueDate = toDoModel.DueDate,
                    IsRecurring = toDoModel.IsRecurring,
                    Time = toDoModel.Time,
                    Title = toDoModel.Title,
                    EventForId = toDoModel.EventForId,
                    CreatedBy = toDoModel.CreatedBy
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

        public ToDo GetToDo(long id)
        {
            var todo = _toDoRepository.Get(id);
            return todo;
        }
        public IList<ToDo> GetAllToDos()
        {
            return _toDoRepository.GetAll().ToList();
        }

        public SearchResult<ToDo> Search(ToDoSearchFilter searchargument, int pagesize, int count)
        {
            return _toDoRepository.SearchToDo(searchargument, pagesize, count);
        }
        public bool DeleteToDo(long id)
        {
            var todo = _toDoRepository.Get(id);
            {
                todo.DeletedOn = DateTime.Now;
            }
            _iUnitOfWork.Commit();
            return true;
        }
    }
}
