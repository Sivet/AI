using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    class Action
    {
        public int moveX { get; private set; }
        public int moveY { get; private set; }
        public double point { get; set; }
        public int player { get; private set; }
        public Action(int moveX, int moveY, double point, int player)
        {
            this.moveX = moveX;
            this.moveY = moveY;
            this.point = point;
            this.player = player;
        }
    }
}
