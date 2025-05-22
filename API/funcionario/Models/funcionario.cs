namespace FUNCIONARIO.Models
{

    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
        public int CargaHorariaSemanal { get; set; }
        public float Salario { get; set; }
        public string EstadoCivil { get; set; }
        public float GastosPorMes { get; set; }
    }
}