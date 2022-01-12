using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class RoyalGuard : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            return new List<Vector>() {
                new Vector(selfPos.x+1, selfPos.y+3), new Vector(selfPos.x-1, selfPos.y+3),
                new Vector(selfPos.x+1, selfPos.y-3), new Vector(selfPos.x-1, selfPos.y-3),
                new Vector(selfPos.x+3, selfPos.y+1), new Vector(selfPos.x+3, selfPos.y-1),
                new Vector(selfPos.x-3, selfPos.y+1), new Vector(selfPos.x-3, selfPos.y-1)
            };
        }
        public Vector kingPos(Piece[,] board)
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
        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = getAttack(selfPos, ref board);
            Vector kingMvmnt = kingPos(board);
            tosend.Add(new Vector(kingMvmnt.x -1, kingMvmnt.y));
            tosend.Add(new Vector(kingMvmnt.x+1, kingMvmnt.y));
            tosend.Add(new Vector(kingMvmnt.x, kingMvmnt.y-1));
            tosend.Add(new Vector(kingMvmnt.x, kingMvmnt.y+1));
            return tosend;
        }
        public RoyalGuard (bool color)
        {
            DisplayName = 'G';
            isWhite = color;
        }
    }
}
