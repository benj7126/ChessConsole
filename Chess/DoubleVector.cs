using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DoubleVector
{
    // define all the varaible positions
    public int x1;
    public int y1;
    public int x2;
    public int y2;

    public bool findInList(List<DoubleVector> moves) // see if there are any double vectors that look like this one in given list
    {
        foreach (DoubleVector doubleVector in moves)
            if (doubleVector.x1 == x1 && doubleVector.y1 == y1 && doubleVector.x2 == x2 && doubleVector.y2 == y2)
                return true;

        return false;
    }

    public DoubleVector(int x1, int y1, int x2, int y2) // on difinition of a doublevector
    {
        // give valuse to the variables
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }
}