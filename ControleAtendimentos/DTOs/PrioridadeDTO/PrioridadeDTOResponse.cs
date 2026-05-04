using System.ComponentModel.DataAnnotations;

namespace ControleAtendimentos.DTOs.PrioridadeDTO
{
    public class PrioridadeDTOResponse
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Tempo estimado é obrigatório")]
        public string tempoEstimado { get; set; }
    }
}
