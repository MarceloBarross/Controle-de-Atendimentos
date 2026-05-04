using ControleAtendimentos.DTOs.PrioridadeDTO;
using ControleAtendimentos.Models;
using ControleAtendimentos.Repositorys;

namespace ControleAtendimentos.Services
{
    public class PrioridadeService
    {
        private readonly PrioridadeRepository _prioridadeRepository;
        private readonly PrioridadeMapper _prioridadeMapper;

        public PrioridadeService(PrioridadeRepository prioridadeRepository, PrioridadeMapper prioridadeMapper)
        {
            _prioridadeRepository = prioridadeRepository;
            _prioridadeMapper = prioridadeMapper;
        }

        public PrioridadeDTOResponse criar(PrioridadeDTORequest prioridadeDTO)
        {
            PrioridadeModel prioridade = _prioridadeMapper.toModel(prioridadeDTO);

            _prioridadeRepository.Add(prioridade);

            return _prioridadeMapper.toDTO(prioridade);
        }

        public PrioridadeDTOResponse atualizar(PrioridadeDTOResponse prioridadeDTO)
        {
            PrioridadeModel prioridade = _prioridadeRepository.GetById(prioridadeDTO.id);

            prioridade.nome = prioridadeDTO.nome;
            prioridade.tempoEstimado = TimeSpan.Parse(prioridadeDTO.tempoEstimado);
            
            _prioridadeRepository.Update(prioridade);
            return _prioridadeMapper.toDTO(prioridade);
        }

        public List<PrioridadeDTOResponse> listarTodos()
        {
            List<PrioridadeModel> prioridades = _prioridadeRepository.GetAll();

            return prioridades.Select(p => _prioridadeMapper.toDTO(p)).ToList();
        }

        public PrioridadeDTOResponse? buscarPorId(int id)
        {
            PrioridadeModel prioridade = _prioridadeRepository.GetById(id);

            if (prioridade == null) return null;

            return _prioridadeMapper.toDTO(prioridade);
        }

        public void deletar(int id)
        {
            _prioridadeRepository.DeleteById(id);
        }
    }
}