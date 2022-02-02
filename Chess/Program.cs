using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main(string[] args) // this is the main game
    {
        Game game = new Game(); // define the game
        game.setKeys(); // ask to set keys
        game.aiYN(); // ask if ai is a thing
        game.radientSidesYN(); // ask abount colors
        game.BeginLoop(); // begin the game
    }
}