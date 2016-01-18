#region

using System;
using MWS.Dominio.Scope;

#endregion

namespace MWS.Dominio.Entidades
{
    public class Produto
    {
        public Produto(string titulo, string descricao, decimal preco, int quantidade, int categoriaId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
            CategoriaId = categoriaId;
        }

        public int Id { get; private set; }
        public String Titulo { get; private set; }
        public String Descricao { get; private set; }
        public Decimal Preco { get; private set; }
        public int Quantidade { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        
        public void RegistrarProduto()
        {
            this.RegistrarProdutoValido();
        }

        public void AtualizarPreco(decimal preco)
        {
            this.AtualizarPrecoValido(preco);
            this.Preco = preco;
        }

        public void AtualizarInformacoes(string titulo,string descricao,int categoria)
        {
           if(!this.AtualizarInformacoesValido(titulo, descricao, categoria))
                return;
            
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.CategoriaId = categoria;
        }

        public void AtualizarQuantidade(int qtd)
        {
            if (!this.AtualizarQuantidadeValido(qtd))
                return;
            this.Quantidade = qtd;
        }


    }



}