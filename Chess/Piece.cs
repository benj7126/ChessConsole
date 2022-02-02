using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Piece // define the piece base class as an abstract so that i can make custom movement and attack methodes
{
    public bool isWhite = true; // what color it is
    public bool hasMoved = false; // if it has moved (only pawn use this)
    public char DisplayName = ' ';

    public abstract List<Vector> getMovement(Vector selfPos, ref Piece[,] board); // the movemet methode that has not definition
    public abstract List<Vector> getAttack(Vector selfPos, ref Piece[,] board); // the attack methode that has not definition

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

    public void PieceOut() // used to print the display names
    {
        Console.Write($"[{DisplayName}]");
    }
}