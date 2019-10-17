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
                return contexto.Gerenos.ToList();
            }
        }
        public Genero FindGenero(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                //Aqui utilizei o lambda para mostar que tambem sei utilizar
                return contexto.Gerenos.Where(g => g.Id == id).FirstOrDefault();
            }

        }
        public void DeleteGenero(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                Genero genero = contexto.Gerenos.Where(f => f.Id == id).FirstOrDefault();
                contexto.Gerenos.Remove(genero);
                contexto.SaveChanges();
            }
        }

        public bool InsertOrUpdateGenero(Genero genero)
        {
            using (var contexto = new LocadoraContext())
            {
                try
                {
                    genero.DataCriacao = DateTime.Now;

                    //SE O ID É 0 QUER DIZER QUE É ADD CASOU CONTRARIO É UPDATE
                    if (genero.Id == 0)
                        contexto.Gerenos.Add(genero);
                    else
                        contexto.Gerenos.Update(genero);


                    contexto.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
   
}
