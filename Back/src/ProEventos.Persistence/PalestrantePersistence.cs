using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private ProEventosContext _context;

        public PalestrantePersistence(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                .Include(e => e.RedesSociais)
                                .AsNoTracking();

            if(includeEventos) // se for true
            {
                query = query   //inclua palestrantes eventos e sua relação no select
                    .Include(e => e.PalestrantesEventos) // a cada palestrante evento que existir, inclua o palestrante
                    .ThenInclude(pe => pe.Evento) //agora inclua == thenInclude
                    .AsNoTracking();
            }
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos = false)
        {
           IQueryable<Palestrante> query = _context.Palestrantes
                                .Include(e => e.RedesSociais);

            if(includeEventos) // se for true
            {
                query = query   //inclua palestrantes eventos e sua relação no select
                    .Include(e => e.PalestrantesEventos) // a cada palestrante evento que existir, inclua o evento
                    .ThenInclude(pe => pe.Evento) //agora inclua == thenInclude
                    .AsNoTracking();
            }
            query = query.OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
           IQueryable<Palestrante> query = _context.Palestrantes
                                .Include(e => e.RedesSociais).AsNoTracking();

            if(includeEventos) // se for true
            {
                query = query   //inclua palestrantes eventos e sua relação no select
                    .Include(e => e.PalestrantesEventos) // a cada palestrante evento que existir, inclua o evento
                    .ThenInclude(pe => pe.Evento); //agora inclua == thenInclude
            }
            query = query.OrderBy(e => e.Id).Where(e => e.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}