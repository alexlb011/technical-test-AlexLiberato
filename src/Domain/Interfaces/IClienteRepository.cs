using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities;
namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync(int pageNumber, int pageSize);
        Task<Client?> GetByIdAsync(int id);
        Task AddAsync(Client client);
        Task<Client?> UpdateAsync(Client client, Client clientDataToUpdate);
        Task DeleteAsync(int id);
    }
}
