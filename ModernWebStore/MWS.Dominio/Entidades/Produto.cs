#region

using System;
using MWS.Dominio.Scope;

#endregion

namespace MWS.Dominio.Entidades
{
    public class Produto
    {
        protected Produto()
        {
        }

        public Produto(string titulo, string descricao, decimal preco, int quantidade, int categoriaId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
            CategoriaId = categoriaId;
        }


        public Produto(int id,string titulo, string descricao, decimal preco, int quantidade, int categoriaId)
        {
            Id = id;
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
            Preco = preco;
        }

        public void AtualizarInformacoes(string titulo, string descricao, int categoria)
        {
            if (!this.AtualizarInformacoesValido(titulo, descricao, categoria))
                return;

            Titulo = titulo;
            Descricao = descricao;
            CategoriaId = categoria;
        }

        public void AtualizarQuantidade(int qtd)
        {
            if (!this.AtualizarQuantidadeValido(qtd))
                return;
            Quantidade = qtd;
        }
    }
}