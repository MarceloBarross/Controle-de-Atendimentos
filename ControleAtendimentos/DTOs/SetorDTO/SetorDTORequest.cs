using System.ComponentModel.DataAnnotations;

namespace ControleAtendimentos.DTOs.SetorDTO
{
    public class SetorDTORequest
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string nome { get; set; }
    }
}
