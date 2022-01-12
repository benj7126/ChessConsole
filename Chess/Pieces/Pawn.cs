using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Pawn : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            return new List<Vector>() { new Vector(selfPos.x-1, selfPos.y + boolToNr(isWhite)), new Vector(selfPos.x+1, selfPos.y + 1 * boolToNr(isWhite)) };
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            if (board[selfPos.x, selfPos.y+boolToNr(isWhite)].DisplayName != ' ')
                return new List<Vector>() { new Vector(selfPos.x, selfPos.y + boolToNr(isWhite)) };

            if (!hasMoved)
                return new List<Vector>() { new Vector(selfPos.x, selfPos.y + boolToNr(isWhite)), new Vector(selfPos.x, selfPos.y + 2 * boolToNr(isWhite)) };
            else
                return new List<Vector>() { new Vector(selfPos.x, selfPos.y + boolToNr(isWhite)) };
        }

        public Pawn(bool color)
        {
            DisplayName = 'P';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
