using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Queen : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = new List<Vector>();
            for (int d = 0; d < 8; d++) // for all direction
            {
                for (int m = 1; m < Math.Sqrt(board.Length); m++) // for max movement
                {
                    Vector thisPos = posFromData(selfPos, d, m);
                    if (-1 < thisPos.x && thisPos.x < Math.Sqrt(board.Length) && -1 < thisPos.y && thisPos.y < Math.Sqrt(board.Length))
                    {
                        if (board[thisPos.x, thisPos.y].isWhite != isWhite || board[thisPos.x, thisPos.y].DisplayName == ' ')
                            tosend.Add(thisPos);

                        if (board[thisPos.x, thisPos.y].DisplayName != ' ')
                            break;
                    }
                }
            }
            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            return getAttack(selfPos, ref board);
        }

        private Vector posFromData(Vector selfPos, int d, int m)
        {
            if (d == 0)
            {
                return new Vector(selfPos.x + m, selfPos.y);
            }
            else if (d == 1)
            {
                return new Vector(selfPos.x - m, selfPos.y);
            }
            else if (d == 2)
            {
                return new Vector(selfPos.x, selfPos.y + m);
            }
            else if (d == 3)
            {
                return new Vector(selfPos.x, selfPos.y - m);
            }
            else if (d == 4)
            {
                return new Vector(selfPos.x + m, selfPos.y + m);
            }
            else if (d == 5)
            {
                return new Vector(selfPos.x - m, selfPos.y + m);
            }
            else if (d == 6)
            {
                return new Vector(selfPos.x + m, selfPos.y - m);
            }
            else
            {
                return new Vector(selfPos.x - m, selfPos.y - m);
            }
        }

        public Queen(bool color)
        {
            DisplayName = 'Q';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
