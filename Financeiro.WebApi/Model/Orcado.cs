using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class Orcado
    {
        public int IdOrcado { get; set; }
        public int IdPessoa { get; set; }
        public int? IdSubcategoria { get; set; }
        public DateTime? DtCompetencia { get; set; }
        public double? VlOrcado { get; set; }
    }
}
