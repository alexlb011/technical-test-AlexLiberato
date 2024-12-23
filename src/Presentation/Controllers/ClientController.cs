using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Application.DTOs;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Application.UseCases;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly ClientUseCase _useCase;

        public ClientController(ClientUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{page}/{pageSize}")]
        [SwaggerOperation(
            Summary = "Obtém todos os clientes",
            Description = "Este método retorna uma lista de clientes paginada com base nos parâmetros de página e tamanho da página."
        )]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var clients = await _useCase.GetAllClientsAsync(page, pageSize);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtém cliente por ID",
            Description = "Este método retorna um cliente específico com base no ID fornecido. Se o cliente não for encontrado, retorna um erro 404."
        )]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _useCase.GetClientByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adiciona um novo cliente",
            Description = "Este método permite adicionar um novo cliente. Os dados do cliente são passados no corpo da requisição como um DTO. Retorna uma resposta com o status da operação."
        )]
        public async Task<IActionResult> Add(ClientDTO clientDTO)
        {
            Client client = ClientMapper.MapToClient(clientDTO);
            string response = await _useCase.AddClientAsync(client);
            if (response.Contains("erros")) { return BadRequest(response); }
            return Ok(response);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualiza os dados de um cliente",
            Description = "Este método atualiza as informações de um cliente existente com base no ID fornecido. Os novos dados do cliente são passados no corpo da requisição como um DTO."
        )]
        public async Task<IActionResult> Update(int id, ClientDTO clientDTO)
        {
            Client clientData = ClientMapper.MapToClient(clientDTO);
            string response = await _useCase.UpdateClientAsync(id, clientData);
            if (response.Contains("erros")) { return BadRequest(response); }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Exclui um cliente",
            Description = "Este método exclui um cliente com base no ID fornecido. Retorna um status de sucesso ou erro dependendo do resultado da operação."
        )]
        public async Task<IActionResult> Delete(int id)
        {
            string response = await _useCase.DeleteClientAsync(id);
            if (response.Contains("erros")) { return BadRequest(response); }
            return Ok(response);
        }
    }
}
