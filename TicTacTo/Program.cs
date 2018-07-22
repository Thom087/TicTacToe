using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit=false;
            while (!exit)
            {
                bool gameOver = false;
                int iPlayer = 1;
                string[] arrTicTacTo = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                DrawGame(arrTicTacTo);
                while (!gameOver)
                {
                    Console.WriteLine("Player {0} choose a field: ", iPlayer);
                    string stInput = Console.ReadLine();
                    bool convert = int.TryParse(stInput, out int indexPlayer);
                    if (convert && indexPlayer < 10 && indexPlayer > 0)
                    {
                        if (arrTicTacTo[indexPlayer - 1]=="X" || arrTicTacTo[indexPlayer - 1] == "O")
                        {
                            Console.WriteLine("Field {0} is already busy.", indexPlayer);
                        }
                        else
                        {
                            string stPlayer = (iPlayer == 1) ? "X" : "O"; //Player 1 is X
                            arrTicTacTo[indexPlayer - 1] = stPlayer;
                            DrawGame(arrTicTacTo);
                            gameOver = CheckWin(arrTicTacTo, stPlayer);
                            iPlayer = iPlayer == 1 ? 2 : 1;
                        } 
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number from 1 to 9");
                    }
                }
                Console.WriteLine("Another game? \"yes\"");
                string stExit = Console.ReadLine();
                exit = (stExit == "yes") ? false : true;
            }
        }

        static bool CheckWin(string[] arr, string player)
        {
            if (
                (arr[0]==player && arr[1] == player&& arr[2] == player)|| //horizontal 1.row
                (arr[3] == player && arr[4] == player && arr[5] == player) || //horizontal 2. row
                (arr[6] == player && arr[7] == player && arr[8] == player) || //horizontal 3. row
                (arr[0] == player && arr[3] == player && arr[6] == player) || //vertical 1. column
                (arr[1] == player && arr[4] == player && arr[7] == player) || //vertical 1. column
                (arr[2] == player && arr[5] == player && arr[8] == player) || //vertical 1. column
                (arr[0] == player && arr[4] == player && arr[8] == player) || //diagonal left to right
                (arr[2] == player && arr[4] == player && arr[6] == player)  //diagonal right to left
                )
            {
                Console.WriteLine("Player {0} has won the game!!!", player=="X"?1:2);
                return true;
            }
            else
            {
                int iField=0;
                foreach (var item in arr)
                {
                    iField = (item == "X" || item == "O") ? iField + 1 : iField;
                }
                if (iField == arr.Length)
                {
                    Console.WriteLine("Game over");
                    return true;
                }
                return false;
            }
        }

        static void DrawGame(string[] arr)
        {
            Console.Clear();
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", arr[0], arr[1], arr[2]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", arr[3], arr[4], arr[5]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", arr[6], arr[7], arr[8]);
            Console.WriteLine("       |       |       ");
        }
    }
}



