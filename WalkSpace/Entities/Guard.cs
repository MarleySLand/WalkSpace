using System.Linq;
using System.Collections.Generic;
using WalkSpace.Entities.Enums;

namespace WalkSpace.Entities
{
    class Guard : Character
    {
        public Guard(int movements, Position pos) : base(movements, pos)
        {
            Color = Colors.Red;
        }

        public override string ToString()
        {
            return "G";
        }
    }

}