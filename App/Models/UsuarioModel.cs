using App.Func;
using EF.Domain;
using EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class UsuarioModel
    {
        public bool UserExists(Usuario usuario)
        {
            using (var contexto = new LocadoraContext())
            {
                var usuarios =  contexto.Usuarios
                                .Where(u => u.User.ToUpper().Contains(usuario.User.ToUpper()))
                                .ToList();
                if (usuarios.Count > 0)
                    return true;
            }


            return false;
        }

        public bool ValidatingLogin(Usuario usuario)
        {
            usuario.Passwd = MD5Hash.CalculaHash(usuario.Passwd);
            using (var contexto = new LocadoraContext())
            {
                var usuarios = contexto.Usuarios
                                .Where(u => u.User.ToUpper().Contains(usuario.User.ToUpper()))
                                .Where(u => u.Passwd.ToUpper().Contains(usuario.Passwd.ToUpper()))
                                .ToList();
                if (usuarios.Count > 0)
                {
                    Session.usuario = usuario;
                    return true;
                }
            }

            return false;
        }

        public bool InsertUser(Usuario usuario)
        {
            //Deixou a senha no padrão MD5
            usuario.Passwd = MD5Hash.CalculaHash(usuario.Passwd);

            using (var contexto = new LocadoraContext())
            {
                try
                {
                    contexto.Usuarios.Add(usuario);
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
