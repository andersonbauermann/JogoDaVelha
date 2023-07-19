using System;

namespace JogoDaVelha
{
    class Jogo
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer = 1;
        static string player;
        static string playerOne;
        static string playerTwo;
        static int totalMove = 0;
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
                player = currentPlayer == 1 ? playerOne : playerTwo;

                DrawBoard();
                Console.WriteLine($"Vez do jogador {player}");
                ValidateOption();

                if (totalMove == 9 && !endGame)
                {
                    DrawBoard();
                    Console.WriteLine("Empate! Ninguém ganhou e ninguém perdeu.");
                    Console.WriteLine("E acaba o jogo! Pressione qualquer tecla para sair.");
                    Console.ReadKey();
                    endGame = true;
                }
            }

            DrawBoard();
        }

        static void ValidateOption()
        {
            int choice;
            bool validate = int.TryParse(Console.ReadLine(), out choice);
            int position = choice - 1;

            if (validate)
            {
                if (choice < 1 || choice > 9)
                {
                    Console.WriteLine("Digite somente um número de 1 a 9 que esteja disponível.");
                    ValidateOption();
                }
                else if (board[position] != 'X' && board[position] != 'O')
                {
                    board[position] = currentPlayer == 1 ? 'X' : 'O';
                    totalMove++;
                    if (totalMove >= 5)
                        CheckWinner();
                    currentPlayer = currentPlayer == 1 ? 2 : 1;
                }
                else
                {
                    Console.WriteLine($"Poxa, já escolheram a posição {choice}.");
                    Console.WriteLine("Escolha outra posição: ");
                    ValidateOption();
                }
            }
            else
            {
                Console.WriteLine("Digite somente um número de 1 a 9 que esteja disponível.");
                ValidateOption();
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0], board[1], board[2]);
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[3], board[4], board[5]);
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[6], board[7], board[8]);
        }

        static void CheckWinner()
        {
            // verificando as linhas
            if (board[0] == board[1] && board[1] == board[2])
                endGame = true;
            else if (board[3] == board[4] && board[4] == board[5])
                endGame = true;
            else if (board[6] == board[7] && board[7] == board[8])
                endGame = true;
            // verificando as colunas
            else if (board[0] == board[3] && board[3] == board[6])
                endGame = true;
            else if (board[1] == board[4] && board[4] == board[7])
                endGame = true;
            else if (board[2] == board[5] && board[5] == board[8])
                endGame = true;
            // verificando as diagonais
            else if (board[0] == board[4] && board[4] == board[8])
                endGame = true;
            else if (board[2] == board[4] && board[4] == board[6])
                endGame = true;


            if (endGame)
            {
                DrawBoard();
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine($"Vitória do jogador {player}");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine("E acaba o jogo! Pressione qualquer tecla para sair.");
                Console.ReadKey();
            }
        }
    }
}
