using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class PessoaCaracteristica
    {
        public int IdPessoaCaracteristica { get; set; }
        public int IdPessoa { get; set; }
        public int IdTipoCaracteristica { get; set; }
        public string VlValor { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
