using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF.Domain
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

        public int? GeneroId { get; set; }
        public Genero Genero { get; set; }

        [NotMapped]
        public bool ErrorValidatingFields { get; set; } = true;


        public string ValidatingFields()
        {
            string msg;
            if (this.Nome == null || this.Nome.Length < 3)
                return "O nome do filme deve ter pelo menos 3 caracteres";

            if (this.GeneroId == null)
                return "Selecione um genero;";
            
            ErrorValidatingFields = false;
            if (this.Id == 0)
                msg = "cadastro";
            else
                msg = "edição";

            return "O " + msg + " foi realizado com sucesso.";
        }

        public override string ToString()
        {
            return this.Nome.ToString();
        }
    }
}
