using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class King : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = new List<Vector>();

            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    tosend.Add(new Vector(selfPos.x + i, selfPos.y + j));

            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            return getAttack(selfPos, ref board);
        }

        public King(bool color)
        {
            DisplayName = 'K';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
