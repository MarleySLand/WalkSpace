using System.Linq;
using System.Collections.Generic;
using WalkSpace.Entities.Enums;

namespace WalkSpace.Entities
{
    class Guard : Character
    {
        public Guard(int movements, Position pos, Space space) : base(movements, pos, space)
        {
            Color = Colors.Red;
        }

        public bool[,] Vision()
        {
            bool[,] mat = new bool[SpaceC.Rows, SpaceC.Columns];
            mat[Pos.Rows, Pos.Columns - 1] = true;
            mat[Pos.Rows, Pos.Columns - 2] = true;
            mat[Pos.Rows, Pos.Columns - 3] = true;
            mat[Pos.Rows, Pos.Columns - 4] = true;

            return mat;
        }

        public override string ToString()
        {
            return "G";
        }
    }

}