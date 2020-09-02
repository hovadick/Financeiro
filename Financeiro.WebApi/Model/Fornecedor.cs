using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Movimentacao = new HashSet<Movimentacao>();
        }

        public int IdFornecedor { get; set; }
        public string NmFornecedor { get; set; }
        public int? IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }
    }
}
