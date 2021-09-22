using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private ProEventosContext _context;

        public EventoPersistence(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
           IQueryable<Evento> query = _context.Eventos
                                .Include(e => e.Lotes)
                                .Include(e => e.RedesSociais);

            if(includePalestrantes) // se for true
            {
                query = query   //inclua palestrantes eventos e sua relação no select
                    .Include(e => e.PalestrantesEventos) // a cada palestrante evento que existir, inclua o palestrante
                    .ThenInclude(pe => pe.Palestrante); //agora inclua == thenInclude
            }
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
              IQueryable<Evento> query = _context.Eventos
                                .Include(e => e.Lotes)
                                .Include(e => e.RedesSociais);

            if(includePalestrantes) // se for true
            {
                query = query   //inclua palestrantes eventos e sua relação no select
                    .Include(e => e.PalestrantesEventos) // a cada palestrante evento que existir, inclua o palestrante
                    .ThenInclude(pe => pe.Palestrante); //agora inclua == thenInclude
            }
            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                    .Include(e => e.Lotes)
                                    .Include(e => e.RedesSociais);

                if(includePalestrantes) // se for true
                {
                    query = query   //inclua palestrantes eventos e sua relação no select
                        .Include(e => e.PalestrantesEventos) // a cada palestrante evento que existir, inclua o palestrante
                        .ThenInclude(pe => pe.Palestrante); //agora inclua == thenInclude
                }
                query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

                return await query.ToArrayAsync();
        }
    }
}