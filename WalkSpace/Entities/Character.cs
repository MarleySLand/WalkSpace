﻿using System;
using System.Linq;
using System.Collections.Generic;
using WalkSpace.Entities.Enums;

namespace WalkSpace.Entities
{

    abstract class Character
    {
        public int Movements { get; set; }
        public Position Pos { get; set; }
        public Colors Color { get; set; }
        public Space SpaceC { get; set; }

        public Character(int movements, Position pos, Space space)
        {
            Movements = movements;
            Pos = new Position(pos.Rows, pos.Columns);
            SpaceC = new Space(space.Rows, space.Columns);
        }

        public Character(int movements, Position pos, Colors color)
        {
            Movements = movements;
            Pos = new Position(pos.Rows, pos.Columns);
            Color = color;
        }

        public Character(int movements, Position pos)
        {
            Movements = movements;
            Pos = new Position(pos.Rows, pos.Columns);
        }

        public override string ToString()
        {
            return " ";
        }
    }

}