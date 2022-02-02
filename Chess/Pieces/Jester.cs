using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Jester : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board) // get possible attacks
        {
            List<Vector> tosend = new List<Vector>(); // define a list for possible moves

            tosend.Add(new Vector(selfPos.x + 2, selfPos.y + 2)); // add positions
            tosend.Add(new Vector(selfPos.x + 2, selfPos.y - 2));
            tosend.Add(new Vector(selfPos.x - 2, selfPos.y - 2));
            tosend.Add(new Vector(selfPos.x - 2, selfPos.y + 2));

            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            return getAttack(selfPos, ref board); // the same movement as attack
        }

        public Jester(bool color) // define piece
        {
            DisplayName = 'J';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
