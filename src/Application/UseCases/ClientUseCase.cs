using System.Text.Json;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Application.Validators;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Interfaces;

namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Application.UseCases
{
    public class ClientUseCase
    {
        private readonly IClientRepository _repository;

        public ClientUseCase(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Client>> GetAllClientsAsync(int pageNumber = 10, int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 10) pageSize = 10;
            return (List<Client>)await _repository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<string?> GetClientByIdAsync(int id)
        {
            try
            {
                Client client = await _repository.GetByIdAsync(id) ?? throw new Exception($"Cliente nao foi encontrado");
                return JsonSerializer.Serialize(new { message = "Cliente encontrado com sucesso.", client });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { message = "Ocorreu um erro inesperado.", erro = ex.Message });
                throw;
            }
        }

        public async Task<string> AddClientAsync(Client client)
        {
            ClientValidator clientValidator = new();
            Dictionary<string, List<string>> erros = clientValidator.ValidateCreateClient(client);
            try
            {
                if (erros.Count > 0) { throw new Exception("Erro de validação: " + JsonSerializer.Serialize(new { erros })); }
                await _repository.AddAsync(client);
                return JsonSerializer.Serialize(new { message = "Cliente adicionado com sucesso.", client });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { message = "Ocorreu um erro inesperado.", erro = ex.Message });
                throw;
            }
        }

        public async Task<string> UpdateClientAsync(int id, Client clientDataToUpdate)
        {
            ClientValidator clientValidator = new();
            Dictionary<string, List<string>> erros = clientValidator.ValidateCreateClient(clientDataToUpdate);
            try
            {
                if (erros.Count > 0) { throw new Exception("Erro de validação: " + JsonSerializer.Serialize(new { erros })); }
                Client client = await _repository.GetByIdAsync(id) ?? throw new Exception($"Cliente nao foi encontrado");
                var clientUpdated = await _repository.UpdateAsync(client, clientDataToUpdate);
                return JsonSerializer.Serialize(new { message = "Cliente atualizado com sucesso.", cliente = clientUpdated });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { message = "Ocorreu um erro inesperado.", err = ex.Message });
            }
        }

        public async Task<string> DeleteClientAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return JsonSerializer.Serialize(new { message = "Cliente deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { message = "Ocorreu um erro inesperado.", err = ex.Message });
            }
        }

    }
}

