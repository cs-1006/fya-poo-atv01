using System;

public class CofreDigital
{
    // [ ] Encapsulamento: Atributos privados
    private readonly string _dono; // [ ] Campo Somente Leitura (Dono não muda)
    private string _senha;
    private bool _estaAberto;
    private int _tentativasErradas;
    private bool _bloqueado;

    // [ ] Construtor: Estado inicial obrigatório
    public CofreDigital(string dono, string senhaInicial)
    {
        _dono = dono;
        _senha = senhaInicial;
        _estaAberto = false;
        _tentativasErradas = 0;
        _bloqueado = false;
    }

    // [ ] Campo Calculado / Leitura: Exposto apenas o necessário
    public string Dono => _dono;
    public bool EstaAberto => _estaAberto; // Regra de Ouro: Leitura externa apenas

    // Métodos de Lógica de Negócio
    public void Abrir(string senhaInformada)
    {
        if (_bloqueado)
        {
            Console.WriteLine("ERRO: Cofre Bloqueado devido a múltiplas tentativas erradas!");
            return;
        }

        if (senhaInformada == _senha)
        {
            _estaAberto = true;
            _tentativasErradas = 0;
            Console.WriteLine("Cofre aberto com sucesso.");
        }
        else
        {
            _tentativasErradas++;
            Console.WriteLine($"Senha incorreta! Tentativa {_tentativasErradas} de 3.");
            
            if (_tentativasErradas >= 3)
            {
                _bloqueado = true;
                Console.WriteLine("ALERTA: O cofre foi bloqueado permanentemente!");
            }
        }
    }

    public void Fechar()
    {
        _estaAberto = false;
        Console.WriteLine("Cofre fechado.");
    }

    public void AlterarSenha(string senhaAntiga, string novaSenha)
    {
        // [ ] Lógica de Negócio: Validação dupla (Aberto + Senha Antiga)
        if (!_estaAberto)
        {
            Console.WriteLine("Erro: O cofre precisa estar ABERTO para alterar a senha.");
            return;
        }

        if (senhaAntiga == _senha)
        {
            _senha = novaSenha;
            Console.WriteLine("Senha alterada com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro: Senha antiga não confere.");
        }
    }

    // [ ] Sobrescrita ToString
    public override string ToString()
    {
        string status = _bloqueado ? "BLOQUEADO" : (_estaAberto ? "Aberto" : "Fechado");
        return $"[Cofre de {_dono}] Status: {status} | Erros: {_tentativasErradas}/3";
    }
}

class Program
{
    static void Main()
    {
        CofreDigital meuCofre = new CofreDigital("Seu Nome", "1234");

        // Testando erro e bloqueio
        meuCofre.Abrir("0000"); // Erro 1
        meuCofre.Abrir("1111"); // Erro 2
        meuCofre.Abrir("2222"); // Erro 3 -> Bloqueia
        
        meuCofre.Abrir("1234"); // Tenta a certa após bloqueio (deve falhar)

        Console.WriteLine(meuCofre);
    }
}
