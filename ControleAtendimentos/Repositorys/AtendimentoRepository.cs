using ControleAtendimentos.Data;
using ControleAtendimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtendimentos.Repositorys
{
    public class AtendimentoRepository
    {
        private readonly AppDbContext _context;

        public AtendimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public AtendimentoModel Add(AtendimentoModel atendimento)
        {
            _context.Atendimentos.Add(atendimento);
            _context.SaveChanges(); 
            return atendimento;
        }

        public void Update(AtendimentoModel atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            _context.SaveChanges();
        }

        public List<AtendimentoModel> GetAll()
        {
            
            return _context.Atendimentos
                .ToList();
        }

        public AtendimentoModel GetById(int id)
        {
            return _context.Atendimentos.FirstOrDefault(a => a.id == id);
        }

        public void DeleteById(int id)
        {
            var atendimento = _context.Atendimentos.Find(id);
            if (atendimento != null)
            {
                _context.Atendimentos.Remove(atendimento);
                _context.SaveChanges();
            }
        }
    }
}