using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IGeralPersistence
    {
        private ProEventosContext _context;

        public ProEventosPersistence(ProEventosContext context)
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

        public async Task<Evento[]> GetAllEventosByAsync(bool includePalestrantes = false)
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

        public async Task<Palestrante[]> GetAllPalestranteByAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                .Include(e => e.RedesSociais);

            if(includeEventos) // se for true
            {
                query = query   //inclua palestrantes eventos e sua relação no select
                    .Include(e => e.PalestrantesEventos) // a cada palestrante evento que existir, inclua o palestrante
                    .ThenInclude(pe => pe.Evento); //agora inclua == thenInclude
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
                    .ThenInclude(pe => pe.Evento); //agora inclua == thenInclude
            }
            query = query.OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
           IQueryable<Palestrante> query = _context.Palestrantes
                                .Include(e => e.RedesSociais);

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