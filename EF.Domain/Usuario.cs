using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Passwd { get; set; }


        [NotMapped]
        public string RePasswd { get; set; }
        [NotMapped]
        public bool ErrorValidatingFields { get; set; } = true;

        public string ValidatingFields()
        {
            if(this.User == null || this.User.Length < 3)
                return "O usuário deve ter pelo menos 3 caracteres";

            if(this.Passwd == null || this.Passwd.Length < 6)
                return "A senha deve ter pelo menos 6 caracteres; </li>";

            if(this.RePasswd == null || this.Passwd == null || this.Passwd != this.RePasswd)
                return "A senha e a confirmação de senha deve ser iguais";


            ErrorValidatingFields = false;
            return "Sua conta foi criada com sucesso, utilize o link abaixo para acessar o app.";
        }
    }
}
