using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Todo.Models;

namespace TodoApp.Todo
{
    public class TodoQuery 
    {
        private static IList<TodoDataModel> Todos = new List<TodoDataModel>();

        public static IList<TodoDataModel> GetTodos()
        {
            return TodoQuery.Todos.OrderBy(t => t.Order).ToList();
        }

        public static TodoDataModel GetTodo(Guid Id)
        {
            return (from TodoDataModel todo in TodoQuery.Todos where todo.Id == Id select todo).FirstOrDefault();
        }

        public static void AddTodo(TodoDataModel todo)
        {
            TodoQuery.Todos.Add(todo);
        }

        public static void RemoveTodo(TodoDataModel todo)
        {
            TodoQuery.Todos.Remove(todo);
        }

        public static int GetNextOrder() 
        {
            return (from TodoDataModel t in TodoQuery.Todos 
                    orderby t.Order descending
                    select t.Order).FirstOrDefault() + 1;
        }
    }
}