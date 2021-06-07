using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

       public IEnumerable<Evento> _evento = new Evento[]{ //array
          new Evento(){
             EventoId = 1,
             Tema = "Angular 11 e .Net 5",
             Local = "Belo Horizonte",
             Lote = "1º",
             QtdPessoas = 250,
             DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
             ImagemUrl = "foto.jpg"
          },
          
          new Evento(){
             EventoId = 2,
             Tema = "Angular 11 e .Net Core 5",
             Local = "SP - São paulo",
             Lote = "2º",
             QtdPessoas = 251,
             DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
             ImagemUrl = "foto.png"
          }

       };

        public EventoController()
        {          
            //constructor vazio.
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _evento;
        }
        
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
           return _evento.Where(evento => evento.EventoId == id);
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
