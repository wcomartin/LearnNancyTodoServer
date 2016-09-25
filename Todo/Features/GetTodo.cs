using System;
using System.Linq;
using Nancy;

using TodoApp.Todo.Models;

namespace TodoApp.Todo.Features
{
    public class GetTodo : NancyModule 
    {
        public GetTodo() : base("/todos")
        {
            Get("/{TodoId:int}", args => TodoQuery.GetTodo(args.TodoId));
        }
        
    }

}