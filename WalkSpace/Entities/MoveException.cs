using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkSpace.Entities
{
    class MoveException : Exception
    {
        public MoveException(string msg) : base(msg)
        {

        }
    }
}
