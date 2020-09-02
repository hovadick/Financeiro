using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class Movimentacao
    {
        public Movimentacao()
        {
            InverseIdMvtoPaiNavigation = new HashSet<Movimentacao>();
        }

        public int IdMvto { get; set; }
        public DateTime DtMvto { get; set; }
        public DateTime DtCompetencia { get; set; }
        public string DsMvto { get; set; }
        public int IdSubCategoria { get; set; }
        public decimal VlMvto { get; set; }
        public int? IdPessoa { get; set; }
        public int? IdFormaPagto { get; set; }
        public int? IdTipoMovimentacao { get; set; }
        public int? IdMvtoPai { get; set; }
        public int? NrParcela { get; set; }
        public int? IdFornecedor { get; set; }
        public decimal? VlRetorno { get; set; }

        public virtual Conta IdFormaPagtoNavigation { get; set; }
        public virtual Fornecedor IdFornecedorNavigation { get; set; }
        public virtual Movimentacao IdMvtoPaiNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Categoria IdSubCategoriaNavigation { get; set; }
        public virtual TipoDiversos IdTipoMovimentacaoNavigation { get; set; }
        public virtual ICollection<Movimentacao> InverseIdMvtoPaiNavigation { get; set; }
    }
}
