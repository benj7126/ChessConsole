using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Chess.Pieces;
using Chess;

internal class Game
{
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

    public ConsoleKeyInfo up;
    public ConsoleKeyInfo down;
    public ConsoleKeyInfo left;
    public ConsoleKeyInfo right;
    public ConsoleKeyInfo select;

    private List<string> printList = new List<string>();

    public Game()
    {
        Board = new Piece[,] {
            { new Rook(true), new Pawn(true), new Empty(), new Joker(false), new Empty(), new Empty(), new Empty(), new Empty(), new Joker(true), new Empty(), new Pawn(false), new Rook(false)},
            { new Knight(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Knight(false)},
            { new Bishop(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Bishop(false)},
            { new Queen(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Queen(false)},
            { new Knight(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Knight(false)},
            { new Rook(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Rook(false)},
            { new Bishop(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Bishop(false)},
            { new Knight(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Knight(false)},
            { new King(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new King(false)},
            { new Bishop(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Bishop(false)},
            { new Knight(true), new Pawn(true), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Empty(), new Pawn(false), new Knight(false)},
            { new Rook(true), new Pawn(true), new Empty(), new Joker(true), new Empty(), new Empty(), new Empty(), new Empty(), new Joker(false), new Empty(), new Pawn(false), new Rook(false)},
        };

        AiValues.Add(' ', 0);
        AiValues.Add('P', 1);
        AiValues.Add('B', 2);
        AiValues.Add('H', 3);
        AiValues.Add('R', 4);
        AiValues.Add('Q', 5);
        AiValues.Add('K', 6);
    }
    
    public void aiYN()
    {
        Console.Clear();
        Console.WriteLine("Do you want to play with the big dum dumb ai on?");
        Console.WriteLine("Alternative is a local 1v1");
        Console.WriteLine("Answer in the form of y/n");
        bool chosen = false;
        while (!chosen)
        {
            ConsoleKey ck = Console.ReadKey(true).Key;
            if (ck == ConsoleKey.Y)
            {
                AiOn = true;
                chosen = true;
                Console.WriteLine("Playing with ai");
            }
            else if (ck == ConsoleKey.N)
            {
                AiOn = false;
                chosen = true;
                Console.WriteLine("Playing local 1v1");
            }
        }


        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
        Console.Clear();
    }
    public void radientSidesYN()
    {
        Console.Clear();
        Console.WriteLine("Should there be alot of color to recognize sides?");
        Console.WriteLine("Answer in the form of y/n");
        bool chosen = false;
        while (!chosen)
        {
            ConsoleKey ck = Console.ReadKey(true).Key;
            if (ck == ConsoleKey.Y)
            {
                colorALOT = true;
                chosen = true;
            }
            else if (ck == ConsoleKey.N)
            {
                colorALOT = false;
                chosen = true;
            }
        }


        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
        Console.Clear();
    }

    public void setKeys()
    {
        Console.WriteLine("Keybinding phase");

        Console.Write("Up key - ");
        up = Console.ReadKey(true); Console.WriteLine(up.Key);
        Console.Write("Down key - ");
        down = Console.ReadKey(true); Console.WriteLine(down.Key);
        Console.Write("Left key - ");
        left = Console.ReadKey(true); Console.WriteLine(left.Key);
        Console.Write("Right key - ");
        right = Console.ReadKey(true); Console.WriteLine(right.Key);
        Console.Write("Select key - ");
        select = Console.ReadKey(true); Console.WriteLine(select.Key);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
        Console.Clear();
    }

    public void BeginLoop()
    {
        bool gameActive = true;
        WriteBoard(new Vector(0, 0));
        while (gameActive)
        {
            List<DoubleVector> dv = new List<DoubleVector>();

            if (SomeSortOfFuncHolder.isCheck(Board, isWhiteTurn))
            {
                dv = SomeSortOfFuncHolder.getAllMoves(Board, isWhiteTurn);
            }

            markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            //move markedPos
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();
            if (isWhiteTurn == false && AiOn)
                aiWork();
            else
                pressedKey = Console.ReadKey(true);

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
                if (selectedSpace.y != -1)
                {
                    if (markedPosition.x == selectedSpace.x && markedPosition.y == selectedSpace.y)
                    {
                        selectedSpace.y = -1; selectedSpace.x = -1;
                    }
                    else
                    {
                        Piece selectedPos = Board[selectedSpace.x, selectedSpace.y];
                        Piece markedPositionPos = Board[markedPosition.x, markedPosition.y];

                        if (Board[markedPosition.x, markedPosition.y].DisplayName != ' ' && Board[markedPosition.x, markedPosition.y].isWhite == isWhiteTurn)
                        {
                            selectedSpace = new Vector(markedPosition.x, markedPosition.y);
                        }
                        else if (markedPosition.findInList(selectedPos.getAttack(selectedSpace, ref Board)) && markedPositionPos.DisplayName != ' ')
                        {
                            if (markedPositionPos.isWhite != isWhiteTurn)
                                moveNUpdate(selectedPos);
                        }
                        else if (markedPosition.findInList(selectedPos.getMovement(selectedSpace, ref Board)) && markedPositionPos.DisplayName == ' ')
                        {
                            moveNUpdate(selectedPos);
                        }
                    }
                }
                else
                    if (Board[markedPosition.x, markedPosition.y].DisplayName != ' ' && Board[markedPosition.x, markedPosition.y].isWhite == isWhiteTurn)
                        selectedSpace = new Vector(markedPosition.x, markedPosition.y);
            }

            // write board to screen

            if (selectedSpace.y == -1)
            {
                WriteBoard(markedPosition);
            }
            else
            {
                Piece selectedPos = Board[selectedSpace.x, selectedSpace.y];
                WriteBoard(markedPosition, sP: selectedSpace, movePos: selectedPos.getMovement(selectedSpace, ref Board), attackPos: selectedPos.getAttack(selectedSpace, ref Board), allowedMoves: dv);
            }

            if(SomeSortOfFuncHolder.isCheck(Board, false))
                if (SomeSortOfFuncHolder.isCheckmate(Board, false))
                {
                    printList.Add("White wins");
                    gameActive = false;
                }

            if (SomeSortOfFuncHolder.isCheck(Board, true))
                if (SomeSortOfFuncHolder.isCheckmate(Board, true))
                {
                    printList.Add("Black wins");
                    gameActive = false;
                }


            //print all from list so that i still have a console, it kinda messes with the board...
            foreach (string str in printList)
            {
                Console.WriteLine(str);
            }
            printList.Clear();
        }
    }

    public void aiWork()
    {
        List<DoubleVector> dv = new List<DoubleVector>();

        if (SomeSortOfFuncHolder.isCheck(Board, isWhiteTurn))
        {
            dv = SomeSortOfFuncHolder.getAllMoves(Board, isWhiteTurn);
        }

        if (dv.Count == 0)
        {
            List<Vector> canTake = new List<Vector>();
            List<Vector> canTakeOrig = new List<Vector>(); // for the origin of the move

            List<Vector> canMove = new List<Vector>();
            List<Vector> canMoveOrig = new List<Vector>(); // for the origin of the move

            for (int y = 0; y < boardSize.x; y++)
            {
                for (int x = 0; x < boardSize.y; x++)
                {
                    Piece thisPiece = Board[x, y];
                    Vector thisPos = new Vector(x, y);

                    if (thisPiece.isWhite == isWhiteTurn)
                    {
                        foreach (Vector v in thisPiece.getAttack(thisPos, ref Board))
                        {
                            if (-1 < v.x && v.x < boardSize.x && -1 < v.y && v.y < boardSize.y)
                            {
                                if (Board[v.x, v.y].DisplayName != ' ')
                                {
                                    if (thisPiece.isWhite != Board[v.x, v.y].isWhite)
                                    {
                                        canTake.Add(v);
                                        canTakeOrig.Add(thisPos);
                                    }
                                }
                            }
                        }
                        foreach (Vector v in thisPiece.getMovement(thisPos, ref Board))
                        {
                            if (-1 < v.x && v.x < boardSize.x && -1 < v.y && v.y < boardSize.y)
                            {
                                if (Board[v.x, v.y].DisplayName == ' ')
                                {
                                    canMove.Add(v);
                                    canMoveOrig.Add(thisPos);
                                }
                            }
                        }
                    }
                }
            }

            if (canTake.Count > 0)
            {
                int maxVal = 0;
                int maxValIndex = 0;
                int index = 0;
                foreach (Vector v in canTake)
                {
                    if (AiValues[Board[v.x, v.y].DisplayName] > maxVal)
                    {
                        maxVal = AiValues[Board[v.x, v.y].DisplayName];
                        maxValIndex = index;
                        index++;
                    }
                }

                if (maxVal != 0)
                {
                    Board[canTake[maxValIndex].x, canTake[maxValIndex].y] = Board[canTakeOrig[maxValIndex].x, canTakeOrig[maxValIndex].y];
                    Board[canTakeOrig[maxValIndex].x, canTakeOrig[maxValIndex].y] = new Empty();
                    isWhiteTurn = !isWhiteTurn;
                    markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
                    return;
                }
            }


            Random rnd = new Random();
            int chosenMove = rnd.Next(canMove.Count - 1);
            Board[canMove[chosenMove].x, canMove[chosenMove].y] = Board[canMoveOrig[chosenMove].x, canMoveOrig[chosenMove].y];
            Board[canMoveOrig[chosenMove].x, canMoveOrig[chosenMove].y] = new Empty();
            isWhiteTurn = !isWhiteTurn;
            markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
        }
        else
        {
            Random rnd = new Random();
            int chosenMove = rnd.Next(dv.Count - 1);
            Board[dv[chosenMove].x1, dv[chosenMove].y1] = Board[dv[chosenMove].x2, dv[chosenMove].y2];
            Board[dv[chosenMove].x2, dv[chosenMove].y2] = new Empty();
            isWhiteTurn = !isWhiteTurn;
            markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
        }
    }

    public void moveNUpdate(Piece selectedPos)
    {
        selectedPos.hasMoved = true;
        Board[markedPosition.x, markedPosition.y] = selectedPos;
        if ((markedPosition.y == 0 || markedPosition.y == 7) && selectedPos.DisplayName == 'P')
            Board[markedPosition.x, markedPosition.y] = new Queen(selectedPos.isWhite); // make this queen when queen is made...
        Board[selectedSpace.x, selectedSpace.y] = new Empty();
        selectedSpace = new Vector(-1, -1);
        isWhiteTurn = !isWhiteTurn;
        markedPosition = isWhiteTurn == true ? markedPosition1 : markedPosition2;
    }

    public void WriteBoard(Vector mP, Vector sP = null, List<Vector> movePos = null, List<Vector> attackPos = null, List<DoubleVector> allowedMoves = null)
    {

        movePos ??= new List<Vector>(); // makes it default to an empty list
        attackPos ??= new List<Vector>(); // same for this
        allowedMoves ??= new List<DoubleVector>(); // same for this
        sP ??= new Vector(-1, -1); // same for this

        bool doAllowedMoves = false;

        if (allowedMoves.Count != 0)
        {
            doAllowedMoves = true;
        }

        Piece selectedPiece = new Empty();
        if (selectedSpace.y != -1)
            selectedPiece = Board[sP.x, sP.y];

        for (int y = 0; y < boardSize.x; y++)
        {
            for (int x = 0; x < boardSize.y; x++)
            {
                Piece thisPiece = Board[x, y];

                Vector thisPos = new Vector(x, y);


                if (sP.Equals(thisPos))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (mP.Equals(thisPos))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    if (thisPiece.DisplayName == ' ')
                    {
                        if (thisPos.findInList(movePos))
                        {
                            if (doAllowedMoves)
                            {
                                if (new DoubleVector(x, y, sP.x, sP.y).findInList(allowedMoves))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    else
                    {
                        if (thisPos.findInList(attackPos))
                        {
                            if (selectedPiece.isWhite != thisPiece.isWhite)
                            {
                                if (doAllowedMoves)
                                {
                                    if (new DoubleVector(x, y, sP.x, sP.y).findInList(allowedMoves))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                             }
                        }
                        else
                        {
                            if (thisPiece.isWhite != isWhiteTurn)
                                if (colorALOT)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                        }

                    }
                }

                thisPiece.PieceOut();
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }
    }
}