using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    class Program
    {
        Board board = new Board();
        int player1Wins = 0;
        int player2Wins = 0;
        int drawWin = 0;
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }
        public void Run()
        {
            RandomPlayer player2 = new RandomPlayer(board, 2);
            QPlayer player1 = new QPlayer(board, 1);

            for (int i = 0; i < 10000; i++)
            {
                int turnCounter = 0;
                while (board.checkForWin(turnCounter) == -1)
                {
                    player1.Play();
                    turnCounter++;
                    if (board.checkForWin(turnCounter) != -1)
                    {
                        break;
                    }
                    player2.Play();
                    turnCounter++;

                }

                if (board.checkForWin(turnCounter) == 1)
                {
                    player1Wins++;
                }
                if (board.checkForWin(turnCounter) == 2)
                {
                    player2Wins++;
                }
                if (board.checkForWin(turnCounter) == -1 || board.checkForWin(turnCounter) == 0)
                {
                    drawWin++;
                }
                player1.Learning(board.checkForWin(turnCounter));
                
                board.ClearBoard();
            }

            Console.WriteLine("Player 1 won: " + player1Wins);
            Console.WriteLine("Player 2 won: " + player2Wins);
            Console.WriteLine("Number of draws: " + drawWin);
            Console.ReadKey();
        }
        
    }
}
