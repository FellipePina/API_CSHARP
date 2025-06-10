using Microsoft.EntityFrameworkCore;
using FUNCIONARIO.Models;
using FUNCIONARIO.Rotas;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco SQLite
builder.Services.AddDbContext<FuncionarioContext>(options =>
    options.UseSqlite("Data Source=funcionarios.db"));

// Configura o CORS para permitir qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

// Mapeia as rotas REST
app.MapGetRoutes();
app.MapPostRoutes();
app.MapDeleteRoutes();

//-------------------------------------------------------------------
//FRONT END
// Serve arquivos estáticos da pasta wwwroot
app.UseDefaultFiles();  // Procura por index.html automaticamente
app.UseStaticFiles();   // Permite servir arquivos da pasta wwwroot
//-------------------------------------------------------------------

// Popular o banco com dados iniciais, se estiver vazio
PopularBancoDeDados(app);

// Inicia a aplicação
app.Run();

void PopularBancoDeDados(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<FuncionarioContext>();

    context.Database.Migrate();

    if (!context.Funcionarios.Any())
    {
        var funcionariosInciais = new List<Funcionario>
        {
            new() { Nome = "Fellipe", Idade = 32, Sexo = "Masculino", Cpf = "067607224-80", Email = "fellipe@gmail.com",
            Celular = "4197990353", Cargo = "Gerente", Setor = "Contabilidade", CargaHorariaSemanal = 40, Salario = 7430,
            EstadoCivil = "Casado", GastosPorMes = 13250 },

            new() { Nome = "Mariana", Idade = 28, Sexo = "Feminino", Cpf = "123456789-00", Email = "mariana.silva@gmail.com",
            Celular = "11987543210", Cargo = "Analista de RH", Setor = "Recursos Humanos", CargaHorariaSemanal = 44, Salario = 4890,
            EstadoCivil = "Solteira", GastosPorMes = 3200 },

            new() { Nome = "Carlos", Idade = 35, Sexo = "Masculino", Cpf = "234567891-00", Email = "carlos.souza@gmail.com",
            Celular = "21981234567", Cargo = "Técnico de TI", Setor = "Tecnologia", CargaHorariaSemanal = 40, Salario = 5600,
            EstadoCivil = "Casado", GastosPorMes = 4700 },

            new() { Nome = "Ana Paula", Idade = 31, Sexo = "Feminino", Cpf = "345678912-00", Email = "ana.paula@gmail.com",
            Celular = "31999887766", Cargo = "Supervisora", Setor = "Vendas", CargaHorariaSemanal = 44, Salario = 6200,
            EstadoCivil = "Divorciada", GastosPorMes = 5100 },

            new() { Nome = "Ricardo", Idade = 42, Sexo = "Masculino", Cpf = "456789123-00", Email = "ricardo.lima@gmail.com",
            Celular = "41977778888", Cargo = "Engenheiro", Setor = "Projetos", CargaHorariaSemanal = 40, Salario = 9100,
            EstadoCivil = "Casado", GastosPorMes = 8500 },

            new() { Nome = "Maria", Idade = 28, Sexo = "Feminino", Cpf = "98765432100", Email = "maria@email.com",
            Celular = "98888-8888", Cargo = "Gerente", Setor = "RH", CargaHorariaSemanal = 40, Salario = 6000,
            EstadoCivil = "Casada", GastosPorMes = 3500 },

            new() { Nome = "Paulo Henrique", Idade = 29, Sexo = "Masculino", Cpf = "567890123-00", Email = "paulo.henrique@gmail.com",
            Celular = "41991122334", Cargo = "Analista Financeiro", Setor = "Financeiro", CargaHorariaSemanal = 40, Salario = 5200,
            EstadoCivil = "Solteiro", GastosPorMes = 2800 },

            new() {  Nome = "Fernanda Costa", Idade = 33, Sexo = "Feminino", Cpf = "678901234-00", Email = "fernanda.costa@gmail.com",
            Celular = "41992233445", Cargo = "Assistente Administrativo", Setor = "Administração", CargaHorariaSemanal = 44, Salario = 3900,
            EstadoCivil = "Casada", GastosPorMes = 2300 },

            new() {  Nome = "Lucas Martins", Idade = 27, Sexo = "Masculino", Cpf = "789012345-00", Email = "lucas.martins@gmail.com",
            Celular = "41993344556", Cargo = "Desenvolvedor", Setor = "TI", CargaHorariaSemanal = 40, Salario = 5800,
            EstadoCivil = "Solteiro", GastosPorMes = 3100 },

            new() {  Nome = "Juliana Souza", Idade = 30, Sexo = "Feminino", Cpf = "890123456-00", Email = "juliana.souza@gmail.com",
            Celular = "41994455667", Cargo = "Coordenadora de Marketing", Setor = "Marketing", CargaHorariaSemanal = 40, Salario = 6200,
            EstadoCivil = "Casada", GastosPorMes = 4000 }
        };
        context.Funcionarios.AddRange(funcionariosInciais);
        context.SaveChanges();
    }
}
