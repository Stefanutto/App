using EF.Domain;
using EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class GeneroModel
    {
        public List<Genero> FindAllGenero()
        {
            using (var contexto = new LocadoraContext())
            {
                List<Genero> generos = contexto.Gerenos.Where(g => g.Ativo == true).ToList();
                return generos;
            }
        }
    }
}
