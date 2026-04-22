using System;
namespace Atividade03;

    public class ContaUniversitaria
    {
        private readonly int _numeroConta;
        private string _titular;
        private double _saldo;
        private double _limite;

        // [ ] Construtor: Inicialização de estado
        public ContaUniversitaria(int numero, string titular)
        {
            _numeroConta = numero;
            _titular = titular;
            _saldo = 0;      // Saldo inicial 0
            _limite = 500;   // Limite inicial 500
        }

        // [ ] Propriedades (Getters e Setters)
        public int NumeroConta => _numeroConta;
        
        public string Titular 
        { 
            get => _titular; 
            set => _titular = value; // Regra de Ouro: Titular pode mudar
        }

        public double SaldoTotal => _saldo + _limite;

        public string StatusConta => _saldo < 0 ? "Negativo" : "Positivo";

        // Métodos de Lógica de Negócio
        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                _saldo += valor;
                Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro: O valor do depósito deve ser positivo.");
            }
        }

        public bool Sacar(double valor)
        {
            // [ ] Lógica de Negócio: Validação de Saldo + Limite
            if (valor > 0 && valor <= SaldoTotal)
            {
                _saldo -= valor;
                Console.WriteLine($"Saque de R$ {valor:F2} realizado.");
                return true;
            }
            
            Console.WriteLine($"Erro: Saldo insuficiente para o saque de R$ {valor:F2}.");
            return false;
        }

        // [ ] Sobrescrita ToString
        public override string ToString()
        {
            return $"Conta: [{_numeroConta}] | Titular: {_titular} | Saldo: R$ {_saldo:F2} | Limite: R$ {_limite:F2} | Status: {StatusConta}";
        }
    }

    class Program
    {
        static void Main()
        {
            ContaUniversitaria minhaConta = new ContaUniversitaria(1001, "Nome");

            Console.WriteLine(minhaConta);

            minhaConta.Depositar(200);
            minhaConta.Sacar(600);
            
            Console.WriteLine($"Status atual: {minhaConta.StatusConta}");
            Console.WriteLine(minhaConta);

            // Tentativa de saque maior que o limite total
            minhaConta.Sacar(200);
        }
    }
