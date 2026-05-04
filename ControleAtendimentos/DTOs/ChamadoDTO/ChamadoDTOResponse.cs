using ControleAtendimentos.DTOs.AtendimentoDTO;
using ControleAtendimentos.DTOs.PrioridadeDTO;
using ControleAtendimentos.Models.enums.StatusEnunm;

namespace ControleAtendimentos.DTOs.ChamadoDTO
{
    public class ChamadoDTOResponse
    {
        public int id { get; set; }
        public string descricao { get; set; }

        public string nomeSetor { get; set; }

        public PrioridadeDTOResponse prioridade { get; set; }

        public StatusEnum status { get; set; }

        public TimeSpan TempoTotalAtendimento { get; set; }

        public AtendimentoDTOResponse atendimento { get; set; }

        public bool passouTempoLimitePrioridade { get; set; }
    }
}
