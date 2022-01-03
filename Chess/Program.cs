using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        int[,] board = new int[7, 7];
        board[5, 1] = 2;
        Console.WriteLine(board[5, 1]);
    }
}