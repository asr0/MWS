using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;

namespace MWS.Dominio.Repository
{
    interface IUsuarioRepository
    {


        Usuario Autenticar(string email, string senha);
        void Registrar(Usuario usuario);
        Usuario GetByEmail(string email);

    }
}
