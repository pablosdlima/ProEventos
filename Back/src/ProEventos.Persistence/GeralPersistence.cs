using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private ProEventosContext _context;

        public GeralPersistence(ProEventosContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class //metodo genérico herdado Add
        {
            _context.Add(entity);
        }
         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class //metodo genérico herdado Delete
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T entity) where T : class //metodo genérico herdado DeleteRange
        {
           _context.RemoveRange(entity);
        }
        
        public async Task<bool> SaveChangesAsync(){
            return (await _context.SaveChangesAsync()) > 0; //se o retorno for maior que zero, ocorre o salvamento
        }
    }
}