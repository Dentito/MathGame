using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Dictionary<string, List<int>> AlunosENotasRegistrados = new Dictionary<string, List<int>>();
AlunosENotasRegistrados.Add("Pedro", new List<int>());
string nomeAluno;
int ScoreSoma = 0;
int ScoreSub = 0;
int ScoreMult = 0;
int ScoreDiv = 0;

void Jogo()
{
    Console.WriteLine($" ==== Bem vindo {nomeAluno} ao jogo da da matemática ===");
    Console.WriteLine(" ——————————————————————————————————————————————————————— ");
    Console.WriteLine(" ====       Escolha seu jogo abaixo       ===");
}

void RegistrarAluno()
{
    ExibirTituloDaOpcao("Registrar Aluno");
    Console.Write("Iniciar sessão como: ");
    nomeAluno = Console.ReadLine();
    if (AlunosENotasRegistrados.ContainsKey(nomeAluno))
    {

    }
    else
    {
        Console.WriteLine($"{nomeAluno} já cadastrado");

    }
    AlunosENotasRegistrados.Add(nomeAluno, new List<int>());
    Console.Clear();

}

void NotasAlunos()
{
    ExibirTituloDaOpcao($"Score de {nomeAluno}");
    Console.WriteLine($"Score de Soma de {nomeAluno} é: " + ScoreSoma);
    Console.WriteLine($"Score de Subtração de {nomeAluno} é: " + ScoreSub);
    Console.WriteLine($"Score de Multiplicação de {nomeAluno} é: " + ScoreMult);
    Console.WriteLine($"Score de Divisão de {nomeAluno} é: " + ScoreDiv);

    mediaAluno();
}

void mediaAluno()
{
    double media = (ScoreSoma + ScoreDiv + ScoreSub + ScoreMult) / 4.0;
    Console.WriteLine($"A média do {nomeAluno} é: {media}");
}
void JogoSoma()
{
    Console.Clear();
    ExibirTituloDaOpcao("Jogo da Soma");
    Random random = new Random();
    int numero1 = random.Next(1, 101);
    int numero2 = random.Next(1, 101);

    Console.Write($"\n{numero1} + {numero2} = ");
    int resposta = int.Parse(Console.ReadLine());
    if (resposta == numero1 + numero2)
    {
        Thread.Sleep(1000);
        Console.WriteLine("Parabéns! Você acertou!");
        ScoreSoma = ScoreSoma + 1;
        OpcaoContinuarJogando("soma");
    }
    else
    {
        Console.WriteLine($"Que pena! A resposta correta era {numero1 + numero2}");
        OpcaoContinuarJogando("soma");
    }
}

void JogoSubtracao()
{
    Console.Clear();
    ExibirTituloDaOpcao("Jogo da Subtração");
    Random random = new Random();
    int numero1 = random.Next(1, 101);
    int numero2 = random.Next(1, 101);

    Console.Write($"\n{numero1} - {numero2} = ");
    int resposta = int.Parse(Console.ReadLine());

    if (resposta == numero1 - numero2)
    {
        Thread.Sleep(1000);
        Console.WriteLine("Parabéns! Você acertou!");
        ScoreSub = ScoreSub + 1;
        OpcaoContinuarJogando("subtracao");
    }
    else
    {
        Console.WriteLine($"Que pena! A resposta correta era {numero1 - numero2}");
        OpcaoContinuarJogando("subtracao");
    }
}

void JogoMultiplicacao()
{
    Console.Clear();
    ExibirTituloDaOpcao("Jogo da Multiplicação");
    Random random = new Random();
    int numero1 = random.Next(1, 101);
    int numero2 = random.Next(1, 101);

    Console.Write($"\n{numero1} * {numero2} = ");
    int resposta = int.Parse(Console.ReadLine());
    if (resposta == numero1 * numero2)
    {
        Thread.Sleep(1000);
        Console.WriteLine("Parabéns! Você acertou!");
        ScoreMult = ScoreMult + 1;
        OpcaoContinuarJogando("multiplicacao");
    }
    else
    {
        Console.WriteLine($"Que pena! A resposta correta era {numero1 * numero2}");
        OpcaoContinuarJogando("multiplicacao");
    }
}

