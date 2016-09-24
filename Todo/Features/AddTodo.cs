using Nancy;
using Nancy.ModelBinding;
using TodoApp.Todo.Models;

namespace TodoApp.Todo.Features
{
    public class AddTodo : NancyModule 
    {
        public AddTodo() : base("/todos")
        {
            Post("/create", args => 
            {
                var post = this.Bind<CreateModel>();
                var nextOrder = TodoQuery.GetNextOrder();
                var todo = new TodoDataModel(post.Title, nextOrder);
                TodoQuery.Todos.Add(todo);
                return HttpStatusCode.OK;
            });
        }

        public class CreateModel
        {
            public string Title {get; set;}
        }

        
    }

}