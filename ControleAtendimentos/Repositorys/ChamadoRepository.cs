using ControleAtendimentos.Data;
using ControleAtendimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtendimentos.Repositorys
{
    public class ChamadoRepository
    {
        private readonly AppDbContext _context;

        public ChamadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public ChamadoModel Add(ChamadoModel chamado)
        {
            _context.Chamados.Add(chamado);
            _context.SaveChanges();
            return chamado;
        }

        public ChamadoModel Update(ChamadoModel chamado)
        {
            _context.Chamados.Update(chamado);
            _context.SaveChanges();
            return chamado;
        }

        public List<ChamadoModel> GetAll()
        {
            return _context.Chamados
                .Include(c => c.setor)
                .Include(c => c.prioridade)
                .Include(c => c.atendimento)
                .ToList();
        }

        public ChamadoModel GetById(int id)
        {
            return _context.Chamados
                .Include(c => c.setor)
                .Include(c => c.prioridade)
                .Include(c => c.atendimento)
                .FirstOrDefault(c => c.id == id);
        }

        public void DeleteById(int id)
        {
            var chamado = _context.Chamados.Find(id);
            if (chamado != null)
            {
                _context.Chamados.Remove(chamado);
                _context.SaveChanges();
            }
        }
    }
}