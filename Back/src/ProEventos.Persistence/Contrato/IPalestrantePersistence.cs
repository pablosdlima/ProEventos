using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IPalestrantePersistence
    {
         //Palestrantes
        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string Nome, bool includeEventos);
        //busca todos os temas de palestrantes que possuir o nome informado no parametro e ou incluir os eventos
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
        //busca todos os Palestrante que possuir o ou incluir os Eventos
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);
        // busca e retorna apenas o Palestrante que contenha id
    }
}