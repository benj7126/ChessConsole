using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Chess.Pieces;
using Chess;

class Game
{
    // declare all the variables
    public Piece[,] Board;
    public Vector markedPosition;
    public Vector markedPosition1 = new Vector(0, 0);
    public Vector markedPosition2 = new Vector(0, 0);
    public Vector selectedSpace = new Vector(-1, -1);

    public Vector boardSize = new Vector(12, 12);

    public bool AiOn = true;
    public Dictionary<char, int> AiValues = new Dictionary<char, int>();

    public bool colorALOT = false;

    public bool isWhiteTurn = true;

    // all the keys for both potential players
    public ConsoleKeyInfo up1;
    public ConsoleKeyInfo down1;
    public ConsoleKeyInfo left1;
    public ConsoleKeyInfo right1;
    public ConsoleKeyInfo select1;
    public ConsoleKeyInfo up2;
    public ConsoleKeyInfo down2;
    public ConsoleKeyInfo left2;
    public ConsoleKeyInfo right2;
    public ConsoleKeyInfo select2;

    private List<string> printList = new List<string>();

    public Game()
    {
        // simply just the board
        Board = new Piece[,] {
            { new Rook(true), new Pawn(true), new Empty(), new Jester(false), new Empty(), new Empty(), new Empty(), new Empty(), new Jester(true), new Empty(), new Pawn(false), new Rook(false)},
            { new Knight(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Knight(false)},
            { new Bishop(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Bishop(false)},
            { new Queen(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Queen(false)},
            { new Wizzard(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Wizzard(false)},
            { new Knight(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Knight(false)},
            { new Knight(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Knight(false)},
            { new RoyalGuard(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new RoyalGuard(false)},
            { new King(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new King(false)},
            { new Bishop(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Bishop(false)},
            { new Knight(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Knight(false)},
            { new Rook(true), new Pawn(true), new Empty(), new Jester(true), new Empty(), new Empty(), new Empty(), new Empty(), new Jester(false), new Empty(), new Pawn(false), new Rook(false)},
        };

        // a list of what the ai prioritises, so if it can take 1 R and one Q it takes Q because Q is higher.
        AiValues.Add(' ', 0);
        AiValues.Add('P', 1);
        AiValues.Add('B', 2);
        AiValues.Add('H', 3);
        AiValues.Add('R', 4);
        AiValues.Add('W', 5);
        AiValues.Add('J', 6);
        AiValues.Add('Q', 7);
        AiValues.Add('K', 8);
        AiValues.Add('G', 9);
    }
    
    public void aiYN()
    {
        // ask the player if he wants to play with the ai
        Console.Clear();
        Console.WriteLine("Do you want to play with the big dum dumb ai on?");
        Console.WriteLine("Alternative is a local 1v1");
        Console.WriteLine("Answer in the form of y/n");
        bool chosen = false;
        while (!chosen) // repeat until the player pressed an acceptable key
        {
            ConsoleKey ck = Console.ReadKey(true).Key; // wait for keypress from the player
            if (ck == ConsoleKey.Y)
            { 
                // activate the ai so that the player plays with it
                AiOn = true;
                chosen = true;
                Console.WriteLine("Playing with ai");
            }
            else if (ck == ConsoleKey.N)
            {
                // dissable the ai and ask the player to bind second players keybindings
                AiOn = false;
                chosen = true;
                Console.WriteLine("Playing local 1v1");
                Console.Clear();
                Console.WriteLine("Keybinding for other player");

                Console.Write("Up key - ");
                up2 = Console.ReadKey(true); Console.WriteLine(up2.Key);
                Console.Write("Down key - ");
                down2 = Console.ReadKey(true); Console.WriteLine(down2.Key);
                Console.Write("Left key - ");
                left2 = Console.ReadKey(true); Console.WriteLine(left2.Key);
                Console.Write("Right key - ");
                right2 = Console.ReadKey(true); Console.WriteLine(right2.Key);
                Console.Write("Select key - ");
                select2 = Console.ReadKey(true); Console.WriteLine(select2.Key);

                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true); // wait for a keypress just to let the player take it all in
                Console.Clear();
            }
        }


        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true); // wait for a keypress just to let the player take it all in
        Console.Clear();
    }
    public void radientSidesYN()
    {
        // ask the player weather there should be colors
        Console.Clear();
        Console.WriteLine("Should there be alot of color to recognize sides?");
        Console.WriteLine("Answer in the form of y/n");
        bool chosen = false;
        while (!chosen) // repeat until the player pressed an acceptable key
        {
            ConsoleKey ck = Console.ReadKey(true).Key; // get the key the player pressed
            if (ck == ConsoleKey.Y)
            {
                // set color alot to true so that some tiles are colored
                colorALOT = true;
                chosen = true;
            }
            else if (ck == ConsoleKey.N)
            {
                // set color alot to false so that everything is white
                colorALOT = false;
                chosen = true;
            }
        }


        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true); // wait for a keypress just to let the player take it all in
        Console.Clear();
    }

    public void setKeys()
    {
        // let the player bind his keys
        Console.WriteLine("Keybinding phase");

        // Up down left right and select keys.
        Console.Write("Up key - ");
        up1 = Console.ReadKey(true); Console.WriteLine(up1.Key);
        Console.Write("Down key - ");
        down1 = Console.ReadKey(true); Console.WriteLine(down1.Key);
        Console.Write("Left key - ");
        left1 = Console.ReadKey(true); Console.WriteLine(left1.Key);
        Console.Write("Right key - ");
        right1 = Console.ReadKey(true); Console.WriteLine(right1.Key);
        Console.Write("Select key - ");
        select1 = Console.ReadKey(true); Console.WriteLine(select1.Key);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true); // wait for a keypress just to let the player take it all in
        Console.Clear();
    }

    public void BeginLoop()
    {
        bool gameActive = true;
        WriteBoard(new Vector(0, 0)); // do an initial write board, because it is gonna wait for a key press before writing the board
        while (gameActive) // repeat game loop until game is no longer active.
        {
            List<DoubleVector> dv = new List<DoubleVector>(); // make a list to potential hold all allowed moves
            // dv was because it was a 'DoubleVector'

            if (SomeSortOfFuncHolder.isCheck(Board, isWhiteTurn)) // if there is check, then make it so that the only moves that can be used are the ones that should be allowed in chess
            {
                dv = SomeSortOfFuncHolder.getAllMoves(Board, isWhiteTurn); // get the allowed moves
            }

            // bind all the keys to what was calibrated depending on weather it is white or black turn.
            ConsoleKeyInfo up = isWhiteTurn == true ? up1 : up2;
            ConsoleKeyInfo down = isWhiteTurn == true ? down1 : down2;
            ConsoleKeyInfo left = isWhiteTurn == true ? left1 : left2;
            ConsoleKeyInfo right = isWhiteTurn == true ? right1 : right2;
            ConsoleKeyInfo select = isWhiteTurn == true ? select1 : select2;

            // do the same for the marked position so that it saves the last player position
            markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
            // make sure the cursor is invisible (if the player clicks anywhere it becomes visible agian)
            Console.CursorVisible = false;
            // make sure it is drawn from top left of the screen
            Console.SetCursorPosition(0, 0);

            //move markedPos
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo(); //make a variable for the potental keypress
            if (isWhiteTurn == false && AiOn)
                aiWork(); // if it is black turn, and the ai is activated make the ai do the move.
            else
                pressedKey = Console.ReadKey(true); // get next keypress

            // move the markedPosition based on the keypress, and restrict it within board with max and min
            if (pressedKey == up)
            {
                markedPosition.y = Math.Min(Math.Max(markedPosition.y - 1, 0), boardSize.y-1);
            }
            else if (pressedKey == down)
            {
                markedPosition.y = Math.Min(Math.Max(markedPosition.y + 1, 0), boardSize.y-1);
            }
            else if (pressedKey == left)
            {
                markedPosition.x = Math.Min(Math.Max(markedPosition.x - 1, 0), boardSize.x-1);
            }
            else if (pressedKey == right)
            {
                markedPosition.x = Math.Min(Math.Max(markedPosition.x + 1, 0), boardSize.x-1);
            }
            else if (pressedKey == select)
            {
                if (selectedSpace.y != -1) // if there is currently no selected space selectedSpace.y == -1
                {
                    if (markedPosition.x == selectedSpace.x && markedPosition.y == selectedSpace.y)
                    {
                        // unselect current selected space if the space you select is already selected
                        selectedSpace.y = -1; selectedSpace.x = -1;
                    }
                    else
                    {
                        Piece selectedPos = Board[selectedSpace.x, selectedSpace.y];
                        Piece markedPositionPos = Board[markedPosition.x, markedPosition.y];

                        if (Board[markedPosition.x, markedPosition.y].DisplayName != ' ' && Board[markedPosition.x, markedPosition.y].isWhite == isWhiteTurn)
                        {
                            //if you press a new piece that you alos own, select that instead of what you have currently selected
                            selectedSpace = new Vector(markedPosition.x, markedPosition.y);
                        }
                        else if (markedPosition.findInList(selectedPos.getAttack(selectedSpace, ref Board)) && markedPositionPos.DisplayName != ' ')
                        {
                            // if the move is a part of possibile attacks from the selected positions piece, and its not the same color. Attack it
                            if (markedPositionPos.isWhite != isWhiteTurn)
                                moveNUpdate(selectedPos);
                        }
                        else if (markedPosition.findInList(selectedPos.getMovement(selectedSpace, ref Board)) && markedPositionPos.DisplayName == ' ')
                        {
                            // if the move is a part of possibile moves from the selected positions piece, and its empty. move to there.
                            moveNUpdate(selectedPos);
                        }
                    }
                }
                else // if you dont have anythin selected, try to select where the 'cursor' is
                    if (Board[markedPosition.x, markedPosition.y].DisplayName != ' ' && Board[markedPosition.x, markedPosition.y].isWhite == isWhiteTurn)
                        selectedSpace = new Vector(markedPosition.x, markedPosition.y);
            }

            // write board to screen
            if (selectedSpace.y == -1)
            {
                // just prints the board
                WriteBoard(markedPosition);
            }
            else
            {
                // if there is a space that is selected, telle the write board, and it will use params to write stuff...
                Piece selectedPos = Board[selectedSpace.x, selectedSpace.y];
                WriteBoard(markedPosition, sP: selectedSpace, movePos: selectedPos.getMovement(selectedSpace, ref Board), attackPos: selectedPos.getAttack(selectedSpace, ref Board), allowedMoves: dv);
            }

            if (SomeSortOfFuncHolder.isCheck(Board, false))
            {
                // check if white is checking
                printList.Add("White Check");
                if (SomeSortOfFuncHolder.isCheckmate(Board, false))
                {
                    // check if white is wins
                    printList.Add("White wins");
                    gameActive = false;
                }
            }

            if (SomeSortOfFuncHolder.isCheck(Board, true))
            {
                // check if white is checking
                printList.Add("Black Check");
                if (SomeSortOfFuncHolder.isCheckmate(Board, true))
                {
                    // check if white is wins
                    printList.Add("Black wins");
                    gameActive = false;
                }
            }

            printList.Add("");
            printList.Add("");

            //print all from list so that i still have a console, it kinda messes with the board...
            foreach (string str in printList)
            {
                // write all console writelines, since it would mess the board up if i wrote to the console while it was drawing.
                Console.WriteLine(str);
            }
            printList.Clear();
        }
    }

    public void aiWork()
    {
        List<DoubleVector> dv = new List<DoubleVector>(); // create a list for all my doubleVectors
        // They will only be used if the king is in check

        if (SomeSortOfFuncHolder.isCheck(Board, isWhiteTurn))
        {
            dv = SomeSortOfFuncHolder.getAllMoves(Board, isWhiteTurn);
            // get all possible moves to save the king
        }

        if (dv.Count == 0)
        {
            // basically if there is not check, or there is check and there are no possible moves to save you (aka ai lost)
            List<Vector> canTake = new List<Vector>(); // list to hold all places that you can take
            List<Vector> canTakeOrig = new List<Vector>(); // holds all the original points of the canTake list
            // so it wokrs like canTakeOrig[3] can take the piece at canTake[3]

            List<Vector> canMove = new List<Vector>(); // same as above, except this is only movement
            List<Vector> canMoveOrig = new List<Vector>();

            for (int y = 0; y < boardSize.x; y++)
            {
                for (int x = 0; x < boardSize.y; x++)
                {
                    // go thru all pieces on board
                    Piece thisPiece = Board[x, y]; // save the current piece as thisPiece
                    Vector thisPos = new Vector(x, y); // and the position, for reference

                    if (thisPiece.isWhite == isWhiteTurn) // if it is on ai side then
                    {
                        foreach (Vector v in thisPiece.getAttack(thisPos, ref Board))
                        {
                            // go thru all attacks of this piece and see if they are 'legal'
                            if (-1 < v.x && v.x < boardSize.x && -1 < v.y && v.y < boardSize.y)
                            {
                                // also check if what its attacking is not an Empty piece
                                if (Board[v.x, v.y].DisplayName != ' ')
                                {
                                    if (thisPiece.isWhite != Board[v.x, v.y].isWhite)
                                    {
                                        // add the attack to possible attacks
                                        canTake.Add(v);
                                        canTakeOrig.Add(thisPos);
                                    }
                                }
                            }
                        }
                        foreach (Vector v in thisPiece.getMovement(thisPos, ref Board))
                        {
                            // go thru all movement of this piece and see if they are 'legal'
                            if (-1 < v.x && v.x < boardSize.x && -1 < v.y && v.y < boardSize.y)
                            {
                                // also check if what its moves to is an Empty piece, and also ignore it if it is the wizzard
                                // cuz the wizzard has 2 manny moves, therefore he only moves when the king is in danger
                                // otherwise the random from the ai, would use the Wizzard way too much
                                if (Board[v.x, v.y].DisplayName == ' ' && thisPiece.DisplayName != 'W')
                                {
                                    // add the move to possible moves
                                    canMove.Add(v);
                                    canMoveOrig.Add(thisPos);
                                }
                            }
                        }
                    }
                }
            }

            // check if you can take any pieces
            if (canTake.Count > 0)
            {
                int maxVal = 0;
                int maxValIndex = 0;
                int index = 0;

                foreach (Vector v in canTake)
                {
                    // go thru all pieces and see if the piece has a higer value than the other pieces that you have checked
                    if (AiValues[Board[v.x, v.y].DisplayName] > maxVal)
                    {
                        // if it has, set it as the best 'kill', or whatever its called
                        maxVal = AiValues[Board[v.x, v.y].DisplayName];
                        maxValIndex = index;
                        index++;
                    }
                }

                if (maxVal != 0)
                {
                    // if you found a maxval that was not 0, wich is always, since there are no pieces with a value of 0
                    // make the ai make that move
                    Board[canTake[maxValIndex].x, canTake[maxValIndex].y] = Board[canTakeOrig[maxValIndex].x, canTakeOrig[maxValIndex].y];
                    Board[canTakeOrig[maxValIndex].x, canTakeOrig[maxValIndex].y] = new Empty();
                    isWhiteTurn = !isWhiteTurn;
                    markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
                    markedPosition.y += 1; // for some reason the martked position.y gets moved 1 down when the ai is done moving, so i just move it back
                    return;
                }
            }


            // take a random move from the list of moves that we just calculated
            // this only happes if you cant take a piece
            Random rnd = new Random();
            int chosenMove = rnd.Next(canMove.Count - 1);
            Board[canMove[chosenMove].x, canMove[chosenMove].y] = Board[canMoveOrig[chosenMove].x, canMoveOrig[chosenMove].y];
            Board[canMoveOrig[chosenMove].x, canMoveOrig[chosenMove].y] = new Empty();
            isWhiteTurn = !isWhiteTurn;
            markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
        }
        else
        {
            // go thru list of possible moves to save the king, then save him...
            Random rnd = new Random();
            int chosenMove = rnd.Next(dv.Count - 1);
            Board[dv[chosenMove].x1, dv[chosenMove].y1] = Board[dv[chosenMove].x2, dv[chosenMove].y2];
            Board[dv[chosenMove].x2, dv[chosenMove].y2] = new Empty();
            isWhiteTurn = !isWhiteTurn;
            markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
        }

        markedPosition.y += 1; // for some reason the martked position.y gets moved 1 down when the ai is done moving, so i just move it back
        // lol
    }

    public void moveNUpdate(Piece selectedPos)
    {
        // make the move that the player has selected on the board.

        selectedPos.hasMoved = true;
        Board[markedPosition.x, markedPosition.y] = selectedPos;

        // if the piece is a pawn and at the opposite side of the board, make it a queen
        if ((markedPosition.y == 0 || markedPosition.y == boardSize.y-1) && selectedPos.DisplayName == 'P')
            Board[markedPosition.x, markedPosition.y] = new Queen(selectedPos.isWhite); // make this queen when queen is made...

        Board[selectedSpace.x, selectedSpace.y] = new Empty(); // place a empty at where it came from
        selectedSpace = new Vector(-1, -1);
        isWhiteTurn = !isWhiteTurn;
        markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
    }

    public void WriteBoard(Vector mP, Vector sP = null, List<Vector> movePos = null, List<Vector> attackPos = null, List<DoubleVector> allowedMoves = null)
    { // this takes a lot of parameters, and its hard to explain it all. So i will be explaining it as it goes

        movePos ??= new List<Vector>(); // makes it default to an empty list
        attackPos ??= new List<Vector>(); // same for this
        allowedMoves ??= new List<DoubleVector>(); // same for this
        sP ??= new Vector(-1, -1); // same for this

        // this variable has something to do with, if you should either do any move, or the moves that are the only one that can save the king.
        bool doAllowedMoves = false;

        if (allowedMoves.Count != 0)
        {
            // if the amount of moves that can save the king, is not 0, only use the moves that can save the king.
            doAllowedMoves = true;
        }

        // make a new piece that holds the piece that is selected by the player, defined by selectedPosition (sP)
        // and only make it equals something if a piece is acutally selected
        Piece selectedPiece = new Empty();
        if (selectedSpace.y != -1)
            selectedPiece = Board[sP.x, sP.y];

        // do a loop that loops thru all the pieces on the board
        for (int y = 0; y < boardSize.x; y++)
        { // for y
            for (int x = 0; x < boardSize.y; x++)
            { // and for x

                // define a var for the piece of the current tile
                Piece thisPiece = Board[x, y];

                // define a var that holds the position in a vector, for easier code stuff
                Vector thisPos = new Vector(x, y);


                if (sP.Equals(thisPos)) // if the selectedPosition is the same as this position, change the color to seleced
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (mP.Equals(thisPos)) // if the markedPosition is the same as this position, change the color to marked
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else // if it is neither selected not marked, do all this below
                {
                    if (thisPiece.DisplayName == ' ') // if its a class Empty, aka a blank
                    {
                        if (thisPos.findInList(movePos)) // see if thisPosition is in all positions that can be moved to (by selected piece)
                        {
                            if (doAllowedMoves) // if you need to protect the king
                            {
                                if (new DoubleVector(x, y, sP.x, sP.y).findInList(allowedMoves)) // check if the attack from x, y to sP.x, sP.y is in allowedMoves
                                {
                                    Console.ForegroundColor = ConsoleColor.Green; // show that it is a possible move
                                }
                            }
                            else // otherwise
                            {
                                Console.ForegroundColor = ConsoleColor.Green; // show that it is a possible move
                            }
                        }
                    }
                    else
                    {
                        if (thisPos.findInList(attackPos)) // same as above, but with attack
                        {
                            if (selectedPiece.isWhite != thisPiece.isWhite) // only if the possible attackable piece is not the same color as this
                            {
                                if (doAllowedMoves) // if you need to protect the king
                                {
                                    if (new DoubleVector(x, y, sP.x, sP.y).findInList(allowedMoves)) // same as above, check if move is allowd
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red; // show that it is a possible move
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; // show that it is a possible move
                                }
                             }
                        }
                        else // if its a piece and is not attackable
                        {
                            if (thisPiece.isWhite != isWhiteTurn) // check if its the same color as the turn is
                                if (colorALOT) // and if the player said yes to the color thing
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan; // set the piece to cyan color
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray; // set the piece to gray color
                                }
                        }

                    }
                }

                thisPiece.PieceOut(); // do a print of this pice from the function in Piece
                Console.ForegroundColor = ConsoleColor.White; // return the color of the foreground
            }
            Console.WriteLine();
        }
    }
}