using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Pieces;

namespace Chess
{
    internal class SomeSortOfFuncHolder
    {
        public static bool isCheck(Piece[,] board, bool turn)
        {
            List<Vector> attacks = getAttacks(board, !turn);

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Piece thisPiece = board[x, y];

                    Vector thisPos = new Vector(x, y);


                    if (thisPiece.DisplayName == 'K' && thisPiece.isWhite == turn)
                    {
                        if (thisPos.findInList(attacks))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static List<Vector> getAttacks(Piece[,] board, bool turn)
        {
            List<Vector> attacks = new List<Vector>();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Piece thisPiece = board[x, y];
                    Vector thisPos = new Vector(x, y);

                    if (thisPiece.isWhite == turn)
                    {
                        /*
                        List<Vector> demAttacks = new List<Vector>();
                        if (thisPiece.DisplayName == 'K')
                            King newP = Convert.ChangeType(thisPiece, King);
                            thisPiece.fakeGetAttack(thisPos, ref board);
                        else
                            demAttacks = thisPiece.getAttack(thisPos, ref board);
                        */

                        foreach (Vector v in thisPiece.getAttack(thisPos, ref board))
                        {
                            if (-1 < v.x && v.x < 8 && -1 < v.y && v.y < 8)
                            {
                                if (board[v.x, v.y].DisplayName != ' ')
                                {
                                    if (thisPiece.isWhite != board[v.x, v.y].isWhite)
                                    {
                                        attacks.Add(v);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return attacks;
        }
    }
}
