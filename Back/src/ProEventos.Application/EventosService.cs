using System;
using System.Threading.Tasks;
using ProEventos.Application.Contrato;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.Application
{
    public class EventosService : IEventos_service
    {
       private readonly IGeralPersistence _geralPersist;
        private readonly IEventoPersistence _eventoPersist;

        public EventosService( IGeralPersistence geralPersist, IEventoPersistence eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
           try{
                _geralPersist.Add<Evento>(model);

                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;

           }
           catch(Exception error){
               throw new Exception(error.Message);
           }
        }

      public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
           try{
              var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
              if(evento == null) return null;
              
              model.Id = evento.Id;

              _geralPersist.Update(model);
              if(await _geralPersist.SaveChangesAsync())
              {
                 return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
              }
              return null;
           }
           catch(Exception error){
              throw new Exception(error.Message);
           }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
           try{
              var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
              if(evento == null) throw new Exception("Evento não encontrado!");

              _geralPersist.Delete<Evento>(evento);
              return await _geralPersist.SaveChangesAsync();
           }
           catch(Exception error){
               throw new Exception(error.Message);            
           }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
           try{

              var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
              if(eventos == null) return null;

              return eventos;
           }
           catch(Exception error){
               throw new Exception(error.Message);
           }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
           try{
              var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
              if(eventos == null) return null;

              return eventos;
           }
           catch(Exception error){
               throw new Exception(error.Message);
           }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
           try{
              var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
              if(eventos == null) return null;

              return eventos;
           }
           catch(Exception error){
               throw new Exception(error.Message);
           }
        }
    }
}