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

        [Required(ErrorMessage = "Digite o nome do seu usuário")]
        public string User { get; set; }

        [Required(ErrorMessage = "Informe uma senha ")]
        public string Passwd { get; set; }

        [NotMapped]
        public string RePasswd { get; set; }

    }
}
