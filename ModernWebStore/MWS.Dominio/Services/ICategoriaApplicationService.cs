#region

using System.Collections.Generic;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Services
{
    public interface ICategoriaApplicationService
    {
        List<Categoria> GetAll();
        List<Categoria> GetInPadding(int skip, int take);
        Categoria Get(int id);
        Categoria Create(Categoria categoria);
        Categoria Update(Categoria categoria);
        Categoria Delete(Categoria categoria);
        Categoria Delete(int id);
    }
}