using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Joker : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = new List<Vector>();

            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if (-1 < selfPos.x + i && selfPos.x + i < Math.Sqrt(board.Length) && -1 < selfPos.y + j && selfPos.y + j < Math.Sqrt(board.Length))
                    {
                        if ((board[selfPos.x + i, selfPos.y + j].isWhite != isWhite || board[selfPos.x + i, selfPos.y + j].DisplayName == ' ')
                            && ((i < -1 || i > 1) || (j < -1 || j > 1)))
                            tosend.Add(new Vector(selfPos.x + i, selfPos.y + j));
                    }
                }
            }

            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            return getAttack(selfPos, ref board);
        }

        public Joker(bool color)
        {
            DisplayName = 'J';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
