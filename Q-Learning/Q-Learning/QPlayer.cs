using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    class QPlayer
    {
        Board board;
        int playerMe;
        Dictionary<int, Q_Node> MoveBank;
        List<Action> ActionsTaken;
        Random Rando = new Random();

        public QPlayer(Board board, int player)
        {
            this.playerMe = player;
            this.board = board;
            MoveBank = new Dictionary<int, Q_Node>();
            ActionsTaken = new List<Action>();
        }
        public void Play()
        {
            int boardstate = board.getHashedBoard();
            if (MoveBank.ContainsKey(boardstate)) //If we know this boardstate, pick and do the best move
            {
                List<Action> SortedList = MoveBank[boardstate].possibleMoves.OrderBy(o => o.point).ToList();
                SortedList.Reverse();
                board.placeBrick(SortedList[0]);

                ActionsTaken.Add(SortedList[0]);
            }
            else //If we don't know this boardstate make a random move, and add the boardstate to the bank
            {
                Q_Node Qnode = new Q_Node(board.getHashedBoard(), board.getPossibleMoves(playerMe));
                MoveBank.Add(board.getHashedBoard(), Qnode);
                board.placeBrick(Qnode.possibleMoves[Rando.Next(0, Qnode.possibleMoves.Count)]);
                ActionsTaken.Add(Qnode.possibleMoves[Rando.Next(0, Qnode.possibleMoves.Count)]);
            }
        }
        private void Clear()
        {
            ActionsTaken.Clear();
        }
        public void Learning(int winningPlayer)
        {
            if (winningPlayer == playerMe)
            {
                for (int i = 0; i < ActionsTaken.Count; i++)
                {
                    ActionsTaken[i].point += 0.01;
                }
            }
            else
            {
                for (int i = 0; i < ActionsTaken.Count; i++)
                {
                    ActionsTaken[i].point -= 0.01;
                }
            }
            Clear();
        }
    }
}
