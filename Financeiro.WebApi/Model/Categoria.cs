using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class Categoria
    {
        public Categoria()
        {
            InverseIdCategoriaPaiNavigation = new HashSet<Categoria>();
            Movimentacao = new HashSet<Movimentacao>();
            InverseIdPessoaNavigation = new HashSet<Pessoa>();
        }

        public int IdCategoria { get; set; }
        public string NmCategoria { get; set; }
        public int? IdCategoriaPai { get; set; }
        public string SnFixo { get; set; }
        public int? IdPessoa { get; set; }
        public decimal? VlMeta { get; set; }
        public int? QtLancamentosPeriodo { get; set; }
        public int? IdTipoLancamento { get; set; }
        public int? IdContaPadrao { get; set; }
        public string SnPrincipal { get; set; }
        public int? SnMostraPrevisao { get; set; }
        public string SnMensal { get; set; }
        public string SnAnual { get; set; }
        public string SnEssencial { get; set; }
        public string SnSuperfulo { get; set; }
        public string SnExporatico { get; set; }

        public virtual Categoria IdCategoriaPaiNavigation { get; set; }
        public virtual Conta IdContaPadraoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Categoria> InverseIdCategoriaPaiNavigation { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }

        public virtual ICollection<Pessoa> InverseIdPessoaNavigation { get; set; }
    }
}
