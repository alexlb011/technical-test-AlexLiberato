using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities;
namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Application.DTOs

{
    public static class ClientMapper
    {
        public static Client MapToClient(ClientDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            return new Client
            {
                Nome = dto.Nome.Trim(),
                DataNascimento = dto.DataNascimento,
                Sexo = dto.Sexo,
                LimiteCompra = dto.LimiteCompra
            };
        }
    }

}