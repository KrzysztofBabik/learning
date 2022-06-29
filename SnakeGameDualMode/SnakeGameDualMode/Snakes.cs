using SnakeGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameDualMode
{
    class Snakes : Circle
    {
        public List<Circle> snake;
        public string directions;
        public bool goLeft, goRight, goDown, goUp;
        public Brush head, body;

        public Snakes(List<Circle> snake, string directions, bool goLeft, bool goRight, bool goDown, bool goUp, Brush head, Brush body)
        {
            this.snake = snake;
            this.directions = directions;
            this.goLeft = goLeft;
            this.goRight = goRight;
            this.goDown = goDown;
            this.goUp = goUp;
            this.head = head;
            this.body = body;
        }
    }
}
