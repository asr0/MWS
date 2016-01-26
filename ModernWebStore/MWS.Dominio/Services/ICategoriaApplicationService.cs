#region

using System.Collections.Generic;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Services
{
    internal interface ICategoriaApplicationService
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