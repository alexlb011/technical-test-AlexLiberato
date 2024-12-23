namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities
{
    public class Client
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public bool Sexo { get; set; }
        public decimal LimiteCompra { get; set; }
    }
}
