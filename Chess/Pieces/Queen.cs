using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Queen : Piece // the queen
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board) // attack
        {
            List<Vector> tosend = new List<Vector>();
            for (int d = 0; d < 8; d++) // for all direction
            {
                for (int m = 1; m < Math.Sqrt(board.Length); m++) // for max movement
                {
                    Vector thisPos = posFromData(selfPos, d, m); // get the position of given m and d
                    if (-1 < thisPos.x && thisPos.x < Math.Sqrt(board.Length) && -1 < thisPos.y && thisPos.y < Math.Sqrt(board.Length))
                    {
                        if (board[thisPos.x, thisPos.y].isWhite != isWhite || board[thisPos.x, thisPos.y].DisplayName == ' ')
                            tosend.Add(thisPos); // if the piece is blank or not the same color as this add it to attack

                        if (board[thisPos.x, thisPos.y].DisplayName != ' ')
                            break; // if the piece is not empty
                    }
                }
            }
            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board) // get movement
        {
            return getAttack(selfPos, ref board); // same as attack
        }

        private Vector posFromData(Vector selfPos, int d, int m) // takes a direction and a distance m and gives a possition based on current position
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

        public Queen(bool color) // on definition
        {
            DisplayName = 'Q';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
