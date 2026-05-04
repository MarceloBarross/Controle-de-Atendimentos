using ControleAtendimentos.DTOs.AtendimentoDTO;
using ControleAtendimentos.Models;
using ControleAtendimentos.Repositorys;

namespace ControleAtendimentos.Services
{
    public class AtendimentoService
    {
        private readonly AtendimentoRepository _atendimentoRepository;
        private readonly AtendimentoMapper _atendimentoMapper;

        public AtendimentoService(AtendimentoRepository atendimentoRepository, AtendimentoMapper atendimentoMapper)
        {
            _atendimentoRepository = atendimentoRepository;
            _atendimentoMapper = atendimentoMapper;
        }

        public AtendimentoDTOResponse iniciar(int chamadoId)
        {
            AtendimentoModel atendimento = new AtendimentoModel
            {
                ChamadoId = chamadoId,
                dataHoraInicio = DateTime.UtcNow,
            };

            _atendimentoRepository.Add(atendimento);

            return _atendimentoMapper.toDTO(atendimento);
        }


        public void finalizarAtendimento(int id)
        {
            AtendimentoModel atendimento = _atendimentoRepository.GetById(id);
            if (atendimento == null) return;

            atendimento.dataHoraFim = DateTime.UtcNow;
            atendimento.tempoTotal = atendimento.dataHoraFim.Value - atendimento.dataHoraInicio;

            _atendimentoRepository.Update(atendimento);
        }

        public void cancelarAtendimento(int id)
        {
            AtendimentoModel atendimento = _atendimentoRepository.GetById(id);
            if (atendimento == null) return;

            atendimento.dataHoraFim = DateTime.UtcNow;
            atendimento.tempoTotal = TimeSpan.Zero;

            _atendimentoRepository.Update(atendimento);
        }

        public List<AtendimentoDTOResponse> listarTodos()
        {
            List<AtendimentoModel> atendimentos = _atendimentoRepository.GetAll();

            return atendimentos.Select(a => _atendimentoMapper.toDTO(a)).ToList();
        }

        public AtendimentoDTOResponse? buscarPorId(int id)
        {
            AtendimentoModel atendimento = _atendimentoRepository.GetById(id);

            if (atendimento == null) return null;

            return _atendimentoMapper.toDTO(atendimento);
        }

        public void deletar(int id)
        {
            _atendimentoRepository.DeleteById(id);
        }
    }
}