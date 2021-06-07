using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
       private readonly DataContext _context;  

        public EventoController(DataContext context)
        {          
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _context.Eventos;
        }
        
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
           return _context.Eventos.Where(evento => evento.EventoId == id);
        }
        


        [HttpPost]
        public string Post()
        {
           return "POST";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
           return $"Put:{id}";
        }
        
        [HttpDelete("{id}")] //parâmetro dentro do protocolo
        public string Delete(int id)
        {
           return $"Delete {id}"; //concatenação semelhante ao js
        }


    }
}
