using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Domain
{
    public class Genero
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataCriacao { set; get; }
        public bool Ativo { set; get; }

        public override string ToString()
        {
            return Nome.ToString();
        }
    }
}
