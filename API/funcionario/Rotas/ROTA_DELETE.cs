using FUNCIONARIO.Models;

public static class Rota_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        app.MapDelete("/api/funcionarios/{id}", async (int id, FuncionarioContext context) =>
        {
            var funcionario = await context.Funcionarios.FindAsync(id);
            if (funcionario is null) return Results.NotFound();

            context.Funcionarios.Remove(funcionario);
            await context.SaveChangesAsync();
            return Results.Ok();
        });
    }
}