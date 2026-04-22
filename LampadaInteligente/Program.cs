using System;

public class LampadaInteligente
{
    // [ ] Encapsulamento: Atributos privados
    private readonly string _marca;
    private readonly string _tecnologia; // [ ] Campo Somente Leitura
    private bool _estaLigada;
    private int _brilho;

    // [ ] Construtor: Inicialização obrigatória e estado inicial
    public LampadaInteligente(string marca, string tecnologia)
    {
        _marca = marca;
        _tecnologia = tecnologia;
        _estaLigada = false; // Inicia desligada
        _brilho = 100;       // Brilho inicial em 100%
    }

    // [ ] Campos Calculados: Propriedades apenas com 'get'
    public string Marca => _marca;
    public string Tecnologia => _tecnologia;
    public bool EstaLigada => _estaLigada;
    public int Brilho => _brilho;

    // Métodos de Lógica de Negócio
    public void Alternar()
    {
        _estaLigada = !_estaLigada;
        Console.WriteLine(_estaLigada ? "Lâmpada ligada." : "Lâmpada desligada.");
    }

    public void AjustarBrilho(int novoBrilho)
    {
        // [ ] Lógica de Negócio: Validações (brilho entre 0-100 e apenas se ligada)
        if (!_estaLigada)
        {
            Console.WriteLine("Erro: Não é possível ajustar o brilho com a lâmpada desligada.");
            return;
        }

        if (novoBrilho >= 0 && novoBrilho <= 100)
        {
            _brilho = novoBrilho;
            Console.WriteLine($"Brilho ajustado para: {_brilho}%");
        }
        else
        {
            Console.WriteLine("Erro: O brilho deve estar entre 0 e 100.");
        }
    }

    // [ ] Sobrescrita: ToString para representação do objeto
    public override string ToString()
    {
        string status = _estaLigada ? "Ligada" : "Desligada";
        return $"[Lâmpada {_marca}] Tecnologia: {_tecnologia} | Status: {status} | Brilho: {_brilho}%";
    }

}

class Program
{   
    static void Main()
    {
     LampadaInteligente minhaLampada = new LampadaInteligente("Philips", "LED");

    Console.WriteLine(minhaLampada); // Usa o ToString()
            
    minhaLampada.AjustarBrilho(50); // Deve dar erro (está desligada)
        
    minhaLampada.Alternar();        
    minhaLampada.AjustarBrilho(75); 

    Console.WriteLine(minhaLampada);
    }
} 
