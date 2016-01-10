#region

using System;

#endregion

namespace MWS.NucleoCompartilhado.Eventos.Contratos
{
    public class NotificacaoDominio : IEventoDominio
    {
        public NotificacaoDominio(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
            DataOcorrido = DateTime.Now;
        }

        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public DateTime DataOcorrido { get;  set; }
    }
}