void JogoDivisao()
{
    Console.Clear();
    ExibirTituloDaOpcao("Jogo da Divisão");
    Random random = new Random();
    int divisorMaX = 10;
    int numero1 = random.Next(1, 20);
    int numero2 = random.Next(1, divisorMaX + 1);

    while (numero1 % numero2 != 0)
    {
        numero1 = random.Next(1, 101);
        numero1 = random.Next(1, divisorMaX + 1);
    }


    Console.Write($"\n{numero1} / {numero2} = ");
    int resposta = int.Parse(Console.ReadLine());
    int resultado = numero1 / numero2;
    if (resposta == resultado)
    {
        Thread.Sleep(1000);
        Console.WriteLine("Parabéns! Você acertou!");
        ScoreDiv = ScoreDiv + 1;
        OpcaoContinuarJogando("divisao");
    }
    else
    {
        Console.WriteLine($"Que pena! A resposta correta era {resultado}");
        OpcaoContinuarJogando("divisao");
    }
}

void OpcaoContinuarJogando(string jogo)
{
    Console.WriteLine("\nDeseja continuar jogando o mesmo jogo?");
    Console.WriteLine("[1] - Sim");
    Console.WriteLine("[2] - Não (Voltar ao menu principal)");

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine();
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            Console.Clear();
            if (jogo == "soma")
                JogoSoma();
            else if (jogo == "subtracao")
                JogoSubtracao();
            else if (jogo == "multiplicacao")
                JogoMultiplicacao();
            else if (jogo == "divisao")
                JogoDivisao();
            else
                Console.WriteLine("Jogo inválido!");
            break;
        case 2:
            Console.Clear();
            Jogo(); // Volta ao menu principal
            ExibirOpcoes();
            break;
        default:
            Console.WriteLine("Opção Inválida");
            OpcaoContinuarJogando(jogo); // Se a opção for inválida, pede novamente
            break;
    }
}

void ExibirOpcoes()
{
    NotasAlunos();
    Console.WriteLine("\n ——————————————————————————————————————————————————————— ");
    Console.WriteLine("\n[1] - Soma");
    Console.WriteLine("\n[2] - Subtração");
    Console.WriteLine("\n[3] - Multiplicação");
    Console.WriteLine("\n[4] - Divisão");
    Console.WriteLine(" ——————————————————————————————————————————————————————— ");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine();
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            Console.WriteLine($"Você escolheu a opção {opcaoEscolhidaNumerica}, Jogo da soma!");
            JogoSoma();
            break;
        case 2:
            Console.WriteLine($"Você escolheu a opção {opcaoEscolhidaNumerica}, Jogo da subtração!");
            JogoSubtracao();
            break;
        case 3:
            Console.WriteLine($"Você escolheu a opção {opcaoEscolhidaNumerica}, Jogo da multiplicação!");
            JogoMultiplicacao();
            break;
        case 4:
            Console.WriteLine($"Você escolheu a opção {opcaoEscolhidaNumerica}, Jogo da divisão!");
            JogoDivisao();
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidaDeLetras = titulo.Length;
    string astericos = string.Empty.PadLeft(quantidaDeLetras, '—');
    Console.WriteLine(astericos);
    Console.WriteLine(titulo);
    Console.WriteLine(astericos + "\n");
}

RegistrarAluno();
Jogo();
//NotasAlunos();
ExibirOpcoes();

//Criar um dicionário que represente um aluno, com uma lista de notas, e mostre a média de suas notas na tela.
//Criar um programa que gerencie o estoque de uma loja. Utilize um dicionário para armazenar produtos e suas quantidades em estoque e mostre, a partir do nome de um produto, sua quantidade em estoque.
//Crie um programa que implemente um quiz simples de perguntas e respostas. Utilize um dicionário para armazenar as perguntas e as respostas corretas.
//Criar um programa que simule um sistema de login utilizando um dicionário para armazenar nomes de usuário e senhas.