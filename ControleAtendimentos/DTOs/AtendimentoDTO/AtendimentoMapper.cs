using ControleAtendimentos.Models;

namespace ControleAtendimentos.DTOs.AtendimentoDTO
{
    public class AtendimentoMapper
    {
        public AtendimentoDTOResponse toDTO(AtendimentoModel atendimento)
        {
            return new AtendimentoDTOResponse
            {
                id = atendimento.id,
                ChamadoId = atendimento.ChamadoId,
                dataHoraInicio = atendimento.dataHoraInicio.ToLocalTime(),
                dataHoraFim = atendimento.dataHoraFim.HasValue
                    ? atendimento.dataHoraFim.Value.ToLocalTime()
                    : null,
                tempoTotal = atendimento.tempoTotal
            };
        }

        public AtendimentoModel toModel(AtendimentoDTOResponse atendimento)
        {
            return new AtendimentoModel
            {
                id = atendimento.id,
                ChamadoId = atendimento.ChamadoId,
                dataHoraInicio = atendimento.dataHoraInicio.ToUniversalTime(),
                dataHoraFim = atendimento.dataHoraFim.HasValue
                    ? atendimento.dataHoraFim.Value.ToUniversalTime()
                    : null,
                tempoTotal = atendimento.tempoTotal
            };
        }

        public AtendimentoModel toModel(AtendimentoDTORequest atendimentoDTO)
        {
            return new AtendimentoModel
            {
                dataHoraInicio = atendimentoDTO.dataHoraInicio,
                ChamadoId = atendimentoDTO.chamadoId
            };
        }
    }
}