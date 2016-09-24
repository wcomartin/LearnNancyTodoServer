using System;
using System.Linq;
using Nancy;

using TodoApp.Todo.Models;

namespace TodoApp.Todo.Features
{
    public class GetTodo : NancyModule 
    {
        public GetTodo() : base("/todo")
        {
            Get("/{TodoId:int}", args => GetTodoById(args.TodoId));
        }

        public TodoDataModel GetTodoById(Guid Id)
        {
            return (from TodoDataModel todo in TodoQuery.Todos where todo.Id == Id select todo).FirstOrDefault();
            // return TodoQuery.Todos.Find(item => item.Id == Id);
        }

        
    }

}