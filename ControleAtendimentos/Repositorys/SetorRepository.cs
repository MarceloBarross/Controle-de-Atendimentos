using ControleAtendimentos.Data;
using ControleAtendimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtendimentos.Repositorys
{
    public class SetorRepository
    {
        private readonly AppDbContext _context;

        public SetorRepository(AppDbContext context)
        {
            _context = context;
        }

        public SetorModel Add(SetorModel setor)
        {
            _context.Setores.Add(setor);
            _context.SaveChanges();
            return setor;
        }

        public SetorModel Update(SetorModel setor)
        {
            _context.Setores.Update(setor);
            _context.SaveChanges();
            return setor;
        }

        public List<SetorModel> GetAll()
        {
            return _context.Setores.ToList();
        }

        public SetorModel GetById(int id)
        {
            return _context.Setores.FirstOrDefault(s => s.id == id);
        }

        public void DeleteById(int id)
        {
            var setor = _context.Setores.Find(id);
            if (setor != null)
            {
                _context.Setores.Remove(setor);
                _context.SaveChanges();
            }
        }
    }
}