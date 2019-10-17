using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF.Domain
{
    public class Genero
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataCriacao { set; get; }
        public bool Ativo { set; get; }

        [NotMapped]
        public bool ErrorValidatingFields { get; set; } = true;


        public string ValidatingFields()
        {
            string msg;
            if (this.Nome == null || this.Nome.Length < 3)
                return "O nome do genero deve ter pelo menos 3 caracteres";

            ErrorValidatingFields = false;

            if (this.Id == 0)
                msg = "cadastro";
            else
                msg = "edição";

            return "O " + msg + " foi realizado com sucesso.";
        }

        public override string ToString()
        {
            return Nome.ToString();
        }
    }
}
