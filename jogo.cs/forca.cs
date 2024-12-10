using System;
using System.Collections.Generic;

namespace JogoDaForca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Jogo da Forca!");
            Console.WriteLine("Você tem 6 tentativas para adivinhar a palavra.");
            Console.WriteLine();

            string[] palavras = { "programacao", "desenvolvimento", "algoritmo", "tecnologia", "computador", "inteligencia" };
            Random random = new Random();
            string palavraSecreta = palavras[random.Next(palavras.Length)];

            char[] letrasDescobertas = new string('_', palavraSecreta.Length).ToCharArray();
            HashSet<char> letrasTentadas = new HashSet<char>();
            int tentativasRestantes = 6;

            while (tentativasRestantes > 0 && new string(letrasDescobertas) != palavraSecreta)
            {
                MostrarEstadoAtual(letrasDescobertas, letrasTentadas, tentativasRestantes);

                Console.Write("Digite uma letra: ");
                string entrada = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(entrada) || entrada.Length != 1)
                {
                    Console.WriteLine("Por favor, digite apenas uma letra.");
                    continue;
                }

                char letra = entrada[0];

                if (letrasTentadas.Contains(letra))
                {
                    Console.WriteLine($"Você já tentou a letra '{letra}'. Tente outra.");
                    continue;
                }

                letrasTentadas.Add(letra);

                if (palavraSecreta.Contains(letra))
                {
                    Console.WriteLine("Boa! Você acertou uma letra.");
                    for (int i = 0; i < palavraSecreta.Length; i++)
                    {
                        if (palavraSecreta[i] == letra)
                        {
                            letrasDescobertas[i] = letra;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ops! Essa letra não está na palavra.");
                    tentativasRestantes--;
                }
            }

            Console.Clear();
            if (new string(letrasDescobertas) == palavraSecreta)
            {
                Console.WriteLine("Parabéns! Você venceu!");
            }
            else
            {
                Console.WriteLine("Game Over! Você perdeu.");
            }

            Console.WriteLine($"A palavra era: {palavraSecreta}");
        }

        static void MostrarEstadoAtual(char[] letrasDescobertas, HashSet<char> letrasTentadas, int tentativasRestantes)
        {
            Console.Clear();
            Console.WriteLine("Palavra: " + string.Join(" ", letrasDescobertas));
            Console.WriteLine("Letras tentadas: " + string.Join(", ", letrasTentadas));
            Console.WriteLine("Tentativas restantes: " + tentativasRestantes);
            MostrarBoneco(tentativasRestantes);
            Console.WriteLine();
        }

        static void MostrarBoneco(int tentativasRestantes)
        {
            string[] boneco = {
                "   +---+",
                "   |   |",
                tentativasRestantes < 6 ? "   O   |" : "       |",
                tentativasRestantes < 5 ? "  /|\\  |" : "       |",
                tentativasRestantes < 4 ? "  / \\  |" : "       |",
                "       |",
                "========="
            };

            foreach (var linha in boneco)
            {
                Console.WriteLine(linha);
            }
        }
    }
}
