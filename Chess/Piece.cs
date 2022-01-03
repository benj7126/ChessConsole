using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class Piece
    {
        char DisplayName = ' ';

        public abstract int[] getMovement();
    }
}
