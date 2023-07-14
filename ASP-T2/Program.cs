using ASP_T2.Models;

namespace ASP_T2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");//// lambda expression

        //app.MapGet("/hello", (HttpRequest request) =>
        app.MapGet("/hello", (string name, int age) =>
        {
            //string? name = request.Query["name"];
            //return $"Hello, {name}. Age = {age}";
            return new PersonDTO(name, age);
        });

        app.MapGet("/bye/{name}", (string name) =>
        {
            return $"Bye, {name}";
        });

        app.MapGet("/person", (string? name) =>
        {
            var list = new List<PersonDTO>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new PersonDTO($"Person {i}", i * 10 + 1));
            }
            return list;
        });

        //app.MapPost("/person", (HttpRequest request) =>
        app.MapPost("/person", (PersonDTO p) =>
        {
            // Insert data

            //var conn = DBConnector.getConnection();
            //string sql = "";

            //var cmd = new SqlCommand(sql);
            //cmd.Parameters.Add();
            //int rowAffected = cmd.ExecuteNonQuery(cmd, conn);

            Person person = new Person();
            int i = person.Insert(p);
            return new { Message = "Insert Success", Rows = i };
        });

        app.MapDelete("/person/{id}", (int id) => {
            Person p = new Person();
            int i = p.Delete(id);
            return new { Message = "Delete Success", Rows = i };
        }); // xoa du lieu

        app.MapPut("/person/{id}", (PersonDTO p) => {
            Person person = new Person();
            int i = person.Update(p);
            return new { Message = "Update Success", Rows = i };
        }); // update du lieu

        app.Run();
        //app.Run("http://localhost:3000");
    }
}

