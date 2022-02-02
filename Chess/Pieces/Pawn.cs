using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Pawn : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board) // it can attack like a pawn
        {
            return new List<Vector>() { new Vector(selfPos.x-1, selfPos.y + boolToNr(isWhite)), new Vector(selfPos.x+1, selfPos.y + 1 * boolToNr(isWhite)) };
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board) // it can move 1 forward, based on its color
        {
            if (board[selfPos.x, selfPos.y+boolToNr(isWhite)].DisplayName != ' ')
                return new List<Vector>() { new Vector(selfPos.x, selfPos.y + boolToNr(isWhite)) }; // bool to nr returns what the bool is in a nuber

            if (!hasMoved) // a variable made for this and only used by this...
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
