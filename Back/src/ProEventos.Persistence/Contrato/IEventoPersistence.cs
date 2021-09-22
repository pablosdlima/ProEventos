using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IEventoPersistence
    {
        //Eventos
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
            //busca todos os eventos que possuir o ou incluir os palestrantes
         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes);
            // busca e retorna apenas o evento que contenha id
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
             //busca todos os temas de eventos que possuir o tema informado no parametro e ou incluir os palestrantes
    }
}