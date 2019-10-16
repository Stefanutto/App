using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Domain
{
    public class Locacao
    {
        public int Id { get; set; }
        public List<Filme> ListaFilmes { get; set; }
        public int CPF { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
