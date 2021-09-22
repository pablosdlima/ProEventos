using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class PalestranteEvento //table relacional de N pra N
    {
        public int EventoId { get; set; }
        public int PalestranteId { get; set; }
        public Evento Evento { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}