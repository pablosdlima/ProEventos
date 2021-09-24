using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contrato
{
    public interface IEventos_service
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int eventoId, Evento model);
        Task<bool> DeleteEventos(int eventoId);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
            //busca todos os eventos que possuir o ou incluir os palestrantes

        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
            // busca e retorna apenas o evento que contenha id

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
            //busca todos os temas de eventos que possuir o tema informado no parametro e ou incluir os palestrantes
    }
}