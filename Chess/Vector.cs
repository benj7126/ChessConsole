using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Vector
{
    public int x;
    public int y;

    public Vector(int xIn, int yIn)
    {
        x = xIn;
        y = yIn;
    }

    public override bool Equals(object? obj)
    {
        Vector v = obj as Vector;
        if (v == null)
            return false;
        else
            return x==v.x && y == v.y;
    }

    public bool findInList(List<Vector> checkVecs)
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

    public override string ToString()
    {
        return x + "|" + y;
    }
}