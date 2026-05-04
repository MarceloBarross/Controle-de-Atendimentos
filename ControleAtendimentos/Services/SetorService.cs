using ControleAtendimentos.DTOs.SetorDTO;
using ControleAtendimentos.Models;
using ControleAtendimentos.Repositorys;

namespace ControleAtendimentos.Services
{
    public class SetorService
    {
        private readonly SetorRepository _setorRepository;
        private readonly SetorMapper _setorMapper;

        public SetorService(SetorRepository setorRepository, SetorMapper setorMapper)
        {
            _setorRepository = setorRepository;
            _setorMapper = setorMapper;
        }

        public SetorDTOResponse criar(SetorDTORequest setorDTO)
        {
            SetorModel setor = _setorMapper.toModel(setorDTO);
            _setorRepository.Add(setor);
            return _setorMapper.toDTO(setor);
        }

        public SetorDTOResponse atualizar(SetorDTOResponse setorDTO)
        {
            SetorModel setor = _setorRepository.GetById(setorDTO.id);

            if (setor == null)
                throw new Exception($"Setor com id {setorDTO.id} não encontrado.");

            setor.nome = setorDTO.nome;
            _setorRepository.Update(setor);
            return _setorMapper.toDTO(setor);
        }

        public List<SetorDTOResponse> listarTodos()
        {
            List<SetorModel> setores = _setorRepository.GetAll();

            return setores.Select(s => _setorMapper.toDTO(s)).ToList();
        }

        public SetorDTOResponse? buscarPorId(int id)
        {
            SetorModel setor = _setorRepository.GetById(id);

            if (setor == null) return null;

            return _setorMapper.toDTO(setor);
        }

        public void deletar(int id)
        {
            _setorRepository.DeleteById(id);
        }
    }
}