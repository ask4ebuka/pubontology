using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication2
{
    struct Object
    {
        public int x;
        public int y;
        public char ch;
        public ConsoleColor color;
    }
    class Program
    {
       
            // in order to print characters on certain positions
            static void PrintOnPosition(int col, int row, char ch,
                ConsoleColor color = ConsoleColor.Gray)
            {
                Console.SetCursorPosition(col, row);
                Console.ForegroundColor = color;
                Console.Write(ch);
            }

            // in order to print strings on certain positions
            static void PrintStringOnPosition(int col, int row, string str,
                ConsoleColor color = ConsoleColor.Gray)
            {
                Console.SetCursorPosition(col, row);
                Console.ForegroundColor = color;
                Console.Write(str);
            }
            static void Main(string[] args)
        {
            // Some properties and variables to be used
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight = 18;
            Console.WindowWidth = 20;
            Console.BufferWidth = 20;

            Random randomGenerator = new Random();
            double sleeptime = 200;
            double score = 0;
            int lives = 5;

            // constructing the dwarf elements "(O)"
            Object DwarfLeft = new Object();
            DwarfLeft.x = 9;
            DwarfLeft.y = Console.WindowHeight - 1;
            DwarfLeft.ch = '(';
            DwarfLeft.color = ConsoleColor.Gray;

            Object DwarfCenter = new Object();
            DwarfCenter.x = 10;
            DwarfCenter.y = Console.WindowHeight - 1;
            DwarfCenter.ch = 'O';
            DwarfCenter.color = ConsoleColor.Gray;

            Object DwarfRight = new Object();
            DwarfRight.x = 11;
            DwarfRight.y = Console.WindowHeight - 1;
            DwarfRight.ch = ')';
            DwarfRight.color = ConsoleColor.Gray;

            List<Object> Rocks = new List<Object>();

            // Writing the instructions at the start of the game
            PrintStringOnPosition(0, 5, " The aim of the game is to avoid all the rocks. Good luck!", ConsoleColor.Yellow);
            PrintStringOnPosition(0, 9, "Pick", ConsoleColor.Yellow);
            PrintOnPosition(5, 9, (char)3, ConsoleColor.Red);
            PrintStringOnPosition(7, 9, "for lives", ConsoleColor.Yellow);
            PrintStringOnPosition(0, 10, "Pick", ConsoleColor.Yellow);
            PrintOnPosition(5, 10, '$', ConsoleColor.Green);
            PrintStringOnPosition(7, 10, "for money", ConsoleColor.Yellow);
            PrintStringOnPosition(5, 13, "Good luck!", ConsoleColor.Red);
            PrintOnPosition(17, 0, ' ', ConsoleColor.Black);
            Console.ReadLine();
            Console.Clear();

            // making the lines of play
            for (int i = 0; i <= Console.WindowWidth - 1; i++)
            {
                PrintOnPosition(i, 4, '_', ConsoleColor.White);
            }

            while (true)
            {
                // The bool values in case we get hit. They are different for the parts of the dwarf elements
                bool hit = false;
                bool hitleft = false;
                bool hitcenter = false;
                bool hitright = false;

                // the chance is for making bonuses from time to time
                int chance = randomGenerator.Next(0, 100);

                {
                    Object NewRock = new Object();
                    NewRock.x = randomGenerator.Next(0, 19);
                    NewRock.y = 5;


                    if (chance < 1)
                    {
                        // It's a heart character
                        NewRock.ch = (char)3;
                        NewRock.color = ConsoleColor.Red;
                    }
                    else if (chance < 10)
                    {
                        NewRock.ch = '$';
                        NewRock.color = ConsoleColor.Green;
                    }
                    else if (chance < 100)
                    {
                        NewRock.ch = '@';
                        NewRock.color = ConsoleColor.Cyan;
                    }
                    Rocks.Add(NewRock);
                }

                //moving the dwarf
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    // In order to avoid the moving bug (If numerous keys are pressed, the program will execute each one)
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    if (userInput.Key == ConsoleKey.LeftArrow && DwarfLeft.x > 0)
                    {
                        PrintOnPosition(DwarfLeft.x, DwarfLeft.y, ' ', DwarfLeft.color);
                        PrintOnPosition(DwarfCenter.x, DwarfCenter.y, ' ', DwarfCenter.color);
                        PrintOnPosition(DwarfRight.x, DwarfRight.y, ' ', DwarfRight.color);
                        DwarfLeft.x = DwarfLeft.x - 1;
                        DwarfCenter.x = DwarfCenter.x - 1;
                        DwarfRight.x = DwarfRight.x - 1;

                    }

                    if (userInput.Key == ConsoleKey.RightArrow && DwarfRight.x < Console.WindowWidth - 1)
                    {
                        PrintOnPosition(DwarfLeft.x, DwarfLeft.y, ' ', DwarfLeft.color);
                        PrintOnPosition(DwarfCenter.x, DwarfCenter.y, ' ', DwarfCenter.color);
                        PrintOnPosition(DwarfRight.x, DwarfRight.y, ' ', DwarfRight.color);
                        DwarfLeft.x = DwarfLeft.x + 1;
                        DwarfCenter.x = DwarfCenter.x + 1;
                        DwarfRight.x = DwarfRight.x + 1;
                    }
                }
                PrintOnPosition(DwarfLeft.x, DwarfLeft.y, DwarfLeft.ch, DwarfLeft.color);
                PrintOnPosition(DwarfCenter.x, DwarfCenter.y, DwarfCenter.ch, DwarfCenter.color);
                PrintOnPosition(DwarfRight.x, DwarfRight.y, DwarfRight.ch, DwarfRight.color);

                // The new list is made in order to add the next position of the rock which is y + 1. Thus making it fall
                List<Object> newList = new List<Object>();
                for (int i = 0; i < Rocks.Count; i++)
                {
                    Object oldRock = Rocks[i];
                    Object newObject = new Object();
                    newObject.x = oldRock.x;
                    newObject.y = oldRock.y + 1;
                    newObject.ch = oldRock.ch;
                    newObject.color = oldRock.color;

                    // check if we get hit
                    if ((newObject.x == DwarfLeft.x && newObject.y == DwarfLeft.y && newObject.ch == '@'))
                    {
                        hit = true;
                        hitleft = true;
                    }
                    else if ((newObject.x == DwarfCenter.x && newObject.y == DwarfCenter.y && newObject.ch == '@'))
                    {
                        hit = true;
                        hitcenter = true;
                    }
                    else if (newObject.x == DwarfRight.x && newObject.y == DwarfRight.y && newObject.ch == '@')
                    {
                        hit = true;
                        hitright = true;
                    }

                    // money
                    else if (newObject.x == DwarfLeft.x && newObject.y == DwarfLeft.y && newObject.ch == '$')
                    {
                        score += 500;
                    }
                    else if (newObject.x == DwarfCenter.x && newObject.y == DwarfCenter.y && newObject.ch == '$')
                    {
                        score += 500;
                    }
                    else if (newObject.x == DwarfRight.x && newObject.y == DwarfRight.y && newObject.ch == '$')
                    {
                        score += 500;
                    }

                    // lives
                    else if (newObject.x == DwarfLeft.x && newObject.y == DwarfLeft.y && newObject.ch == (char)3)
                    {
                        lives += 1;
                    }
                    else if (newObject.x == DwarfCenter.x && newObject.y == DwarfCenter.y && newObject.ch == (char)3)
                    {
                        lives += 1;
                    }
                    else if (newObject.x == DwarfRight.x && newObject.y == DwarfRight.y && newObject.ch == (char)3)
                    {
                        lives += 1;
                    }

                    // Add the new object in the newList until it reaches the end of the screen
                    if (newObject.y < Console.WindowHeight)
                    {
                        newList.Add(newObject);
                    }
                }

                // consequences for being hit
                if (hit == true)
                {
                    // checks if you have 1 live left. Else the game will continue until you reach -1 lives
                    if (lives < 2)
                    {
                        PrintStringOnPosition(0, 0, "GAME OVER!", ConsoleColor.Red);
                        // We print the X in order to see the place of casualty
                        if (hitleft == true)
                        {
                            PrintOnPosition(DwarfLeft.x, DwarfLeft.y, 'X', ConsoleColor.Red);
                        }
                        else if (hitcenter == true)
                        {
                            PrintOnPosition(DwarfCenter.x, DwarfCenter.y, 'X', ConsoleColor.Red);
                        }
                        else if (hitright == true)
                        {
                            PrintOnPosition(DwarfRight.x, DwarfRight.y, 'X', ConsoleColor.Red);
                        }
                        PrintOnPosition(17, 0, ' ', ConsoleColor.Black);
                        Console.ReadLine();
                        PrintStringOnPosition(0, 0, @"           ", ConsoleColor.Red);
                        return;
                    }
                    // Print an X on the hit position
                    if (hitleft == true)
                    {
                        PrintOnPosition(DwarfLeft.x, DwarfLeft.y, 'X', ConsoleColor.Red);
                    }
                    else if (hitcenter == true)
                    {
                        PrintOnPosition(DwarfCenter.x, DwarfCenter.y, 'X', ConsoleColor.Red);
                    }
                    else if (hitright == true)
                    {
                        PrintOnPosition(DwarfRight.x, DwarfRight.y, 'X', ConsoleColor.Red);
                    }

                    // If we still have lives, the game continues
                    PrintStringOnPosition(0, 0, "Press enter", ConsoleColor.Red);
                    // this is made in order to avoid a bug in which when you press some letter, it prints it on the console
                    // on the last position the cursor was
                    PrintOnPosition(17, 0, ' ', ConsoleColor.Black);
                    Console.ReadLine();
                    // Clear the positions of the old objects
                    PrintStringOnPosition(0, 0, @"           ", ConsoleColor.Red);
                    foreach (Object rock in Rocks)
                    {
                        PrintOnPosition(rock.x, rock.y, ' ', ConsoleColor.Black);
                    }
                    Rocks.Clear();
                    newList.Clear();
                    // Consequences
                    lives--;
                    sleeptime += 20;
                }

                // This basically makes the rocks move. The idea is - Clear the old rocks and make the new ones
                foreach (Object rock in Rocks)
                {
                    PrintOnPosition(rock.x, rock.y, ' ', ConsoleColor.Black);
                }
                // The object Rocks takes the value of the new list which contains the positions of the new rocks
                Rocks = newList;

                foreach (Object rock in Rocks)
                {
                    PrintOnPosition(rock.x, rock.y, rock.ch, rock.color);
                }

                // The score and lives
                PrintStringOnPosition(7, 2, "Score: " + (int)score, ConsoleColor.Cyan);
                PrintStringOnPosition(7, 3, "Lives: " + lives, ConsoleColor.Yellow);

                // Making the score increase and the speed of the game increase constantly
                score += 14.66;
                sleeptime -= 0.5;
                if (sleeptime < 100)
                {
                    sleeptime = 100;
                }

                if (sleeptime > 200)
                {
                    sleeptime = 200;
                }

                // Set the speed of the program
                Thread.Sleep((int)sleeptime);
            }
        }
    }


}




