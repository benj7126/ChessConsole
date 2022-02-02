using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Bishop : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board) // this returns all possible attacks
        {
            List<Vector> tosend = new List<Vector>(); // prepare a list to send
            for (int d = 0; d < 4; d++) // for all direction
            {
                for (int m = 1; m < Math.Sqrt(board.Length); m++) // for max movement (length of board)
                {
                    Vector thisPos = posFromData(selfPos, d, m); // get position for m spaces in d direction
                    if (-1 < thisPos.x && thisPos.x < Math.Sqrt(board.Length) && -1 < thisPos.y && thisPos.y < Math.Sqrt(board.Length))
                    { // if it is within the board continue

                        // 
                        if (board[thisPos.x, thisPos.y].isWhite != isWhite || board[thisPos.x, thisPos.y].DisplayName == ' ') // if the position checking is not the same color as this piece, or it is an empty, add it to attack
                            tosend.Add(thisPos);

                        if (board[thisPos.x, thisPos.y].DisplayName != ' ') // if the piece at current position stop checking direction
                            break;
                    }
                }
            }
            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            return getAttack(selfPos, ref board); // just take the positions from the attack (reuse code)
        }

        private Vector posFromData(Vector selfPos, int d, int m) // this is what defines movement based on direction
        {
            if (d == 0)
            {
                return new Vector(selfPos.x + m, selfPos.y + m);
            }
            else if (d == 1)
            {
                return new Vector(selfPos.x - m, selfPos.y + m);
            }
            else if (d == 2)
            {
                return new Vector(selfPos.x + m, selfPos.y - m);
            }
            else
            {
                return new Vector(selfPos.x - m, selfPos.y - m);
            }
        }

        public Bishop(bool color) // define the piece
        {
            DisplayName = 'B';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
