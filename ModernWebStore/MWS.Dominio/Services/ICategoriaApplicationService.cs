using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;

namespace MWS.Dominio.Services
{
    interface ICategoriaApplicationService
    {
        List<Categoria> GetAll();
        List<Categoria> GetinPadding(int skip, int take);
        Categoria Get(int id);
        Categoria Get(Categoria categoria);
        void Create(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);
        void Delete(int id);

    }
}
