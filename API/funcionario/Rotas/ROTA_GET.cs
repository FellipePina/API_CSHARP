using Microsoft.EntityFrameworkCore;
using FUNCIONARIO.Models;

namespace FUNCIONARIO.Rotas
{
    public static class Rota_GET
    {
        public static void MapGetRoutes(this WebApplication app)
        {
            app.MapGet("/api/funcionarios", async (FuncionarioContext context) =>
            {
                var funcionarios = await context.Funcionarios.ToListAsync();
                return Results.Ok(funcionarios);
            });

            app.MapGet("/api/funcionarios/{id}", async (int id, FuncionarioContext context) =>
            {
                var funcionario = await context.Funcionarios.FindAsync(id);
                return funcionario is not null ? Results.Ok(funcionario) : Results.NotFound();
            });
        }
    }
}