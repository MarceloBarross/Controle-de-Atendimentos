using System.ComponentModel.DataAnnotations;

namespace ControleAtendimentos.Models
{
    public class AtendimentoModel
    {
        [Key]
        public int id { get; set; }

        public int ChamadoId { get; set; }
        public ChamadoModel chamado { get; set; }
        public DateTime dataHoraInicio { get; set; }
        public DateTime? dataHoraFim { get; set; }
        public TimeSpan tempoTotal { get; set; }
    }
}
