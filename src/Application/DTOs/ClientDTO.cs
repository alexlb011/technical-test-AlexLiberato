namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Application.DTOs
{
    public class ClientDTO
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public bool Sexo { get; set; }
        public decimal LimiteCompra { get; set; }
    }
}