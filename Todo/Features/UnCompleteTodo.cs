using Nancy;
using Nancy.ModelBinding;
using TodoApp.Todo.Models;

namespace TodoApp.Todo.Features
{
    public class UnCompleteTodo : NancyModule 
    {
        public UnCompleteTodo() : base("/todos")
        {
            Put("/{TodoId:Guid}/uncomplete", args => 
            {
                TodoDataModel todo = TodoQuery.GetTodo(args.TodoId);
                todo.Complete = false;
                return HttpStatusCode.OK;
            });
        }
        
    }

}