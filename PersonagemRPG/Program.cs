using System;
namespace Atividade04;

    public class PersonagemRPG
    {
        // [ ] Encapsulamento: Atributos privados
        private readonly string _nome;
        private readonly string _classe;
        private int _nivel;
        private double _vidaAtual;
        private double _vidaMaxima;

        // [ ] Construtor: Lógica de inicialização baseada na classe
        public PersonagemRPG(string nome, string classe)
        {
            _nome = nome;
            _nivel = 1;

            // Validação simples de classe e definição de HP inicial
            if (classe.ToLower() == "guerreiro")
            {
                _classe = "Guerreiro";
                _vidaMaxima = 150;
            }
            else
            {
                _classe = "Mago";
                _vidaMaxima = 80;
            }

            _vidaAtual = _vidaMaxima; // Inicia com vida cheia
        }
        
        public bool EstaVivo => _vidaAtual > 0;

        // Métodos de Lógica de Negócio
        public void ReceberDano(double pontos)
        {
            _vidaAtual -= pontos;
            if (_vidaAtual < 0) _vidaAtual = 0;
            
            Console.WriteLine($"{_nome} recebeu {pontos} de dano. HP: {_vidaAtual}/{_vidaMaxima}");
        }

        public void Curar(double pontos)
        {
            if (!EstaVivo)
            {
                Console.WriteLine($"Erro: {_nome} está morto e não pode ser curado!");
                return;
            }

            _vidaAtual += pontos;
            if (_vidaAtual > _vidaMaxima) _vidaAtual = _vidaMaxima;
            
            Console.WriteLine($"{_nome} foi curado em {pontos} pontos.");
        }

        public void SubirNivel()
        {
            if (!EstaVivo)
            {
                Console.WriteLine($"Erro: {_nome} está morto e não pode subir de nível!");
                return;
            }

            _nivel++;
            _vidaMaxima += _vidaMaxima * 0.10; // Aumenta 10%
            _vidaAtual = _vidaMaxima;         // Restaura vida
            
            Console.WriteLine($"{_nome} subiu para o nível {_nivel}! Vida Máxima aumentada para {_vidaMaxima:F1}.");
        }

        public void Ressuscitar()
        {
            if (EstaVivo)
            {
                Console.WriteLine($"{_nome} já está vivo!");
                return;
            }

            _vidaAtual = _vidaMaxima * 0.5; // Ressuscita com 50% da vida
            Console.WriteLine($"{_nome} ressuscitou com metade da vida!");
        }

        // [ ] Sobrescrita ToString
        public override string ToString()
        {
            string status = EstaVivo ? "Vivo" : "MORTO";
            return $"[{_nome}] ({_classe}) - Lvl [{_nivel}] - HP: [{_vidaAtual:F1}/{_vidaMaxima:F1}] - Status: {status}";
        }
    }

    class Program
    {
        static void Main()
        {
            PersonagemRPG heroi = new PersonagemRPG("Aragorn", "Guerreiro");
            PersonagemRPG mago = new PersonagemRPG("Gandalf", "Mago");

            Console.WriteLine(heroi);
            Console.WriteLine(mago);

            // Simulando combate
            heroi.ReceberDano(100);
            heroi.SubirNivel(); // Cura e aumenta HP máximo
            
            Console.WriteLine(heroi);

            // Simulando morte do Mago
            mago.ReceberDano(90); 
            mago.Curar(10);       // Deve falhar
            mago.SubirNivel();    // Deve falhar
            
            Console.WriteLine(mago);

            mago.Ressuscitar();
            Console.WriteLine(mago);
        }
    }
