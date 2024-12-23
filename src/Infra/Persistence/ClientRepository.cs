using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Infra.Persistence
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Clients
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id) ;
        }

        public async Task AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task<Client?> UpdateAsync(Client client, Client clientDataToUpdate)
        {
            client.Nome = clientDataToUpdate.Nome;
            client.DataNascimento = clientDataToUpdate.DataNascimento;
            client.LimiteCompra = clientDataToUpdate.LimiteCompra;
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(int id)
        {
            var client = await GetByIdAsync(id) ?? throw new Exception($"Cliente nao foi encontrado");
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
