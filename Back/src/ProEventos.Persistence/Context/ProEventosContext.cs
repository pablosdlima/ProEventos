using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosContext: DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options){

        } //construtor contexto.
           
        public DbSet<Evento> Eventos { get; set; } //mapeamento da tabela do banco.
        public DbSet<Lote> Lotes { get; set; } //mapeamento da tabela do banco.
        public DbSet<Palestrante> Palestrantes { get; set; } //mapeamento da tabela do banco.
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; } //mapeamento da tabela do banco.
        public DbSet<RedeSocial> RedeSociais { get; set; } //mapeamento da tabela do banco.
     
        protected override void OnModelCreating(ModelBuilder modelBuilder){ //declara que a tabela é de N pra N
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>() //delete em cascata
                .HasMany(e => e.RedesSociais) //muitos
                .WithOne(rs => rs.Evento)   //um
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>() //delete em cascata
                .HasMany(e => e.RedesSociais) //muitos
                .WithOne(rs => rs.Palestrante)   //um
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}