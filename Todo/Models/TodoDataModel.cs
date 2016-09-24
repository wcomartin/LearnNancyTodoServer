using System;

namespace TodoApp.Todo.Models
{
    public class TodoDataModel 
    {
        public Guid Id {get; set;}
        public string Title {get; set;}
        public int Order {get; set;}
        public bool Complete {get; set;}

        public TodoDataModel(string Title, int Order)
        {
            this.Id = Guid.NewGuid();
            this.Title = Title;
            this.Order = Order;
        }
    }
}