using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Game game = new Game();
        game.setKeys();
        game.aiYN();
        game.BeginLoop();
    }
}