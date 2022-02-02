using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class King : Piece
    {
        public override List<Vector> getAttack (Vector selfPos, ref Piece[,] board) // do a lot of shit to make it only attack where it can move
        {
            List<Vector> tosend = new List<Vector>();
            
            // go thru all positions in a 3x3 where this piece is center
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (-1 < selfPos.x + i && selfPos.x + i < Math.Sqrt(board.Length) && -1 < selfPos.y + j && selfPos.y + j < Math.Sqrt(board.Length))
                    {
                        if (board[selfPos.x + i, selfPos.y + j].isWhite != isWhite || board[selfPos.x + i, selfPos.y + j].DisplayName == ' ')
                        {
                            // simulate the move of the king, and check if there is check afterwards, if its not in check in the simulation add it.
                            Piece[,] pieces = SomeSortOfFuncHolder.copyBoard(board);
                            pieces[selfPos.x + i, selfPos.y + j] = new King(isWhite);
                            pieces[selfPos.x, selfPos.y] = new Empty();
                            if (!SomeSortOfFuncHolder.isCheck(pieces, isWhite))
                                tosend.Add(new Vector(selfPos.x + i, selfPos.y + j));
                        }
                    }
                }
            }

            return tosend;
        }
        
        public List<Vector> actualAttack(Vector selfPos, ref Piece[,] board) // when it simulates the board, it needs this or it will loop for infinity...
        {
            List<Vector> tosend = new List<Vector>();

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (-1 < selfPos.x + i && selfPos.x + i < Math.Sqrt(board.Length) && -1 < selfPos.y + j && selfPos.y + j < Math.Sqrt(board.Length))
                    {
                        if (board[selfPos.x + i, selfPos.y + j].isWhite != isWhite || board[selfPos.x + i, selfPos.y + j].DisplayName == ' ')
                            tosend.Add(new Vector(selfPos.x + i, selfPos.y + j));
                    }
                }
            }

            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            return getAttack(selfPos, ref board); // Same as attack
        }

        public King(bool color) // define piece
        {
            DisplayName = 'K';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}
