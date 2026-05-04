using ControleAtendimentos.DTOs.ChamadoDTO;
using ControleAtendimentos.Services;
using ControleAtendimentos.View.CriarChamados; 
using Microsoft.AspNetCore.Mvc;

namespace ControleAtendimentos.Controllers
{
    public class CriarChamadosController : Controller
    {
        private readonly PrioridadeService _prioridadeService;
        private readonly SetorService _setorService;
        private readonly ChamadoService _chamadoService;
        private readonly ChamadoMapper _chamadoMapper;

        public CriarChamadosController(
            ChamadoMapper chamadoMapper,
            PrioridadeService prioridadeService,
            SetorService setorService,
            ChamadoService chamadoService)
        {
            _prioridadeService = prioridadeService;
            _setorService = setorService;
            _chamadoService = chamadoService;
            _chamadoMapper = chamadoMapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new ViewModel
            {
                prioridades = _prioridadeService.listarTodos(),
                setores = _setorService.listarTodos()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Criar(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                ChamadoDTORequest chamadoDTORequest = _chamadoMapper.toDTO(model);
                _chamadoService.criar(chamadoDTORequest);
                return RedirectToAction("Index", "ListarChamados");
            }


            return View("Index", model);
        }
    }
}