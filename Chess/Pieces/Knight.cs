using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Knight : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            return new List<Vector>() {
                new Vector(selfPos.x+1, selfPos.y+2), new Vector(selfPos.x-1, selfPos.y+2),
                new Vector(selfPos.x+1, selfPos.y-2), new Vector(selfPos.x-1, selfPos.y-2),
                new Vector(selfPos.x+2, selfPos.y+1), new Vector(selfPos.x+2, selfPos.y-1),
                new Vector(selfPos.x-2, selfPos.y+1), new Vector(selfPos.x-2, selfPos.y-1)
            };
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            return getAttack(selfPos, ref board);
        }

        public Knight(bool color)
        {
            DisplayName = 'H'; // h for horse since king has k
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
