using ControleAtendimentos.Models.enums.StatusEnunm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAtendimentos.Models
{
    public class ChamadoModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public StatusEnum status { get; set; }

        [Column("setorid")]
        public int setorId { get; set; }

        public SetorModel setor { get; set; }

        [Column("prioridadeid")]
        public int prioridadeId { get; set; }
        public PrioridadeModel prioridade { get; set; }

        public AtendimentoModel? atendimento { get; set; }
    }
}
