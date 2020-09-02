using System;
using System.Collections.Generic;

namespace EFCore.Financeiro
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Categoria = new HashSet<Categoria>();
            Conta = new HashSet<Conta>();
            Fornecedor = new HashSet<Fornecedor>();
            Movimentacao = new HashSet<Movimentacao>();
            PessoaCaracteristica = new HashSet<PessoaCaracteristica>();
        }

        public int IdPessoa { get; set; }
        public string NmPessoa { get; set; }
        public string TxEmail { get; set; }
        public int? IdTipoCadastro { get; set; }
        public string TxSenha { get; set; }
        public string SnPrevisaoSaldoMensal { get; set; }
        public string Bloqueado { get; set; }
        public DateTime? DataCadastro { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<Conta> Conta { get; set; }
        public virtual ICollection<Fornecedor> Fornecedor { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }
        public virtual ICollection<PessoaCaracteristica> PessoaCaracteristica { get; set; }

        public static implicit operator Pessoa(HashSet<Pessoa> v)
        {
            throw new NotImplementedException();
        }
    }
}
