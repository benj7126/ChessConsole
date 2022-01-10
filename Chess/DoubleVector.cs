using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DoubleVector
{
    public int x1;
    public int y1;
    public int x2;
    public int y2;

    public bool findInList(List<DoubleVector> moves)
    {
        foreach (DoubleVector doubleVector in moves)
            if (doubleVector.x1 == x1 && doubleVector.y1 == y1 && doubleVector.x2 == x2 && doubleVector.y2 == y2)
                return true;

        return false;
    }

    public DoubleVector(int x1In, int y1In, int x2In, int y2In)
    {
        x1 = x1In;
        y1 = y1In;
        x2 = x2In;
        y2 = y2In;
    }
}