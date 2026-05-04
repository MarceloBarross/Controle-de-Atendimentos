using ControleAtendimentos.DTOs.SetorDTO;
using ControleAtendimentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleAtendimentos.Controllers
{
    public class SetorController : Controller
    {
        private SetorService _setorService;

        public SetorController(SetorService setorSetvice) {
            _setorService = setorSetvice;
        }

        public IActionResult Index()
        {
            List<SetorDTOResponse> listaSetores = _setorService.listarTodos();

            return View(listaSetores);
        }

        [HttpPost]
        public IActionResult Criar(SetorDTORequest model)
        {
            if (ModelState.IsValid)
            {
                _setorService.criar(model);
                return RedirectToAction("Index");
            }
            return View("TelaCriarSetor", model);
        }

        public IActionResult TelaCriarSetor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TelaEditarSetor(int id)
        {
            var setor = _setorService.buscarPorId(id);
            if (setor == null) return NotFound();
            return View(setor);
        }

        [HttpPost]
        public IActionResult Editar(SetorDTOResponse model)
        {
            if (!ModelState.IsValid)
            {
                return View("TelaEditarSetor", model);
            }

            _setorService.atualizar(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            try
            {
                _setorService.deletar(id);
            }
            catch (Exception)
            {
                TempData["Erro"] = "Não é possível excluir um setor que possui chamados vinculados.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
