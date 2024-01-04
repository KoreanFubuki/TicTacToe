using System;
using System.Dynamic;

namespace TicTacToe
{
    class Program
    {
        //playfield
        static char[,] playfield =
        {
            { '1','2','3' },
            { '4','5','6' },
            { '7','8','9' }
        };
        static int turn = 0;
        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool check = true;
            
            //goal program must not stop until I want it to stop
            do
            {
                if (player == 2)
                {
                    player = 1;
                    enterXorO(player ,input);
                } 
                else if (player == 1)
                {
                    player = 2;
                    enterXorO(player , input);
                }

                setfield();
                #region
                //Check for winner
                char[] playerChars = { 'X', 'O' };

                foreach(char PlayerChar in playerChars)
                {
                    if (((playfield[0, 0] == PlayerChar) && (playfield[0, 1] == PlayerChar) && (playfield[0, 2] == PlayerChar))
                        || 
                        ((playfield[1, 0] == PlayerChar) && (playfield[1, 1] == PlayerChar) && (playfield[1, 2] == PlayerChar))
                        ||
                        ((playfield[2, 0] == PlayerChar) && (playfield[2, 1] == PlayerChar) && (playfield[2, 2] == PlayerChar))
                        ||
                        ((playfield[0, 0] == PlayerChar) && (playfield[1, 1] == PlayerChar) && (playfield[2, 2] == PlayerChar))
                        ||
                        ((playfield[0, 2] == PlayerChar) && (playfield[1, 1] == PlayerChar) && (playfield[2, 0] == PlayerChar))
                        ||
                        ((playfield[0, 0] == PlayerChar) && (playfield[1, 0] == PlayerChar) && (playfield[2, 0] == PlayerChar))
                        ||
                        ((playfield[0, 1] == PlayerChar) && (playfield[1, 1] == PlayerChar) && (playfield[2, 1] == PlayerChar))
                        ||
                        ((playfield[0, 2] == PlayerChar) && (playfield[1, 2] == PlayerChar) && (playfield[2, 2] == PlayerChar)))
                        
                    {
                        if (PlayerChar == 'X')
                        {
                            Console.WriteLine("Player 2 Wins!");
                        }
                        else
                        {
                            Console.WriteLine("Player 1 Wins!");
                        }
                        //need to reset the field
                        Console.WriteLine("Press any key to reset the game");
                        Console.ReadKey();
                        resetfield();

                        break;
                        
                        
                    }
                    else if (turn == 10)
                    {
                        Console.WriteLine("This is a draw");
                        Console.WriteLine("Press any key to reset the game");
                        Console.ReadKey();
                        resetfield();
                        break;
                    }

                }
                #endregion

                #region
                //testing field
                do
                {
                    Console.Write("\nPlayer {0}: Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please Enter a number");
                    }
                    if ((input == 1) && (playfield[0, 0] == '1'))
                        check = true;
                    else if ((input == 2) && (playfield[0, 1] == '2'))
                        check = true;
                    else if ((input == 3) && (playfield[0, 2] == '3'))
                        check = true;
                    else if ((input == 4) && (playfield[1, 0] == '4'))
                        check = true;
                    else if ((input == 5) && (playfield[1, 1] == '5'))
                        check = true;
                    else if ((input == 6) && (playfield[1, 2] == '6'))
                        check = true;
                    else if ((input == 7) && (playfield[2, 0] == '7'))
                        check = true;
                    else if ((input == 8) && (playfield[2, 1] == '8'))
                        check = true;
                    else if ((input == 9) && (playfield[2, 2] == '9'))
                        check = true;
                    else
                    {
                        Console.WriteLine("\n incorrect field use a different field");
                        check = false;
                    }

                }
                while (!check);
                #endregion
            }
            while (true);
        }

        public static void resetfield()
        {
            char[,] playfield2 =
            {
            { '1','2','3' },
            { '4','5','6' },
            { '7','8','9' }
            };
            playfield = playfield2;
            setfield();
            turn = 0;
        }
        public static void setfield()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playfield[0,0], playfield[0,1], playfield[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playfield[1, 0], playfield[1, 1], playfield[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playfield[2, 0], playfield[2, 1], playfield[2, 2]);
            Console.WriteLine("     |     |     ");
            turn++;
        }
        public static void enterXorO(int player, int input)
        {
            char playersign = ' ';
            if (player == 1)
                playersign = 'X';
            else if (player == 2)
                playersign = 'O';
            switch (input)
            {
                case 1: playfield[0, 0] = playersign; break;
                case 2: playfield[0, 1] = playersign; break;
                case 3: playfield[0, 2] = playersign; break;
                case 4: playfield[1, 0] = playersign; break;
                case 5: playfield[1, 1] = playersign; break;
                case 6: playfield[1, 2] = playersign; break;
                case 7: playfield[2, 0] = playersign; break;
                case 8: playfield[2, 1] = playersign; break;
                case 9: playfield[2, 2] = playersign; break;
            }
        }
        
    }
}