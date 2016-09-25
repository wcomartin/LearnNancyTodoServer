using Nancy;
using Nancy.ModelBinding;
using TodoApp.Todo.Models;

namespace TodoApp.Todo.Features
{
    public class CompleteTodo : NancyModule 
    {
        public CompleteTodo() : base("/todos")
        {
            Put("/{TodoId:Guid}/complete", args => 
            {
                TodoDataModel todo = TodoQuery.GetTodo(args.TodoId);
                todo.Complete = true;
                return HttpStatusCode.OK;
            });
        }

    }

}