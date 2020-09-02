using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.Financeiro
{
    public partial class FinanceiroContext : DbContext
    {
        public FinanceiroContext()
        {
        }

        public FinanceiroContext(DbContextOptions<FinanceiroContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Movimentacao> Movimentacao { get; set; }
        public virtual DbSet<Orcado> Orcado { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaCaracteristica> PessoaCaracteristica { get; set; }
        public virtual DbSet<TipoDiversos> TipoDiversos { get; set; }
        public virtual DbSet<VwMovimentacao> VwMovimentacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.IdCategoriaPai).HasColumnName("ID_CATEGORIA_PAI");

                entity.Property(e => e.IdContaPadrao).HasColumnName("ID_CONTA_PADRAO");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdTipoLancamento).HasColumnName("ID_TIPO_LANCAMENTO");

                entity.Property(e => e.NmCategoria)
                    .HasColumnName("NM_CATEGORIA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QtLancamentosPeriodo).HasColumnName("QT_LANCAMENTOS_PERIODO");

                entity.Property(e => e.SnAnual)
                    .HasColumnName("SN_ANUAL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SnEssencial)
                    .HasColumnName("SN_ESSENCIAL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SnExporatico)
                    .HasColumnName("SN_EXPORATICO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SnFixo)
                    .IsRequired()
                    .HasColumnName("SN_FIXO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SnMensal)
                    .HasColumnName("SN_MENSAL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SnMostraPrevisao)
                    .HasColumnName("sn_mostra_previsao")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SnPrincipal)
                    .HasColumnName("SN_PRINCIPAL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SnSuperfulo)
                    .HasColumnName("SN_SUPERFULO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VlMeta)
                    .HasColumnName("VL_META")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdCategoriaPaiNavigation)
                    .WithMany(p => p.InverseIdCategoriaPaiNavigation)
                    .HasForeignKey(d => d.IdCategoriaPai)
                    .HasConstraintName("FK_CATEGORIA_CATEGORIA");

                entity.HasOne(d => d.IdContaPadraoNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.IdContaPadrao)
                    .HasConstraintName("FK_CATEGORIA_Conta");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK_CATEGORIA_Pessoa");
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(e => e.IdConta);

                entity.Property(e => e.IdConta).HasColumnName("ID_CONTA");

                entity.Property(e => e.DtFechamento)
                    .HasColumnName("DT_FECHAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtVencimento)
                    .HasColumnName("DT_VENCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdTipoConta).HasColumnName("ID_TIPO_CONTA");

                entity.Property(e => e.NmConta)
                    .HasColumnName("NM_CONTA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SnPrincipal)
                    .HasColumnName("SN_PRINCIPAL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VlSaldo).HasColumnName("VL_SALDO");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK_Conta_Pessoa");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor);

                entity.Property(e => e.IdFornecedor).HasColumnName("ID_FORNECEDOR");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.NmFornecedor)
                    .HasColumnName("NM_FORNECEDOR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Fornecedor)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK_Fornecedor_Pessoa");
            });

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasKey(e => e.IdMvto)
                    .HasName("PK_Mvto");

                entity.HasIndex(e => e.DtCompetencia)
                    .HasName("IX_COMPETENCIA");

                entity.HasIndex(e => e.IdFormaPagto)
                    .HasName("IX_formapagamento");

                entity.HasIndex(e => e.IdSubCategoria)
                    .HasName("IX_SUBCATEGORIA");

                entity.Property(e => e.IdMvto).HasColumnName("id_Mvto");

                entity.Property(e => e.DsMvto)
                    .IsRequired()
                    .HasColumnName("ds_Mvto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DtCompetencia)
                    .HasColumnName("dt_Competencia")
                    .HasColumnType("date");

                entity.Property(e => e.DtMvto)
                    .HasColumnName("dt_Mvto")
                    .HasColumnType("date");

                entity.Property(e => e.IdFormaPagto).HasColumnName("id_formaPagto");

                entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

                entity.Property(e => e.IdMvtoPai).HasColumnName("id_mvto_pai");

                entity.Property(e => e.IdPessoa).HasColumnName("id_pessoa");

                entity.Property(e => e.IdSubCategoria).HasColumnName("id_subCategoria");

                entity.Property(e => e.IdTipoMovimentacao).HasColumnName("id_Tipo_Movimentacao");

                entity.Property(e => e.NrParcela).HasColumnName("nr_parcela");

                entity.Property(e => e.VlMvto)
                    .HasColumnName("vl_mvto")
                    .HasColumnType("money");

                entity.Property(e => e.VlRetorno)
                    .HasColumnName("vl_retorno")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdFormaPagtoNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdFormaPagto)
                    .HasConstraintName("FK_Movimentacao_FormaPagto");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK_Movimentacao_Fornecedor");

                entity.HasOne(d => d.IdMvtoPaiNavigation)
                    .WithMany(p => p.InverseIdMvtoPaiNavigation)
                    .HasForeignKey(d => d.IdMvtoPai)
                    .HasConstraintName("FK_Movimentacao_MovimentacaoPai");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK_Movimentacao_Pessoa");

                entity.HasOne(d => d.IdSubCategoriaNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdSubCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimentacao_Categoria");

                entity.HasOne(d => d.IdTipoMovimentacaoNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdTipoMovimentacao)
                    .HasConstraintName("FK_Movimentacao_TpMovimentacao");
            });

            modelBuilder.Entity<Orcado>(entity =>
            {
                entity.HasKey(e => e.IdOrcado);

                entity.ToTable("ORCADO");

                entity.Property(e => e.IdOrcado).HasColumnName("ID_ORCADO");

                entity.Property(e => e.DtCompetencia)
                    .HasColumnName("DT_COMPETENCIA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdSubcategoria).HasColumnName("ID_SUBCATEGORIA");

                entity.Property(e => e.VlOrcado).HasColumnName("VL_ORCADO");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa);

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.Bloqueado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.IdTipoCadastro).HasColumnName("ID_TIPO_CADASTRO");

                entity.Property(e => e.NmPessoa)
                    .HasColumnName("NM_PESSOA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SnPrevisaoSaldoMensal)
                    .HasColumnName("SN_PREVISAO_SALDO_MENSAL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TxEmail)
                    .HasColumnName("TX_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TxSenha)
                    .HasColumnName("TX_SENHA")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoaCaracteristica>(entity =>
            {
                entity.HasKey(e => e.IdPessoaCaracteristica);

                entity.ToTable("Pessoa_Caracteristica");

                entity.Property(e => e.IdPessoaCaracteristica).HasColumnName("ID_PESSOA_CARACTERISTICA");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdTipoCaracteristica).HasColumnName("ID_TIPO_CARACTERISTICA");

                entity.Property(e => e.VlValor)
                    .HasColumnName("VL_VALOR")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.PessoaCaracteristica)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa_Caracteristica_Pessoa");
            });

            modelBuilder.Entity<VwMovimentacao>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwMovimentacao", "dbo");

                entity.Property(e => e.Ano).HasColumnName("ANO");

                entity.Property(e => e.AnoBissexto)
                    .IsRequired()
                    .HasColumnName("ANO_BISSEXTO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bimestre).HasColumnName("BIMESTRE");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompAno).HasColumnName("comp_ano");

                entity.Property(e => e.CompBimestre).HasColumnName("comp_bimestre");

                entity.Property(e => e.CompData)
                    .HasColumnName("comp_data")
                    .HasColumnType("date");

                entity.Property(e => e.CompMes).HasColumnName("comp_mes");

                entity.Property(e => e.CompNomeMes)
                    .HasColumnName("Comp_Nome_mes")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompSemestre).HasColumnName("Comp_semestre");

                entity.Property(e => e.CompTrimestre).HasColumnName("Comp_trimestre");

                entity.Property(e => e.Compartilhador)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Competência).HasColumnType("date");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date");

                entity.Property(e => e.DataMovimentação)
                    .HasColumnName("Data Movimentação")
                    .HasColumnType("date");

                entity.Property(e => e.DataPorExtenso)
                    .IsRequired()
                    .HasColumnName("DATA_POR_EXTENSO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descrição)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dia).HasColumnName("DIA");

                entity.Property(e => e.DiaAno).HasColumnName("DIA_ANO");

                entity.Property(e => e.DiaSemana).HasColumnName("DIA_SEMANA");

                entity.Property(e => e.DiaUtil)
                    .IsRequired()
                    .HasColumnName("DIA_UTIL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EstacaoAno)
                    .IsRequired()
                    .HasColumnName("ESTACAO_ANO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Evento)
                    .HasColumnName("EVENTO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Feriado)
                    .IsRequired()
                    .HasColumnName("FERIADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FimSemana)
                    .IsRequired()
                    .HasColumnName("FIM_SEMANA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FormaDePagamento)
                    .HasColumnName("Forma de Pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDimTempo).HasColumnName("ID_DIM_TEMPO");

                entity.Property(e => e.Mes).HasColumnName("MES");

                entity.Property(e => e.NomeDiaSemana)
                    .IsRequired()
                    .HasColumnName("NOME_DIA_SEMANA")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NomeDiaSemanaAbrev)
                    .IsRequired()
                    .HasColumnName("NOME_DIA_SEMANA_ABREV")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NomeFeriado)
                    .HasColumnName("NOME_FERIADO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMes)
                    .IsRequired()
                    .HasColumnName("NOME_MES")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMesAbrev)
                    .IsRequired()
                    .HasColumnName("NOME_MES_ABREV")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NrSemanaAno).HasColumnName("NR_SEMANA_ANO");

                entity.Property(e => e.NrSemanaMes).HasColumnName("NR_SEMANA_MES");

                entity.Property(e => e.PosFeriado)
                    .IsRequired()
                    .HasColumnName("POS_FERIADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PreFeriado)
                    .IsRequired()
                    .HasColumnName("PRE_FERIADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Quinzena).HasColumnName("QUINZENA");

                entity.Property(e => e.Semestre).HasColumnName("SEMESTRE");

                entity.Property(e => e.SubCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoMovimentação)
                    .HasColumnName("Tipo Movimentação")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Trimestre).HasColumnName("TRIMESTRE");

                entity.Property(e => e.ValorCrédito)
                    .HasColumnName("Valor Crédito")
                    .HasColumnType("money");

                entity.Property(e => e.ValorDébito)
                    .HasColumnName("Valor Débito")
                    .HasColumnType("money");

                entity.Property(e => e.ValorMovimentação)
                    .HasColumnName("Valor Movimentação")
                    .HasColumnType("money");

                entity.Property(e => e.ValorReal)
                    .HasColumnName("Valor Real")
                    .HasColumnType("money");

                entity.Property(e => e.ValorRetorno)
                    .HasColumnName("Valor Retorno")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<TipoDiversos>(entity =>
            {
                entity.HasKey(e => e.IdTipoDiverso)
                    .HasName("PK_TIPODIVERSOS");

                entity.Property(e => e.IdTipoDiverso).HasColumnName("ID_TIPO_DIVERSO");

                entity.Property(e => e.NmTipoCategoria)
                    .HasColumnName("NM_TIPO_CATEGORIA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NmTipoDiversos)
                    .HasColumnName("NM_TIPO_DIVERSOS")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
