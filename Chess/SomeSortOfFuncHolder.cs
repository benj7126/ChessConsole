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

                        List<Vector> demAttacks = new List<Vector>();
                        if (thisPiece.DisplayName == 'K')
                        {
                            King obj = (King)thisPiece;
                            demAttacks = obj.actualAttack(thisPos, ref board);
                            // make the king not do a rule check so that it doesnt infinite loop
                        }
                        else
                        {
                            demAttacks = thisPiece.getAttack(thisPos, ref board);
                        }

                        foreach (Vector v in demAttacks)
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
        public static bool isCheckmate(Piece[,] board, bool turn)
        {
            List<DoubleVector> moves = getAllMoves(board, turn);
            if (moves.Count == 0)
                return true;
            else
                return false;
        }
        public static List<DoubleVector> getAllMoves(Piece[,] board, bool turn)
        {
            List<DoubleVector> moves = new List<DoubleVector>();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Piece thisPiece = board[x, y];
                    Vector thisPos = new Vector(x, y);

                    if (thisPiece.isWhite == turn)
                    {

                        List<Vector> demMoves = new List<Vector>();
                        List<Vector> demAttacks = new List<Vector>();
                        if (thisPiece.DisplayName == 'K')
                        {
                            King obj = (King)thisPiece;
                            demMoves = obj.getMovement(thisPos, ref board);
                            demAttacks = obj.actualAttack(thisPos, ref board);
                            // make the king not do a rule check so that it doesnt infinite loop
                        }
                        else
                        {
                            demMoves = thisPiece.getMovement(thisPos, ref board);
                            demAttacks = thisPiece.getAttack(thisPos, ref board);
                        }

                        foreach (Vector v in demMoves)
                        {
                            if (-1 < v.x && v.x < 8 && -1 < v.y && v.y < 8)
                            {
                                if (board[v.x, v.y].DisplayName == ' ')
                                {
                                    Piece[,] pieces = copyBoard(board);
                                    pieces[v.x, v.y] = pieces[x, y];
                                    pieces[x, y] = new Empty();
                                    if (!SomeSortOfFuncHolder.isCheck(pieces, turn))
                                        moves.Add(new DoubleVector(v.x, v.y, x, y));
                                }
                            }
                        }

                        foreach (Vector v in demAttacks)
                        {
                            if (-1 < v.x && v.x < 8 && -1 < v.y && v.y < 8)
                            {
                                if (board[v.x, v.y].DisplayName != ' ')
                                {
                                    if (thisPiece.isWhite != board[v.x, v.y].isWhite)
                                    {
                                        Piece[,] pieces = copyBoard(board);
                                        pieces[v.x, v.y] = pieces[x, y];
                                        pieces[x, y] = new Empty();
                                        if (!SomeSortOfFuncHolder.isCheck(pieces, turn))
                                            moves.Add(new DoubleVector(v.x, v.y, x, y));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return moves;
        }

        public static Piece[,] copyBoard(Piece[,] theBoard)
        {
            // so that simulating the board dosent affect the real board
            Piece[,] newBoard = new Piece[8,8];

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    newBoard[x, y] = theBoard[x, y];
                }
            }

            return newBoard;
        }
    }
}
