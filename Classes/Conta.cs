﻿using Bank_POO.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_POO.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public Conta()
        {
            this.NumeroDaAgencia = "0001";
            Conta.NumeroDaContaSequencial++;
            this.Movimentacoes = new List<Extrato>();
        }

        public double Saldo { get; protected set; }
        public string NumeroDaAgencia{ get; private set; }
        public string NumeroConta { get; protected set; }
        public static int NumeroDaContaSequencial { get; private set; }
        private List<Extrato> Movimentacoes;

        public double ConsultarSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "DEPOSITO", valor));
            this.Saldo += valor;
        }
        
        public bool Sacar(double valor)
        {
            if(valor > this.ConsultarSaldo())
                return false;

            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "DEPOSITO", -valor));

            this.Saldo -= valor;
            return true;
        }

        public string GetCodigoDoBanco()
        {
            return this.CodigoDoBanco;
        }

        public string GetNumeroDaAgencia()
        {
            return this.NumeroDaAgencia; 
        }
        public string GetNumeroDaConta()
        {
            return this.NumeroConta;
        }

        public List<Extrato> Extratos()
        {
            return this.Movimentacoes;
        }
    }
}
