using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace ProblematicProblem
{
    public class Program
    {
        //Universal method Declarations
        public static bool StringToBoolValidater(string input) 
        {
            input = input.ToLower();

            if (input.Contains("yes") || input.Contains("sure") || input.Contains("keep") || input.Contains("yep") || input.Contains("yeah")) { return true; }
            else { return false; } 
        }

        public static string StringCleaner(string input)
        {
           input = input.ToLower();
           input = input.Trim();
   
           return input;
        }

        //Universal variable delcarations.
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static string userName;
        static int userAge;
        static string stringValidater;
        static int intValidater = 0;
        static bool boolValidater;

        static void Main(string[] args)
         {
            //Greeter
            Console.WriteLine("Welcome to the activities database!");

            //name getter
            Console.WriteLine("Before we continue, we are going to need some information first! What is your first name?");
            userName = StringCleaner(Console.ReadLine());
            Console.WriteLine($"Hello, {userName}!");
            Console.WriteLine();

            //age getter
            Console.WriteLine($"How old are you?");
            do{
                stringValidater = Console.ReadLine();
                boolValidater = int.TryParse(stringValidater, out intValidater);

                if (boolValidater) { userAge = int.Parse(stringValidater); }
                else { Console.WriteLine($"I'm sorry but I cant work with {stringValidater}. Please input a valid age."); }

                if(userAge > 100 || userAge < 10) 
                { Console.WriteLine($"I'm sorry but I can't work with {userAge}. Please input a valid age for this database."); boolValidater = false; }

                Console.WriteLine();

            }while (boolValidater == false);

            //see list of activities prompt
            Console.Write($"{userName} would you like to see the current list of activities? Sure/No thanks: ");
            boolValidater = StringToBoolValidater(Console.ReadLine());

            //activites loops
            if (boolValidater)
            {
                //activity printer
                Console.WriteLine($"Okay! Here is the list of activities:");
                foreach (string activity in activities)
                {
                    Console.WriteLine($" - {activity}");
                    Thread.Sleep(250);
                }
                Console.WriteLine();

                //activity adder prompt
                Console.Write("Would you like to add any activities? yes/no: ");
                boolValidater = StringToBoolValidater(Console.ReadLine());
                Console.WriteLine();

                //activity adder
                while (boolValidater)
                {
                    Console.WriteLine("What would you like to add?");
                    string userAddition = Console.ReadLine();
                    userAddition = StringCleaner(userAddition);

                    activities.Add(userAddition);
                    Console.WriteLine($"Okay! Here is the new list of activities:");
                    foreach (string activity in activities)
                    {
                        Console.WriteLine($" - {activity}");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Would you like to add more? yes/no: ");
                    boolValidater = StringToBoolValidater(Console.ReadLine());
                    Console.WriteLine();
                }
            }
            //random activity generator prompt
            Console.WriteLine($"{userName} would you like to access the random activity generater? Sure/No thanks: ");
            Console.WriteLine("(Warning saying no exits the application.)");
            boolValidater = StringToBoolValidater(Console.ReadLine());

            if (boolValidater)
            {
                //fluff
                Console.Write("Connecting to the database.");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity.");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                //random variable creation 
                Random rng = new Random();
                int randomNumber;
                string randomActivity;

                ////random variable assignment
                randomNumber = rng.Next(activities.Count);
                randomActivity = activities[randomNumber];

                while (userAge > 21 && randomActivity == "Wine Tasting")
                {
                     randomNumber = rng.Next(activities.Count);
                     randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                boolValidater = StringToBoolValidater(Console.ReadLine());

                while (boolValidater == false)
                {
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];

                    Console.Write($"Okay {userName}, your new random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    boolValidater = StringToBoolValidater(Console.ReadLine());
                }
                Console.WriteLine($"Have a nice {randomActivity} day.");
            }
         }

    }

}
    
