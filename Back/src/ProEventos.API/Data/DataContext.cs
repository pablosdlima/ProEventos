using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        } //construtor contexto.
           
        public DbSet<Evento> Eventos { get; set; } //mapeamento da tabela do banco.
     
    }
}