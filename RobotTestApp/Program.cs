using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace RobotTestApp
{
    
    public class Directions
    {
        public static string F= string.Empty;
        public static int X;
        public static int Y;
        public static string[] compass =  {"north", "east", "west", "south"};
        private static readonly Directions directions = new Directions(0,0,null);


        public Directions(int aX, int aY, string aF)
        {
            X = aX;
            Y = aY;
            F = aF;
        }
        static string[,] grid = new string[,]
        {
            {"A1", "A2", "A3", "A4", "A5"},
            {"B1", "B2", "B3", "B4", "B5"},
            {"C1", "C2", "C3", "C4", "C5"},
            {"D1", "D2", "D3", "D4", "D5"},
            {"E1", "E2", "E3", "E4", "E5"}
        };

        static string[,] grid2 = new string[,]
        {
            {"E1", "E2", "E3", "E4", "E5"},
            {"D1", "D2", "D3", "D4", "D5"},
            {"C1", "C2", "C3", "C4", "C5"},
            {"B1", "B2", "B3", "B4", "B5"},
            {"A1", "A2", "A3", "A4", "A5"}
        };

        //Console.WriteLine(grid[0, 1]);


        public static void Report(Directions directions)
        {
            var gridLocal = grid[X, Y];
            Console.WriteLine("Location: {0} Facing: {1}", gridLocal, F);
            Console.WriteLine("Press Enter to go back to options");
            Console.ReadLine();
        }

        public static void Map(Directions directions)
        {

            string[] items = { "one", "two", "three", "one", "two", "one" };
            items = items.Select(s => s != "one" ? s : "zero").ToArray();

            //foreach (var a in grid2)
            //{
            //    a.Select()
            //}
            foreach (string thing in grid2)
            {
                if (thing == grid[X, Y])
                {
                    grid[X, Y] = "test";
                    //string[,] gridage = grid2.Select(s => s != grid[X, Y] ? s : "0").ToArray();
                    //string replace = thing;
                    //replace = "O";
                    //if (F == "north")
                    //{
                    //    grid = "^";
                    //}

                    //if (F == "south")
                    //{

                    //}

                    //if (F == "west")
                    //{
                    //    thing = "<";
                    //}

                    //if (F == "east")
                    //{
                    //    thing = ">";
                    //}

                }
            }
            int rowLength = grid2.GetLength(0);
            int colLength = grid2.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", grid2[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.ReadLine();
        }
        public static Directions Left(Directions directions)
        {

            switch (F)
            {
                case "north":
                    
                    F = "west";
                    break;

                case "east":
                    F = "north";
                   
                    break;

                case "south":
                    
                    F = "east";
                    break;
                case "west":
                    
                    F = "south";
                    break;

            }
            return (directions);

        }

        public static Directions Right(Directions directions)
        {

            switch (F)
            {
                case "north":
                    
                    F = "east";
                    break;
                case "south":
                    
                    F = "west";
                    break;

                case "east":
                    
                    F = "south";
                    break;

                case "west":
                    
                    F = "north";
                    break;
            }
            return (directions);
        }

        public static Directions Move(Directions directions)
        {
            switch(F)
            {
                case "north":
                    if (X < 4)
                    {
                        X++;
                        break;
                    }
                    else
                        Console.WriteLine("Your Robot will die if you move there!");
                    Console.WriteLine("Move to a different square");
                    Console.WriteLine("Press Enter to go back to options");
                    Console.ReadLine();
                    break;

                case "south":

                    if (X > 0)
                    {
                        X--;
                        break;
                    }
                    else
                        Console.WriteLine("Your Robot will die if you move there!");
                    Console.WriteLine("Move to a different square");
                    Console.WriteLine("Press Enter to go back to options");
                    Console.ReadLine();
                    break;

                case "east":
                    if (Y < 4)
                    {
                        Y++;
                        break;
                    }
                    else
                        Console.WriteLine("Your Robot will die if you move there!");
                    Console.WriteLine("Move to a different square");
                    Console.WriteLine("Press Enter to go back to options");
                    Console.ReadLine();
                    break;

                case "west":
                    if (Y > 0)
                    {
                        Y--;
                        break;
                    }
                    else
                        Console.WriteLine("Your Robot will die if you move there!");
                    Console.WriteLine("Move to a different square");
                    Console.WriteLine("Press Enter to go back to options");
                    Console.ReadLine();
                    break;
            }

            return (directions);
        }
        public static Directions Place(int X,int Y, string F)
        {
            
            //
            //var input = grid[X, Y];
            //Console.WriteLine("Completed line: {0}", input);

            return (directions);  
        }

    class Program
    { 
    static void Main(string[] args)

    {

        bool breakFlag = false;

        while (!breakFlag)
        {
            //Console.WriteLine(grid);
            Console.Clear();
            Directions directions = new Directions(X, Y, F);
            Console.WriteLine("Pick X (between 0-4):");
            
            
            bool correctEntryX = Int32.TryParse(Console.ReadLine(), out X);
            if (!correctEntryX)
            {
                Console.WriteLine("Try to put in a number moron!!");
                Console.WriteLine("Press enter to go back to coordinate entry");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine("Pick Y (between 0-4):");

            bool correctEntryY = Int32.TryParse(Console.ReadLine(), out Y);
           

            if (!correctEntryY)
            {
                Console.WriteLine("Try to put in a number moron!!");
                Console.WriteLine("Press enter to go back to coordinate entry");
                Console.ReadLine();
                continue;
            }
            
            Console.WriteLine("Pick Facing (North, East, South or West):");
            F = (Console.ReadLine().ToLower());

            if ((X < 0 || X > 4 || Y < 0 || Y > 4))
            {
                Console.WriteLine("X and Y out of range");

                Console.ReadLine();
            }//else if (F != null && ((F.ToLower() != "north" )|| (F.ToLower() != "south") || (F.ToLower() != "east" )||( F.ToLower() != "west")))

            else if (compass.Contains(F)) 
            {
                Place(X, Y, F);
                breakFlag = true;
                break;
                
            }

            else
            {
                //Console.WriteLine(F);
                Console.WriteLine("Enter North, South, East or West");
                Console.WriteLine("Press Enter to go back to Place Input");
                Console.ReadLine();
                //throw new IndexOutOfRangeException();
            }

        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Pick Options");
            Console.WriteLine("1) Move");
            Console.WriteLine("2) Left");
            Console.WriteLine("3) Right");
            Console.WriteLine("4) Report");

            var command = (Console.ReadLine());
        
        
            switch (command)
            {
                case "1":
                    Move(directions);
                    break;

                case "2":
                    Left(directions);
                    break;
                case "3":
                    Right(directions);
                    break;
                case "4":
                    Report(directions);
                    break;
                case "5":
                   Map(directions);
                    break;

                default:
                    Console.WriteLine("Enter a correct option");
                    Console.WriteLine("Press Enter to go back to options");
                    Console.ReadLine();
                    break;
            }
        }

        


    }
    }
    }

}
