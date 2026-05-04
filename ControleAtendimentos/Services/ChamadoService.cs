using ControleAtendimentos.DTOs.AtendimentoDTO;
using ControleAtendimentos.DTOs.ChamadoDTO;
using ControleAtendimentos.Models;
using ControleAtendimentos.Models.enums.StatusEnunm;
using ControleAtendimentos.Repositorys;

namespace ControleAtendimentos.Services
{
    public class ChamadoService
    {
        private readonly ChamadoRepository _chamadoRepository;
        private readonly ChamadoMapper _chamadoMapper;
        private readonly AtendimentoService _atendimentoService;
        private readonly AtendimentoMapper _atendimentoMapper;

        public ChamadoService(ChamadoRepository chamadoRepository, ChamadoMapper chamadoMapper, AtendimentoService atendimentoService, AtendimentoMapper atendimentoMapper)
        {
            _atendimentoMapper = atendimentoMapper;
            _chamadoRepository = chamadoRepository;
            _chamadoMapper = chamadoMapper;
            _atendimentoService = atendimentoService;
        }

        public ChamadoDTOResponse criar(ChamadoDTORequest chamadoDTO)
        {
            ChamadoModel chamado = _chamadoMapper.toModel(chamadoDTO);

            _chamadoRepository.Add(chamado);

            ChamadoModel chamadoCompleto = _chamadoRepository.GetById(chamado.id);

            return _chamadoMapper.toDTO(chamadoCompleto);
        }




        public void iniciarAtendimento(int id)
        {
            ChamadoModel chamado = _chamadoRepository.GetById(id);
            if (chamado == null) return;
            
            if(chamado.status.Equals(StatusEnum.Aberto)){ 

                chamado.status = StatusEnum.EmAndamento;

                chamado.atendimento = _atendimentoMapper.toModel(_atendimentoService.iniciar(id));
            }

            _chamadoRepository.Update(chamado);
        }

        public void finalizarAtendimento(int id)
        {
            ChamadoModel chamado = _chamadoRepository.GetById(id);

            if (chamado == null) return;
            
            if (chamado.status.Equals(StatusEnum.EmAndamento))
            {
                chamado.status = StatusEnum.Concluido;
                _atendimentoService.finalizarAtendimento(chamado.atendimento.id);
            }

            _chamadoRepository.Update(chamado); 
        }



        public void cancelarAtendimento(int id)
        {
            ChamadoModel chamado = _chamadoRepository.GetById(id);

            if (chamado == null) return;

            chamado.status = StatusEnum.Cancelado;

            if (chamado.atendimento != null)
            {
                _atendimentoService.cancelarAtendimento(chamado.atendimento.id);
            }

            _chamadoRepository.Update(chamado);
        }



        public List<ChamadoDTOResponse> listarTodos()
        {

            var chamados = _chamadoRepository.GetAll();

            return chamados.Select(c => _chamadoMapper.toDTO(c)).ToList();
        }

        public ChamadoDTOResponse? buscarPorId(int id)
        {
            var chamado = _chamadoRepository.GetById(id);

            if (chamado == null) return null;

            return _chamadoMapper.toDTO(chamado);
        }

        public void deletar(int id)
        {
            _chamadoRepository.DeleteById(id);
        }
    }
}