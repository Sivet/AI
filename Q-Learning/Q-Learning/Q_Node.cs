using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    class Q_Node
    {
        public int boardState { get; private set; }
        public List<Action> possibleMoves;
        public Q_Node(int boardState, List<Action> moves)
        {
            this.boardState = boardState;
            this.possibleMoves = moves;
        }
        public Q_Node()
        {

        }
    }
}
