using System;

namespace JogoDaVelha
{
    class Jogo
    {
        static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int jogadorAtual = 1;
        static string player;
        static string playerOne;
        static string playerTwo;
        static int totalJogadas = 0;
        static bool endGame = false;

        public void Start()
        {
            Console.WriteLine("Bem vindo ao Jogo da Velha digital!");
            Console.Write("Digite o nome do jogador que será o X (xis):");
            playerOne = Console.ReadLine();
            Console.Write("Digite o nome do jogador que será o O (bolinha):");
            playerTwo = Console.ReadLine();

            while (!endGame)
            {
                player = jogadorAtual == 1 ? playerOne : playerTwo;

                DesenharTabuleiro();
                Console.WriteLine($"Vez do jogador {player}");
                ValidaOpcao();

                if (totalJogadas == 9 && !endGame)
                {
                    DesenharTabuleiro();
                    Console.WriteLine("Empate! Ninguém ganhou e ninguém perdeu.");
                    Console.WriteLine("E acaba o jogo! Pressione qualquer tecla para sair.");
                    Console.ReadKey();
                    endGame = true;
                }
            }

            DesenharTabuleiro();
        }

        static void ValidaOpcao()
        {
            int valor;
            bool escolha = int.TryParse(Console.ReadLine(), out valor);
            int posicao = valor - 1;

            if (escolha)
            {
                if (valor < 1 || valor > 9)
                {
                    Console.WriteLine("Digite somente um número de 1 a 9 que esteja disponível.");
                    ValidaOpcao();
                }
                else if (tabuleiro[posicao] != 'X' && tabuleiro[posicao] != 'O')
                {
                    tabuleiro[posicao] = jogadorAtual == 1 ? 'X' : 'O';
                    totalJogadas++;
                    if (totalJogadas >= 5)
                        VerificarVencedor();
                    jogadorAtual = jogadorAtual == 1 ? 2 : 1;
                }
                else
                {
                    Console.WriteLine($"Poxa, já escolheram a posição {valor}.");
                    Console.WriteLine("Escolha outra posição: ");
                    ValidaOpcao();
                }
            }
            else
            {
                Console.WriteLine("Digite somente um número de 1 a 9 que esteja disponível.");
                ValidaOpcao();
            }
        }

        static void DesenharTabuleiro()
        {
            Console.Clear();
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", tabuleiro[0], tabuleiro[1], tabuleiro[2]);
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", tabuleiro[3], tabuleiro[4], tabuleiro[5]);
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", tabuleiro[6], tabuleiro[7], tabuleiro[8]);
        }

        static void VerificarVencedor()
        {
            // verificando as linhas
            if (tabuleiro[0] == tabuleiro[1] && tabuleiro[1] == tabuleiro[2])
                endGame = true;
            else if (tabuleiro[3] == tabuleiro[4] && tabuleiro[4] == tabuleiro[5])
                endGame = true;
            else if (tabuleiro[6] == tabuleiro[7] && tabuleiro[7] == tabuleiro[8])
                endGame = true;
            // verificando as colunas
            else if (tabuleiro[0] == tabuleiro[3] && tabuleiro[3] == tabuleiro[6])
                endGame = true;
            else if (tabuleiro[1] == tabuleiro[4] && tabuleiro[4] == tabuleiro[7])
                endGame = true;
            else if (tabuleiro[2] == tabuleiro[5] && tabuleiro[5] == tabuleiro[8])
                endGame = true;
            // verificando as diagonais
            else if (tabuleiro[0] == tabuleiro[4] && tabuleiro[4] == tabuleiro[8])
                endGame = true;
            else if (tabuleiro[2] == tabuleiro[4] && tabuleiro[4] == tabuleiro[6])
                endGame = true;


            if (endGame)
            {
                DesenharTabuleiro();
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine($"Vitória do jogador {player}");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine("E acaba o jogo! Pressione qualquer tecla para sair.");
                Console.ReadKey();
            }
        }
    }
}
