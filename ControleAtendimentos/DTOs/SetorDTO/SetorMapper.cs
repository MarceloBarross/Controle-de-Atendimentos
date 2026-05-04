using ControleAtendimentos.Models;

namespace ControleAtendimentos.DTOs.SetorDTO
{
    public class SetorMapper
    {
        public SetorDTOResponse toDTO(SetorModel setor)
        {
            return new SetorDTOResponse
            {
                id = setor.id,
                nome = setor.nome
            };
        }

        public SetorModel toModel(SetorDTORequest setorDTO)
        {
            return new SetorModel
            {
                nome = setorDTO.nome
            };
        }

        public SetorModel toModel(SetorDTOResponse setorDTO)
        {
            return new SetorModel
            {
                id = setorDTO.id,
                nome = setorDTO.nome
            };
        }
    }
}
