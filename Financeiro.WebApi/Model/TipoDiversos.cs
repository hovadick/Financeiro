using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class TipoDiversos
    {
        public TipoDiversos()
        {
            Movimentacao = new HashSet<Movimentacao>();
        }

        public int IdTipoDiverso { get; set; }
        public string NmTipoDiversos { get; set; }
        public string NmTipoCategoria { get; set; }

        public virtual ICollection<Movimentacao> Movimentacao { get; set; }
    }
}
