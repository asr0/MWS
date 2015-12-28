using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWS.Dominio.Entidades
{
 public   class Produto
    {
     public Produto( string titulo,string descricao,decimal preco,int quantidade,int categoriaId)
     {
         this.Titulo = titulo;
         this.Descricao = descricao;
         this.Preco = preco;
         Quantidade = quantidade;
         this.CategoriaId = categoriaId;
     }

     public int Id { get; private set; }
     public String Titulo { get;private set; }
     public String Descricao { get;private set; }
     public Decimal Preco { get;private set; }
     public int Quantidade { get;private set; }
     public int CategoriaId { get;private set; }
     public Categoria Categoria { get; private set; }
    }
}
