using FUNCIONARIO.Models;

public static class Rota_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        app.MapPost("/api/funcionarios", async (Funcionario funcionario, FuncionarioContext context) =>
        {
            context.Funcionarios.Add(funcionario);
            await context.SaveChangesAsync();
            return Results.Created($"/funcionario/{funcionario.Id}", funcionario);
        });
    }
}