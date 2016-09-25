using Nancy;

namespace TodoApp.Todo.Features
{
    public class GetTodos : NancyModule 
    {
        public GetTodos() : base("/todos")
        {
            Get("/", args => TodoQuery.GetTodos());
        }
    }

}