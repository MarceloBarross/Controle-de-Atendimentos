using System.ComponentModel.DataAnnotations;

namespace ControleAtendimentos.Models
{
    public class SetorModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public List<ChamadoModel> chamados { get; set; }
    }
}
