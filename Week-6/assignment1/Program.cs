using System;
using System.Collections.Generic;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            ChessPiece[,] chessboard = new ChessPiece[8, 8];

            InitChessboard(chessboard);

            DisplayChessboard(chessboard);

            PlayChess(chessboard);

        }

        void InitChessboard(ChessPiece[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = null;
                }
            }
            PutChessPieces(chessboard);
        }

        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            string[] cols = {"a", "b", "c", "d", "e", "f", "g", "h"};

            int Rcount = 8;

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                Console.Write(Rcount);
                Rcount--;

                for (int col = 0; col < chessboard.GetLength(1); col++)
                {

                    if ((row + col) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    DisplayChessPiece(chessboard[row, col]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            for (int i = 0; i < cols.Length; i++)
            {
                Console.Write(String.Format("{0,2}", cols[i]) + " ");
            }

        }

        void PutChessPieces(ChessPiece[,] chessboard)
        {
            ChessPieceType[] order = { ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.Queen, ChessPieceType.King, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook };

            for (int row = 0; row < chessboard.GetLength(1); row++)
            {
                ChessPiece blackBk = new ChessPiece();
                blackBk.color = ChessPieceColor.Black;
                blackBk.type = order[row];
                chessboard[0, row] = blackBk;

                ChessPiece whiteBk = new ChessPiece();
                whiteBk.color = ChessPieceColor.White;
                whiteBk.type = order[row];
                chessboard[7, row] = whiteBk;

                ChessPiece blackFr = new ChessPiece();
                blackFr.color = ChessPieceColor.Black;
                blackFr.type = ChessPieceType.Pawn;
                chessboard[1, row] = blackFr;

                ChessPiece whiteFr = new ChessPiece();
                whiteFr.color = ChessPieceColor.White;
                whiteFr.type = ChessPieceType.Pawn;
                chessboard[6, row] = whiteFr;
            }
        }

        void DisplayChessPiece(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                Console.Write("   ");
            }
            else
            {
                if (chessPiece.color == ChessPieceColor.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write($" {(char)chessPiece.type} ");
            }
        }

        Position String2Position(string pos)
        {
            Position position = new Position();

            int column = pos[0] - 'a';
            int row = 8 - int.Parse(pos[1].ToString());

            position.fieldColumn = column;
            position.fieldRow = row;

            if (row < 0 || column > 7)
            {
                throw new Exception($"Invalid position: {pos}");
            }
            return position;

        }

        void PlayChess(ChessPiece[,] chessboard)
        {
            Console.WriteLine("\n" + "Enter move (e.g. a2 a3): ");
            string move = Console.ReadLine();

            string fPos;
            string lPos;
            
            while (move != "stop")
            {
                try
                {
                    fPos = move.Split(' ')[0];
                    lPos = move.Split(' ')[1];

                    Position initial = String2Position(fPos);
                    Position final = String2Position(lPos);

                    Console.WriteLine("\n" + "move from {0} to {1}", fPos, lPos);
                    DoMove(chessboard, initial, final);

                    DisplayChessboard(chessboard);

                }
                catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exception occurred: {0}", e.Message);
                    Console.ResetColor();
                }
                Console.WriteLine("\n" + "Enter move (e.g. a2 a3): ");
                move = Console.ReadLine();
            }
        }

        void DoMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            CheckMove(chessboard, from, to);

            chessboard[to.fieldRow, to.fieldColumn] = chessboard[from.fieldRow, from.fieldColumn];
            chessboard[from.fieldRow, from.fieldColumn] = null;
        }

        void CheckMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            int hor = Math.Abs(to.fieldColumn - from.fieldColumn);
            int ver = Math.Abs(to.fieldRow - from.fieldRow);

            string chesspiece = (chessboard[from.fieldRow, from.fieldColumn].type).ToString();

            if (chessboard[from.fieldRow, from.fieldColumn] == null)
            {
                throw new Exception("No chess piece at from-position");
            }
            if (hor == 0 && ver == 0)
            {
                throw new Exception("No movement");
            }
            if ((chessboard[to.fieldRow, to.fieldColumn] != null) && (chessboard[from.fieldRow, from.fieldColumn].color == chessboard[to.fieldRow, to.fieldColumn].color))
            {
                throw new Exception("Can not take a chess piece of same color");
            }
            switch (chessboard[from.fieldRow, from.fieldColumn].type)
            {
                case ChessPieceType.Pawn:
                    if(hor != 0 && ver != 1)
                    {
                        throw new Exception("Invalid move for chess piece " + chesspiece);
                    }
                    break;
                case ChessPieceType.Rook:
                    if (hor * ver != 0)
                    {
                        throw new Exception("Invalid move for chess piece " + chesspiece);
                    }
                    break;

                case ChessPieceType.Knight:
                    if (hor * ver != 2)
                    {
                        throw new Exception("Invalid move for chess piece " + chesspiece);
                    }
                    break;

                case ChessPieceType.Bishop:
                    if (hor != ver)
                    {
                        throw new Exception("Invalid move for chess piece " + chesspiece);
                    }
                    break;

                case ChessPieceType.King:
                    if (ver != 1 && hor != 1 | ver != 1 || hor != 1)
                    {
                        throw new Exception("Invalid move for chess piece " + chesspiece);
                    }
                    break;

                case ChessPieceType.Queen:
                    if (hor * ver != 0 || hor != ver)
                    {
                        throw new Exception("Invalid move for chess piece " + chesspiece);
                    }
                    break;
            }
        }
    }
}