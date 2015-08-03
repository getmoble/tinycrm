using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using System;
using System.Collections.Generic;

namespace CRMLite.Data.Data.Seeders
{
    public static class CRMToDoSeeder
    {
        public static void Seed(DataContext context)
        {
            var toDos = new List<CRMToDo>
            {
                new CRMToDo{StartDate=Convert.ToDateTime("1/6/2015"),EndDate=Convert.ToDateTime("1/6/2015"),DueDate=Convert.ToDateTime("1/6/2015"),IsRecurring=true,Title="New Work",CreatedBy=1,Time=Convert.ToDateTime("5:00")},
                new CRMToDo{StartDate=Convert.ToDateTime("1/6/2015"),EndDate=Convert.ToDateTime("1/6/2015"),DueDate=Convert.ToDateTime("1/6/2015"),IsRecurring=true,Title="New Work",CreatedBy=1,Time=Convert.ToDateTime("5:00")},
                new CRMToDo{StartDate=Convert.ToDateTime("1/6/2015"),EndDate=Convert.ToDateTime("1/6/2015"),DueDate=Convert.ToDateTime("1/6/2015"),IsRecurring=true,Title="New Work",CreatedBy=1,Time=Convert.ToDateTime("5:00")},
                new CRMToDo{StartDate=Convert.ToDateTime("1/6/2015"),EndDate=Convert.ToDateTime("1/6/2015"),DueDate=Convert.ToDateTime("1/6/2015"),IsRecurring=true,Title="New Work",CreatedBy=1,Time=Convert.ToDateTime("5:00")}
            };
            toDos.ForEach(s => context.CRMToDos.Add(s));
            context.SaveChanges();
            var toDoMaps = new List<CRMToDoMap>
            {
                new CRMToDoMap{ToDoId=1,EntityType=CRMEntityType.Lead,CreatedBy=1},
                new CRMToDoMap{ToDoId=2,EntityType=CRMEntityType.Lead,CreatedBy=1},
                new CRMToDoMap{ToDoId=3,EntityType=CRMEntityType.Lead,CreatedBy=2},
                new CRMToDoMap{ToDoId=1,EntityType=CRMEntityType.Account,CreatedBy=1},
                new CRMToDoMap{ToDoId=1,EntityType=CRMEntityType.Account,CreatedBy=1},
                new CRMToDoMap{ToDoId=1,EntityType=CRMEntityType.Account,CreatedBy=2}
            };
            toDoMaps.ForEach(s => context.CRMToDoMaps.Add(s));
            context.SaveChanges();
        }
    }
}
