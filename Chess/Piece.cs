using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Piece
{
    public bool isWhite = true;
    public char DisplayName = ' ';

    public abstract List<Vector> getMovement(Vector selfPos, ref Piece[,] board);
    public abstract List<Vector> getAttack(Vector selfPos, ref Piece[,] board);

    public int boolToNr(bool boolIn) // used to reverse y if piece is black
    {
        if (boolIn)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public void PieceOut()
    {
        Console.Write($"[{DisplayName}]");
    }
}