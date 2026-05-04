using ControleAtendimentos.DTOs.PrioridadeDTO;
using ControleAtendimentos.DTOs.SetorDTO;
using ControleAtendimentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleAtendimentos.Controllers
{
    public class PrioridadeController : Controller
    {
        PrioridadeService _prioridadeService;

        public PrioridadeController(PrioridadeService prioridadeService)
        {
            _prioridadeService = prioridadeService;
        }

        public IActionResult Index()
        {
            List<PrioridadeDTOResponse> prioridade = _prioridadeService.listarTodos();
            return View(prioridade);
        }


        public IActionResult TelaCriarPrioridade()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(PrioridadeDTORequest model)
        {
            if (!TimeSpan.TryParse(model.tempoEstimado, out _))
            {
                ModelState.AddModelError("tempoEstimado", "Formato inválido. Use hh:mm:ss");
            }

            if (ModelState.IsValid)
            {
                _prioridadeService.criar(model);
                return RedirectToAction("Index");
            }

            return View("TelaCriarPrioridade", model);
        }

        [HttpGet]
        public IActionResult TelaEditarPrioridade(int id)
        {
            var prioridade = _prioridadeService.buscarPorId(id);
            if (prioridade == null) return NotFound();
            return View(prioridade);
        }

        [HttpPost]
        public IActionResult Editar(PrioridadeDTOResponse model)
        {
            if (!TimeSpan.TryParse(model.tempoEstimado, out _))
            {
                ModelState.AddModelError("tempoEstimado", "Formato inválido. Use hh:mm:ss");
            }

            if (!ModelState.IsValid) {
                return View("TelaEditarPrioridade", model);
            }
            _prioridadeService.atualizar(model);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Deletar(int id)
        {
            try{
                _prioridadeService.deletar(id);
            }
            catch (Exception) { 
                TempData["Erro"] = "Não é possível excluir uma prioridade que possui chamados vinculados.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
