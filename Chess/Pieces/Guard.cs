using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class RoyalGuard : Piece // custom piece RoyalGuard
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            return new List<Vector>() { // same movement as the knight/horse, but slightly modified
                new Vector(selfPos.x+1, selfPos.y+3), new Vector(selfPos.x-1, selfPos.y+3),
                new Vector(selfPos.x+1, selfPos.y-3), new Vector(selfPos.x-1, selfPos.y-3),
                new Vector(selfPos.x+3, selfPos.y+1), new Vector(selfPos.x+3, selfPos.y-1),
                new Vector(selfPos.x-3, selfPos.y+1), new Vector(selfPos.x-3, selfPos.y-1)
            };
        }
        public Vector kingPos(Piece[,] board) // find the position of the king, by looking thru the whole board
        {
            for (int x = 0; x<Math.Sqrt(board.Length); x++)
            {
                for (int y = 0; y < Math.Sqrt(board.Length); y++)
                {
                    Piece thatpiece = board[x, y];
                    if (thatpiece.isWhite == isWhite)
                        if (thatpiece.DisplayName == 'K')
                            return new Vector(x, y);
                }
            }
            return new Vector(-2, -2);
        }
        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board) // gets the possible movement
        {
            // either tp to the king or go to where you could attack

            List<Vector> tosend = getAttack(selfPos, ref board);
            Vector kingMvmnt = kingPos(board);
            tosend.Add(new Vector(kingMvmnt.x -1, kingMvmnt.y));
            tosend.Add(new Vector(kingMvmnt.x+1, kingMvmnt.y));
            tosend.Add(new Vector(kingMvmnt.x, kingMvmnt.y-1));
            tosend.Add(new Vector(kingMvmnt.x, kingMvmnt.y+1));
            return tosend;
        }
        public RoyalGuard (bool color) // define the piece
        {
            DisplayName = 'G';
            isWhite = color;
        }
    }
}
