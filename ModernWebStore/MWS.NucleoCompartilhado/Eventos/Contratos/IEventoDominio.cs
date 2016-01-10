#region

using System;

#endregion

namespace MWS.NucleoCompartilhado.Eventos.Contratos
{
    public interface IEventoDominio
    {
        DateTime DataOcorrido { get; set; }
    }
}