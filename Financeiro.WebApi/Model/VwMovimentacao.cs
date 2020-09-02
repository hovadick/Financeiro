using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class VwMovimentacao
    {
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string FormaDePagamento { get; set; }
        public string Descrição { get; set; }
        public decimal? ValorReal { get; set; }
        public decimal? ValorDébito { get; set; }
        public decimal? ValorCrédito { get; set; }
        public decimal ValorMovimentação { get; set; }
        public DateTime DataMovimentação { get; set; }
        public DateTime Competência { get; set; }
        public string TipoMovimentação { get; set; }
        public int? Parcela { get; set; }
        public string Compartilhador { get; set; }
        public decimal? ValorRetorno { get; set; }
        public DateTime CompData { get; set; }
        public short CompAno { get; set; }
        public short CompMes { get; set; }
        public string CompNomeMes { get; set; }
        public short CompBimestre { get; set; }
        public short CompTrimestre { get; set; }
        public short CompSemestre { get; set; }
        public int IdDimTempo { get; set; }
        public DateTime Data { get; set; }
        public short Ano { get; set; }
        public short Mes { get; set; }
        public short Dia { get; set; }
        public short DiaSemana { get; set; }
        public short DiaAno { get; set; }
        public string AnoBissexto { get; set; }
        public string DiaUtil { get; set; }
        public string FimSemana { get; set; }
        public string Feriado { get; set; }
        public string PreFeriado { get; set; }
        public string PosFeriado { get; set; }
        public string NomeFeriado { get; set; }
        public string NomeDiaSemana { get; set; }
        public string NomeDiaSemanaAbrev { get; set; }
        public string NomeMes { get; set; }
        public string NomeMesAbrev { get; set; }
        public short Quinzena { get; set; }
        public short Bimestre { get; set; }
        public short Trimestre { get; set; }
        public short Semestre { get; set; }
        public short NrSemanaMes { get; set; }
        public short NrSemanaAno { get; set; }
        public string EstacaoAno { get; set; }
        public string DataPorExtenso { get; set; }
        public string Evento { get; set; }
    }
}
