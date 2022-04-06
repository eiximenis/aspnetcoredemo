using Microsoft.AspNetCore.Mvc;

namespace Net6Demo
{
    public static class HelloHandler
    {
        public static IResult Handle(int id, [FromServices] FooService svc)
        {
            var text = svc.Text;
            return Results.Ok(text.Length + " " + id);
        }
    }
}
