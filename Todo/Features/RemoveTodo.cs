using Nancy;
using Nancy.ModelBinding;
using TodoApp.Todo.Models;

namespace TodoApp.Todo.Features
{
    public class RemoveTodo : NancyModule 
    {
        public RemoveTodo() : base("/todos")
        {
            Delete("/{TodoId:Guid}", args => 
            {
                TodoDataModel todo = TodoQuery.GetTodo(args.TodoId);
                TodoQuery.RemoveTodo(todo);
                return HttpStatusCode.OK;
            });
        }
        
    }

}