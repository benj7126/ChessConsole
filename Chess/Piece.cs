using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Piece
{
    char DisplayName = ' ';

    public abstract List<Vector> getMovement();
    public abstract List<Vector> getAttack();

    public void PieceOut()
    {
        Console.Write($"[{DisplayName}]");
    }
}