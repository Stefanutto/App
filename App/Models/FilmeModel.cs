using EF.Domain;
using EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class FilmeModel
    {
        public List<Filme> FindAllFilmes()
        {
            using (var contexto = new LocadoraContext())
            {
                return (from f in contexto.Filmes
                        join g in contexto.Gerenos on f.GeneroId equals g.Id
                        select new Filme() {
                            Id = f.Id,
                            GeneroId = f.GeneroId,
                            Ativo = f.Ativo,
                            DataCriacao = f.DataCriacao,
                            Nome=f.Nome,
                            Genero = g
                        }).ToList();
            }
        }

        public Filme FindFime(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Filmes.Where(f => f.Id == id).FirstOrDefault();
            }

        }

        public void DeleteFilme(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                Filme filme = contexto.Filmes.Where(f => f.Id == id).FirstOrDefault();
                contexto.Filmes.Remove(filme);
                contexto.SaveChanges();
            }

        }

        public bool InsertOrUpdateFilme(Filme filme)
        {
            using (var contexto = new LocadoraContext())
            {
                try
                {
                    filme.DataCriacao = DateTime.Now;

                    if(filme.Id == 0)
                        contexto.Filmes.Add(filme);
                    else
                        contexto.Filmes.Update(filme);
                        
                    
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
