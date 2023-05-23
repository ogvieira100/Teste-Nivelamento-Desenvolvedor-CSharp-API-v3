using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Questao1
{
   public class ContaBancaria
    {
        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
        }

        public override string ToString() 
            => $"Conta {Numero}, Titular: {Titular}, Saldo: $ {Saldo}";

       public ContaBancaria(int numero, string titular, double? depositoInicial)
        {
            Numero = numero;
            Titular = titular;
            DepositoInicial = depositoInicial;
            if (depositoInicial.HasValue)
                Saldo += depositoInicial.Value;
        }

        public int Numero { get; private set; }
        public string Titular { get; private set; }
        public double? DepositoInicial { get; private set; }

        public double Saldo { get; private set; }

        public void Deposito(double quantia)
            => Saldo += quantia;
       

        public void AlterarTitular(string titular)
         =>    Titular = titular;
        
        public void Saque(double quantia)
        {
            var taxInstituicao = 3.5d;
            Saldo += ((quantia + taxInstituicao) * -1);
        }
    }
}
