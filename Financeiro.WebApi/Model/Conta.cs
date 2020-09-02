using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class Conta
    {
        public Conta()
        {
            Categoria = new HashSet<Categoria>();
            Movimentacao = new HashSet<Movimentacao>();
        }

        public int IdConta { get; set; }
        public int? IdPessoa { get; set; }
        public string NmConta { get; set; }
        public int? IdTipoConta { get; set; }
        public DateTime? DtFechamento { get; set; }
        public DateTime? DtVencimento { get; set; }
        public string SnPrincipal { get; set; }
        public double? VlSaldo { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }
    }
}
