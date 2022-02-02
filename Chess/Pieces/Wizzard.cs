using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Wizzard : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = new List<Vector>();

            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = new List<Vector>();

            for (int i = 0; i < Math.Sqrt(board.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(board.Length); j++)
                {
                    if (board[i, j].DisplayName == ' ')
                    {
                        tosend.Add(new Vector(i, j));
                    }
                }
            }

            return tosend;
        }

        public Wizzard(bool color)
        {
            DisplayName = 'W';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
