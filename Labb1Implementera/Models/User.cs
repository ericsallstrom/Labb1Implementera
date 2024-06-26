using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb1Implementera.Adapters;
using Labb1Implementera.Factories;
using Labb1Implementera.Interfaces;
using Labb1Implementera.Navigations;

namespace Labb1Implementera.Models
{
    /// <summary>
    /// Represents a user of the application, managin run entries with different workout types for running.
    /// This class demonstrates the Factory Method pattern by using two different factories:
    /// - RegularRunEntryFactory
    /// - MarathonRunEntryFactory
    /// The AddRunEntry method uses the selected factory based on the workout type chosen by the user.
    /// 
    /// The class also applies the Adapter pattern:
    /// The SmartWatchAdapter adapts the SmartWatch class to the IFitnessTracker interface, allowing the User
    /// class to obtain heart rate and burned calories data from a SmartWatch instance in a compatible format.
    /// </summary>
    internal class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<RunEntry> RunEntries { get; set; } = [];

        private readonly IRunEntryFactory _regularRunFactory;
        private readonly IRunEntryFactory _marathonRunFactory;

        public User()
        {
            _regularRunFactory = new RegularRunEntryFactory();
            _marathonRunFactory = new MarathonRunEntryFactory();
        }

        public void AddRunEntry()
        {
            string prompt = "Enter run entry details.\nSelect workout type:";
            WorkoutType workoutType = SelectWorkoutType(prompt);
            
            Console.CursorVisible = true;            

            DateTime date;
            while (true)
            {
                Console.Write("\nDate (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    break;
                }
                Console.Write("Invalid date format. Please enter date in yyyy-MM-dd format.\n");
            }

            double distance = 0;
            if (workoutType != WorkoutType.Marathon)
            {                
                while (true)
                {
                    Console.Write("Distance (km): ");
                    if (double.TryParse(Console.ReadLine(), out distance) || distance < 0)
                    {
                        break;
                    }
                    Console.Write("Invalid distance format. Please enter a valid number.\n");
                }
            }           

            double duration;
            while (true)
            {
                Console.Write("Total running time (minutes): ");
                if (double.TryParse(Console.ReadLine(), out duration) || duration < 0)
                {
                    break;
                }
                Console.Write("Invalid time format. Please enter a valid number.\n");
            }      

            SmartWatch smartWatch = new();
            IFitnessTracker fitnessTracker = new SmartWatchAdapter(smartWatch);
            int averagePulse = fitnessTracker.GetHeartRate();
            double caloriesBurned = fitnessTracker.GetCaloriesBurned();
            
            IRunEntryFactory factory = workoutType == WorkoutType.Marathon ? _marathonRunFactory : _regularRunFactory;
            RunEntry entry = factory.CreateEntry(date, distance, duration, workoutType, averagePulse, caloriesBurned);
            RunEntries.Add(entry);

            Console.Write("\nRun entry added successfully!\nPress ENTER to go back.");
            Console.ReadKey();
        }

        public void PrintUserRunEntries()
        {
            Console.Clear();
            Console.WriteLine($"RUN ENTRIES:");

            if (RunEntries.Count != 0)
            {
                // Sorting run entries after date (oldest last)
                RunEntries.Sort((entry1, entry2) => entry2.Date.CompareTo(entry1.Date));

                foreach (var entry in RunEntries)
                {
                    Console.WriteLine($"-\n" +
                        $"Date: {entry.Date.ToString("dd MMMM yyyy")}\n" +
                        $"Distance: {entry.DistanceKm} km\n" +
                        $"Time: {entry.DurationMinutes} minutes\n" +
                        $"Workout Type: {entry.WorkoutType}\n" +
                        $"Pulse (average): {entry.AveragePulse} bpm\n" +
                        $"Calories burned: {entry.CaloriesBurned:N2}");
                }
            }
            else
            {
                Console.WriteLine("\nYou currently have no run entries registered.");
            }
            Console.WriteLine("\nPress ENTER to go back.");
            Console.ReadKey();
        }

        public void PrintRunnersData()
        {
            Console.Clear();
            Console.WriteLine($"RUNNER'S DATA:" +
                            $"\n-" +
                            $"\nTotal distance runned: {GetTotalDistance()} km" +
                            $"\nAverage distance each run: {GetTotalDistance()} km" +
                            $"\nTotal time running: {GetTotalDuration()} minutes");

            Console.WriteLine("\nPress ENTER to go back.");
            Console.ReadKey();
        }     

        private double GetTotalDuration()
        {
            return RunEntries.Sum(e => e.DurationMinutes);
        }

        private double GetAverageDistance()
        {
            double totalDistance = GetTotalDistance();
            double averageDistance = totalDistance / RunEntries.Count;
            return averageDistance;
        }

        private double GetTotalDistance()
        {
            return RunEntries.Sum(e => e.DistanceKm);
        }

        private WorkoutType SelectWorkoutType(string prompt)
        {
            Menu menu = new();
            menu.DisplayWorkoutMenu(prompt);

            return (WorkoutType)menu.SelectedOption;
        }
    }
}
