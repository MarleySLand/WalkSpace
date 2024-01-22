using System;
using System.Linq;
using System.Collections.Generic;
using WalkSpace.Entities.Enums;

namespace WalkSpace.Entities
{
    class Player : Character
    {
        public int CatchedChs { get; set; }
        public Player(int movements, Position pos, Space space) : base(movements, pos, space)
        {
            Color = Colors.Green;
        }

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
