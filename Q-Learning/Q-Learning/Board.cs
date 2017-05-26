using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    class Board
    {
        static private int[,] TicTacToeBoard;

        public Board()
        {
            if (TicTacToeBoard == null)
            {
                TicTacToeBoard = new int[3, 3];
            }
        }
        public int getHashedBoard()
        {
            string temp = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp += TicTacToeBoard[i, j];
                }
            }
            return temp.GetHashCode();
        }
        public int[,] getBoard()
        {
            return TicTacToeBoard;
        }
        public List<Action> getPossibleMoves(int player)
        {
            List<Action> moves = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (TicTacToeBoard[i,j] == 0)
                    {
                        moves.Add(new Action(i,j,0.5,player));
                    }
                }
            }
            return moves;
        }
        public void placeBrick(int player, int x, int y)
        {
            TicTacToeBoard[x, y] = player;
        }
        public void placeBrick(Action action)
        {
            TicTacToeBoard[action.moveX, action.moveY] = action.player;
        }
        public void ClearBoard()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    TicTacToeBoard[x, y] = 0;
                }
            }
        }
        public int checkForWin(int turn)
        {
            if (TicTacToeBoard[0, 0] == TicTacToeBoard[0, 1] && TicTacToeBoard[0, 0] == TicTacToeBoard[0, 2] && TicTacToeBoard[0, 0] != 0)
            { //de 3 vandret øverste er ens
                return TicTacToeBoard[0, 0];
            }
            if (TicTacToeBoard[1, 0] == TicTacToeBoard[1, 1] && TicTacToeBoard[1, 0] == TicTacToeBoard[1, 2] && TicTacToeBoard[1, 0] != 0)
            { //de 3  vandret midten er ens
                return TicTacToeBoard[1, 0];
            }
            if (TicTacToeBoard[2, 0] == TicTacToeBoard[2, 1] && TicTacToeBoard[2, 0] == TicTacToeBoard[2, 2] && TicTacToeBoard[2, 0] != 0)
            { //de 3 vandret nederste er ens
                return TicTacToeBoard[2, 0];
            }
            if (TicTacToeBoard[0, 0] == TicTacToeBoard[1, 0] && TicTacToeBoard[0, 0] == TicTacToeBoard[2, 0] && TicTacToeBoard[0, 0] != 0)
            { //de 3 til lodret venstre er ens
                return TicTacToeBoard[0, 0];
            }
            if (TicTacToeBoard[0, 1] == TicTacToeBoard[1, 1] && TicTacToeBoard[0, 1] == TicTacToeBoard[1, 2] && TicTacToeBoard[0, 1] != 0)
            { //de 3 i lodret midten er ens
                return TicTacToeBoard[1, 0];
            }
            if (TicTacToeBoard[0, 2] == TicTacToeBoard[1, 2] && TicTacToeBoard[0, 2] == TicTacToeBoard[2, 2] && TicTacToeBoard[0, 2] != 0)
            { //de 3 til lodret højre er ens
                return TicTacToeBoard[2, 0];
            }
            if (TicTacToeBoard[0, 0] == TicTacToeBoard[1, 1] && TicTacToeBoard[0, 0] == TicTacToeBoard[2, 2] && TicTacToeBoard[0, 0] != 0)
            { //de 3 på tværs fra øverste ventre
                return TicTacToeBoard[0, 0];
            }
            if (TicTacToeBoard[0, 2] == TicTacToeBoard[1, 1] && TicTacToeBoard[0, 2] == TicTacToeBoard[2, 0] && TicTacToeBoard[0, 2] != 0)
            { //de 3 på tværs fra øverste højre
                return TicTacToeBoard[0, 2];
            }
            if (turn == 9)
            {
                return 0;
            }
            return -1;
        }
        public int[,] getTempBoard()
        {
            int[,] tempBoard = new int[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    tempBoard[x, y] = TicTacToeBoard[x, y];
                }
            }
            return tempBoard;
        }
        
    }
}
