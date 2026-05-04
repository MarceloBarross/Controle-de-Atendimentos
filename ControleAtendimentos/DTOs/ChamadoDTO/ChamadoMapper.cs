using ControleAtendimentos.DTOs.AtendimentoDTO;
using ControleAtendimentos.DTOs.PrioridadeDTO;
using ControleAtendimentos.DTOs.SetorDTO;
using ControleAtendimentos.Models;
using ControleAtendimentos.Models.enums.StatusEnunm;
using ControleAtendimentos.Services;
using ControleAtendimentos.View.CriarChamados;

namespace ControleAtendimentos.DTOs.ChamadoDTO
{
    public class ChamadoMapper
    {
        private readonly SetorMapper _setorMapper;
        private readonly PrioridadeMapper _prioridadeMapper;
        private readonly SetorService _setorService;
        private readonly PrioridadeService _prioridadeService;
        private readonly AtendimentoMapper _atendimentoMapper;

        public ChamadoMapper(
            AtendimentoMapper atendimentoMapper,
            PrioridadeMapper prioridadeMapper,
            SetorMapper setorMapper,
            SetorService setorService,
            PrioridadeService prioridadeService)
        {
            _atendimentoMapper = atendimentoMapper;
            _prioridadeMapper = prioridadeMapper;
            _setorMapper = setorMapper;
            _setorService = setorService;
            _prioridadeService = prioridadeService;
        }

        public ChamadoDTOResponse toDTO(ChamadoModel chamado)
        {
            return new ChamadoDTOResponse
            {
                id = chamado.id,
                descricao = chamado.descricao,
                nomeSetor = chamado.setor.nome,
                
                prioridade = chamado.prioridade != null ? _prioridadeMapper.toDTO(chamado.prioridade) : null,
                
                status = chamado.status,
                
                TempoTotalAtendimento = chamado.atendimento != null ? chamado.atendimento.tempoTotal : TimeSpan.Zero,

                atendimento = chamado.atendimento != null ? _atendimentoMapper.toDTO(chamado.atendimento) : null,

                passouTempoLimitePrioridade = chamado.atendimento?.dataHoraFim != null ? chamado.atendimento.tempoTotal > chamado.prioridade.tempoEstimado : false
            }; 
        }

        public ChamadoDTORequest toDTO(ViewModel chamado)
        {
            return new ChamadoDTORequest
            {
                descricao = chamado.descricao,
                setorId = chamado.setorId,
                prioridadeId = chamado.prioridadeId,
            };
        }

        public ChamadoModel toModel(ChamadoDTORequest chamadoDTO)
        {
            return new ChamadoModel
            {
                descricao = chamadoDTO.descricao,
                setorId = chamadoDTO.setorId,
                prioridadeId = chamadoDTO.prioridadeId,
                status = StatusEnum.Aberto
            };
        }
    }
}
