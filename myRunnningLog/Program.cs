using System;


namespace MyRunningLog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Variables
            double totalMiles = 0.0;
            TimeSpan totalTime = new TimeSpan(0, 0, 0); // Cool object that allows me to log the user input time as h, m, s
            double weeklyGoal = 10.0;   // Change this to a user input when a user creates their profile
            
            // Master loop - Run through data entry prompt until user says to stop
            while (true)
            {
                Console.WriteLine("Log Run (type 'q' to quit): ");
                Console.WriteLine("Log Mileage (ex: 2.56): ");
                string inputMiles = Console.ReadLine();

                // If the user inputs the quit command ('q') then break the master while loop
                if(inputMiles.ToLower() == "q")
                {
                    break;
                }

                // Check if the user inputs a valid number of miles
                double miles;
                // Convert the string inputMiles to a double miles
                if(!double.TryParse(inputMiles, out miles))
                {
                    // If they do not then tell them the input is invalid and return to the beginning of the while loop
                    Console.WriteLine("Invalid input. Enter a valid number of miles");
                    continue;
                }

                // Prompt user for the duration of their run
                Console.WriteLine("Log time ('hh:mm:ss'): ");
                string inputTime = Console.ReadLine();
                TimeSpan time;
                // Convert the string inputTime into a time object called time
                if(!TimeSpan.TryParse(inputTime, out time))
                {
                    Console.WriteLine("Invalid input. Enter a valid time in the format hh:mm:ss");
                    continue;
                }
                Console.WriteLine();

                // Update the total variables
                totalMiles += miles;
                totalTime += time;

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
        }
    }
}