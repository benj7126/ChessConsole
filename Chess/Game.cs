using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Pieces;

internal class Game
{
    public Piece[,] Board = new Piece[7, 7];
  
    public Game()
    {
        Console.WriteLine("a");
        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                Board[x, y] = new Pawn();
                Board[x, y].PieceOut();
            }
            Console.WriteLine();
        }
    }
}