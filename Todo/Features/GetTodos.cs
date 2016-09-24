using Nancy;

namespace TodoApp.Todo.Features
{
    public class GetTodos : NancyModule 
    {
        public GetTodos() : base("/todo")
        {
            Get("/", args => TodoQuery.Todos);
        }
    }

}