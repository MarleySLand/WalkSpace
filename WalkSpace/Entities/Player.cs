using System;
using System.Linq;
using System.Collections.Generic;
using SpaceWalk.Entities.Enums;

namespace SpaceWalk.Entities
{
    class Player : Character
    {
        public Player(int movements, Position pos) : base(movements, pos)
        {
            Color = Colors.Green;
        }

        public override string ToString()
        {
            return "C";
        }
    }

}
