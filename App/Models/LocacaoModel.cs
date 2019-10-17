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

        public Locacao FindLocacao(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                //Aqui utilizei o lambda para mostar que tambem sei utilizar
                return contexto.Locacoes.Where(g => g.Id == id).FirstOrDefault();
            }

        }

        public void DeleteLocacao(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                Locacao locacao = contexto.Locacoes.Where(f => f.Id == id).FirstOrDefault();
                contexto.Locacoes.Remove(locacao);
                contexto.SaveChanges();
            }
        }

        public bool InsertOrUpdateLocacao(Locacao locacao)
        {
            using (var contexto = new LocadoraContext())
            {
                try
                {
                    locacao.DataCriacao = DateTime.Now;

                    //SE O ID É 0 QUER DIZER QUE É ADD CASOU CONTRARIO É UPDATE
                    if (locacao.Id == 0)
                        contexto.Locacoes.Add(locacao);
                    else
                        contexto.Locacoes.Update(locacao);


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
