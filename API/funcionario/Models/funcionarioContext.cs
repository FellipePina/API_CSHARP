using Microsoft.EntityFrameworkCore;

namespace FUNCIONARIO.Models
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}