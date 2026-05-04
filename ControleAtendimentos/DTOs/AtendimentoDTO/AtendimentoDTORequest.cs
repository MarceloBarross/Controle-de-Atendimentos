using ControleAtendimentos.Models;

namespace ControleAtendimentos.DTOs.AtendimentoDTO
{
    public class AtendimentoDTORequest
    {
        public DateTime dataHoraInicio { get; set; }
        public int chamadoId { get; set; }
    }
}
