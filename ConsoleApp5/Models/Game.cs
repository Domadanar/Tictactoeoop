using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp5.Models
{
    class Game
    {
        public int[] playingField = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private int[][] winCombination = new int[][]
        {
        new int[] {0, 1, 2},
        new int[] {3, 4, 5},
        new int[] {6, 7, 8},
        new int[] {0, 4, 8},
        new int[] {2, 4, 6},
        new int[] {0, 3, 6},
        new int[] {1, 4, 7},
        new int[] {2, 5, 8}
        };

        internal string GetField()
        {  
            return $"/////////////\n{playingField[0]}|{playingField[1]}|{playingField[2]}\n" + $"—————\n{playingField[3]}|{playingField[4]}|{playingField[5]}\n—————\n{playingField[6]}|{playingField[7]}|{playingField[8]}\n";
        }

        internal string CheckMove()
        {
            if (GetMoves() % 2 == 0)
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }

        internal bool MakeMove(string turn, int n)
        {
            Input(turn, n);
            isGameOver(n, turn == "X");
            return GetError();
        }

        internal string CheckStatus()
        {      
            return GetStatus();
        }

 

        internal const string WIN = "win";
        internal const string DRAW = "draw";
        internal const string CONTINUE = "continue";

       
        private bool error = false;
        private string status = "";
        private int playersMoveCounter = 0;



        internal int GetMoves()
        {
            return playersMoveCounter;
        }

        internal string GetStatus()
        {
            return status;
        }

        internal bool GetError()
        {
            return error;
        }


        internal void Input(string turn, int n)
        {


            if (playingField[n] == 0)
            {
                if (turn == "X")
                {
                    playingField[n] = 1;
                    playersMoveCounter++;
                    error = false;
                    return;
                }
                else if (turn == "0" || turn == "O")
                {
                    playingField[n] = 2;
                    playersMoveCounter++;
                    error = false;
                    return;
                }
            }
            error = true;
            return;
        }

        private bool isGameOver(int n,  bool isCurrentX)
        {
            int currentPlayer = isCurrentX ? 1 : 2;

            var currentWinCombinations = winCombination.Where(c => c.Any(e => e == n));

            foreach (var winCombination in currentWinCombinations)
            {
                if (playingField[winCombination[0]] == currentPlayer && playingField[winCombination[1]] == currentPlayer && playingField[winCombination[2]] == currentPlayer)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
