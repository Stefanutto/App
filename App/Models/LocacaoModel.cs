using EF.Domain;
using EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class LocacaoModel
    {
        public List<Locacao> FindAllLocacao()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Locacoes.ToList();
            }
        }


    }
}
