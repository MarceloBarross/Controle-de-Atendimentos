using System.ComponentModel.DataAnnotations;

namespace ControleAtendimentos.Models
{
    public class PrioridadeModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }

        public TimeSpan tempoEstimado {  get; set; }

        public List<ChamadoModel> chamados { get; set; }
    }
}
