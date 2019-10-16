using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Domain
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
