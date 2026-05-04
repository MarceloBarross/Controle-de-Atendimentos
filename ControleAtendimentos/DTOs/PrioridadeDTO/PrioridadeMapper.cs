using ControleAtendimentos.Models;
namespace ControleAtendimentos.DTOs.PrioridadeDTO
{
    public class PrioridadeMapper
    {
        public PrioridadeDTOResponse toDTO(PrioridadeModel prioridade)
        {
            return new PrioridadeDTOResponse
            {
                id = prioridade.id,
                nome = prioridade.nome,
                tempoEstimado = prioridade.tempoEstimado.ToString(),
            };
        }

        public PrioridadeModel toModel(PrioridadeDTORequest prioridadeDTO)
        {
            return new PrioridadeModel {

                nome = prioridadeDTO.nome,

                tempoEstimado = TimeSpan.Parse(prioridadeDTO.tempoEstimado)
            };
        }

        public PrioridadeModel toModel(PrioridadeDTOResponse prioridadeDTO)
        {
            return new PrioridadeModel
            {
                id = prioridadeDTO.id,
                nome = prioridadeDTO.nome,
                tempoEstimado = TimeSpan.Parse(prioridadeDTO.tempoEstimado)

            };
        }
    }
}
