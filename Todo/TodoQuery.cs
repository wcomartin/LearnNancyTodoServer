using System.Collections.Generic;
using System.Linq;
using TodoApp.Todo.Models;

namespace TodoApp.Todo
{
    public class TodoQuery 
    {
        public static IList<TodoDataModel> Todos = new List<TodoDataModel>();

        public static int GetNextOrder() 
        {
            return (from TodoDataModel t in TodoQuery.Todos 
                    orderby t.Order descending
                    select t.Order).FirstOrDefault() + 1;
        }
    }
}