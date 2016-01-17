#region

using System;
using MWS.Dominio.Scope;

#endregion

namespace MWS.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria(String titulo)
        {
            Titulo = titulo;
        }

        public int Id { get; set; }
        public String Titulo { get; private set; }

        public void Register()
        {
        }

        public void AtualizarTitulo(String titulo)
        {
            if (!this.AlteracaoCategoriaValida())
                return;

            Titulo = titulo;
        }
    }
}