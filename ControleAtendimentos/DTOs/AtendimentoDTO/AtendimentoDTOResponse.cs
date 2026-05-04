using ControleAtendimentos.Models;

namespace ControleAtendimentos.DTOs.AtendimentoDTO
{
    public class AtendimentoDTOResponse
    {
        public int id { get; set; }
        public int ChamadoId { get; set; }
        public DateTime dataHoraInicio { get; set; }
        public DateTime? dataHoraFim { get; set; }
        public TimeSpan tempoTotal { get; set; }
    }
}
