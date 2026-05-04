using ControleAtendimentos.Data;
using ControleAtendimentos.Models;

namespace ControleAtendimentos.Repositorys
{
    public class PrioridadeRepository
    {
        private readonly AppDbContext _context;

        public PrioridadeRepository(AppDbContext context)
        {
            _context = context;
        }

        public PrioridadeModel Add(PrioridadeModel prioridade)
        {
            _context.Prioridades.Add(prioridade);
            _context.SaveChanges();
            return prioridade;
        }

        public PrioridadeModel Update(PrioridadeModel prioridade)
        {
            _context.Prioridades.Update(prioridade);
            _context.SaveChanges();
            return prioridade;
        }

        public List<PrioridadeModel> GetAll()
        {
            return _context.Prioridades.ToList();
        }

        public PrioridadeModel GetById(int id)
        {
            return _context.Prioridades.FirstOrDefault(p => p.id == id);
        }

        public void DeleteById(int id)
        {
            var prioridade = _context.Prioridades.Find(id);
            if (prioridade != null)
            {
                _context.Prioridades.Remove(prioridade);
                _context.SaveChanges();
            }
        }
    }
}