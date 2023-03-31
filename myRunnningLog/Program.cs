using myRunnningLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyRunningLog
{
    class Program
    {
        static void Display(double miles, double totalMiles, TimeSpan time, TimeSpan totalTime)
        {

            // Display the User's running data for current run / Confirmation of data
            Console.WriteLine("TODAY'S DATA:");
            Console.WriteLine($"Mileage: {miles} mi");
            Console.WriteLine($"Time: {time} (hh,mm,ss)");
            Console.WriteLine($"Pace: {time.TotalMinutes / miles} min/mi");
            Console.WriteLine();

            // Display Weekly Mileage and Stats
            Console.WriteLine("WEEK'S DATA:");
            Console.WriteLine($"Total Mileage: {totalMiles} mi");
            Console.WriteLine($"Toal Time: {totalTime} (hh,mm,ss)");
            Console.WriteLine($"Avg Pace: {totalTime.TotalMinutes / totalMiles} min/mi");
            Console.WriteLine();


        }

        static double NextWeekGoal(double weeklyTotalMiles, double weeklyGoal)
        {
            if (weeklyTotalMiles >= weeklyGoal)
            {
                // Congradulate the user for meeting their goal and then raise the new weekly goal 0.05 times higher
                Console.WriteLine("Congrats! You met your weekly goal!");
                weeklyGoal *= 1.05;
                Console.WriteLine($"Your new weekly goal: {weeklyGoal} mi");
            }
            else
            {
                // Reduce the weekly goal if the user did not reach it
                Console.WriteLine("You did not quite reach your weekly goal. Keep trying!");
                weeklyGoal *= 0.90;
                Console.WriteLine($"Your new weekly goal: {weeklyGoal} mi");
            }

            return weeklyGoal;

        }

        static void Main(string[] args)
        {
            // Create Variables
            double totalMiles = 0.0;
            TimeSpan totalTime = new TimeSpan(0, 0, 0);
            List<run> runs = new List<run>();

            // Cool object that allows me to log the user input time as h, m, s
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);

            // Change this to a user input when a user creates their profile
            double weeklyGoal = 10.0; 

            // Master loop - Run through data entry prompt until user says to stop
            while (true)
            {
                Console.WriteLine("Log a Run: ");
                Console.WriteLine("Enter the number of miles for your run (or type 'q' to quit):");
                string inputMiles = Console.ReadLine();

                if (inputMiles.ToLower() == "q")
                {
                    break;
                }

                // Check if the user inputs a valid number of miles
                double miles;

                // Convert the string inputMiles to a double miles
                if (!double.TryParse(inputMiles, out miles))
                {
                    // If they do not then tell them the input is invalid and return to the beginning of the while loop
                    Console.WriteLine("Invalid input. Enter a valid number of miles");
                    continue;
                }

                // Prompt user for the duration of their run
                Console.WriteLine("Enter Time ('hh:mm:ss'): ");
                string inputTime = Console.ReadLine();
                TimeSpan time;

                // Convert the string inputTime into a time object called time
                if (!TimeSpan.TryParse(inputTime, out time))
                {
                    Console.WriteLine("Invalid input. Enter a valid time in the format hh:mm:ss");
                    continue;
                }
                Console.WriteLine();

                // Create new Run object and add to list of runs
                run newRun = new run(miles, time);
                runs.Add(newRun);

                // Update the total variables
                totalMiles += miles;
                totalTime += time;

                // Execute the Display method
                Display(miles, totalMiles, time, totalTime);

                // Checks if one week has past
                if (DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek) != startOfWeek)
                {
                    startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);

                    double weeklyTotalMiles = runs.Where(r => r.Date >= startOfWeek).Sum(r => r.Distance);
                    Console.WriteLine($"Weekly total miles: {weeklyTotalMiles:F2}");

                    // Execute the NextWeekGoal method to determine what the user's goal will be for next week and return next weeks goal.
                    NextWeekGoal(weeklyTotalMiles, weeklyGoal);
                }
            }
        }
    }
}