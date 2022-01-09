using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Empty : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = new List<Vector>();
            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = new List<Vector>();
            return tosend;
        }
    }
}
