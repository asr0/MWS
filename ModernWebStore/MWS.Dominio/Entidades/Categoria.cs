#region

using System;

#endregion

namespace MWS.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria(String titulo)
        {
            this.Titulo = titulo;
        }
        public int Id { get; set; }

        public String Titulo { get; private set; }
    }
}