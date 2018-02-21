using FinchAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    class Program
    {
        // **************************************
        // * Name: Nate Schlusler
        // * Course: CIT 110
        // * Date: 19 February 2018
        // * Assessment: Exam 1
        // **************************************
        static void Main(string[] args)
        {
            // connect finch
            Finch myFinch = new Finch();
            myFinch.connect();

            // variables
            string key;
            string turnRight;
            int number;
            string userResponse;
            
            //
            // level 1
            //
            Console.WriteLine("Exercising my Finch - Part 1.");
            myFinch.wait(5000);
            Console.WriteLine();
            Console.WriteLine("Turning my nose red and backing up for 3 seconds.");

            // set LED
            myFinch.setLED(255, 0, 0);

            // set motors to reverse
            myFinch.setMotors(-255, -255);
            myFinch.wait(3000);

            // stop LED and motors
            myFinch.setLED(0, 0, 0);
            myFinch.setMotors(0, 0);
            Console.WriteLine("Now I'm stopped and my nose is off.");
            myFinch.wait(3000);

            // set beep
            myFinch.noteOn(500);
            myFinch.wait(1000);
            myFinch.noteOff();
            Console.WriteLine("Excuse me... I beeped!");

            // end level 1
            Console.WriteLine();
            Console.WriteLine("That was easy. Press the enter key to continue to Part 2.");

            //
            // level 2
            //
            key = Console.ReadLine();
            if (key == "")
            {
                // left or right?
                Console.WriteLine();
                Console.WriteLine("Should I turn left or right?");
                Console.WriteLine("Enter Left or Right and press the Enter key.");
                turnRight = Console.ReadLine().ToLower();

                // right
                if (turnRight == "right")
                {
                    Console.WriteLine("Turning right with my nose green.");
                    myFinch.setMotors(255, 0);
                    myFinch.setLED(0, 255, 0);
                    myFinch.wait(2000);
                    myFinch.setMotors(0, 0);
                    myFinch.setLED(0, 0, 0);


                }

                // left
                else if (turnRight == "left")
                {
                    Console.WriteLine("Turning left with my nose blue.");
                    myFinch.setMotors(0, 255);
                    myFinch.setLED(0, 0, 255);
                    myFinch.wait(2000);
                    myFinch.setMotors(0, 0);
                    myFinch.setLED(0, 0, 0);

                }

                // invalid
                else
                {
                    Console.WriteLine("Invalid user entry!");
                }

            }

            // end level 2
            Console.WriteLine();
            Console.WriteLine("OK. On to Part 3. Press any key");
            Console.ReadKey();

            //
            // level 3
            //
            Console.WriteLine();
            Console.WriteLine("I'd like to make some noise.");
            Console.WriteLine("I'll make a tone for one second as long as you don't ask me to go too high.");
            Console.WriteLine("My top range is 800.");
            Console.WriteLine("Enter a tone value.");
            userResponse = Console.ReadLine();
            while (int.TryParse(userResponse, out number))
            {
                if (number <= 800)
                {

                    Console.WriteLine("Enter a tone value.");
                    userResponse = Console.ReadLine();
                    int.TryParse(userResponse, out number);
                    myFinch.noteOn(number);
                    myFinch.wait(1000);
                    myFinch.noteOff();

                }

                else if (number > 800)
                {
                    Console.WriteLine();
                    Console.WriteLine("OK, I'm done!");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit application.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                // make sure userResponse is a number
                while (!int.TryParse(userResponse, out number))
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine();
                    Console.WriteLine("Enter a tone value.");
                    userResponse = Console.ReadLine();
                    if (number <= 800)
                    {


                        int.TryParse(userResponse, out number);
                        myFinch.noteOn(number);
                        myFinch.wait(1000);
                        myFinch.noteOff();

                    }
                    else if (number > 800)
                    {
                        Console.WriteLine();
                        Console.WriteLine("OK, I'm done!");
                        Console.WriteLine("Press any key to exit application.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                }


            }

        }
    }
}
