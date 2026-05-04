using ControleAtendimentos.DTOs.PrioridadeDTO;
using ControleAtendimentos.DTOs.SetorDTO;
using System.ComponentModel.DataAnnotations;

namespace ControleAtendimentos.View.CriarChamados
{
    public class ViewModel
    {
        public List<PrioridadeDTOResponse> prioridades { get; set; } = new();
        public List<SetorDTOResponse> setores { get; set; } = new();

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string descricao { get; set; }
        public int setorId { get; set; }
        public int prioridadeId { get; set; }
    }
}