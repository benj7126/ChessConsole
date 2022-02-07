using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Vector
{
    //x n y
    public int x;
    public int y;

    public Vector(int xIn, int yIn) // define it
    {
        x = xIn;
        y = yIn;
    }

    public override bool Equals(object? obj) // i dont know how to make == work for it, so we using this instead
    {
        Vector v = obj as Vector;
        if (v == null)
            return false;
        else
            return x==v.x && y == v.y;
    }

    public bool findInList(List<Vector> checkVecs) // find this in a list of vectors
    {
        foreach (Vector vector in checkVecs)
        {
            if (x == vector.x && y == vector.y)
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString() // if i need to represent it
    {
        return x + "|" + y;
    }
}