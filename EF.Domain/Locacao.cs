using App.Func;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF.Domain
{
    public class Locacao
    {
        public int Id { get; set; }
        public List<Filme> ListaFilmes { get; set; }
        public int CPF { get; set; }
        public DateTime DataCriacao { get; set; }

        [NotMapped]
        public bool ErrorValidatingFields { get; set; } = true;


        public string ValidatingFields()
        {
            string msg;
            if (!CpfCnpjUtils.IsValid(this.CPF.ToString()))
                return "CPF ou CNPJ inválidos;";

            ErrorValidatingFields = false;

            if (this.Id == 0)
                msg = "cadastro";
            else
                msg = "edição";

            return "O " + msg + " foi realizado com sucesso.";
        }

        public override string ToString()
        {
            return CPF.ToString();
        }
    }
}
