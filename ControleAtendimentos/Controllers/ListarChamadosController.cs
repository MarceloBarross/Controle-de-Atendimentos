using Microsoft.AspNetCore.Mvc;
using ControleAtendimentos.Services;
using ControleAtendimentos.DTOs.ChamadoDTO;

namespace ControleAtendimentos.Controllers
{
    public class ListarChamadosController : Controller
    {
        private readonly ChamadoService _chamadoService;

        public ListarChamadosController(ChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        public IActionResult Index()
        {
          
            List<ChamadoDTOResponse> listaDeChamados = _chamadoService.listarTodos();

            return View(listaDeChamados);
        }

        [HttpPost]
        public IActionResult IniciarAtendimento(int id)
        {
            _chamadoService.iniciarAtendimento(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult FinalizarAtendimento(int id)
        {
            _chamadoService.finalizarAtendimento(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CancelarAtendimento(int id)
        {
            _chamadoService.cancelarAtendimento(id);
            return RedirectToAction("Index");
        }
    }
}