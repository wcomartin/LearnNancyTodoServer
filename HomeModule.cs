using Nancy;
namespace TodoApp
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Hello World, it's Nancy on .NET Core");
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}