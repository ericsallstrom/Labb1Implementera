using Labb1Implementera.Interfaces;
using Labb1Implementera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implementera.Factories
{
    /// <summary>
    /// This class implements the IRunEntryFactory interface, providing a method to
    /// create RunEntry objects specifically for marathon runs with a fixed distance.
    /// </summary>
    internal class MarathonRunEntryFactory : IRunEntryFactory
    {
        public RunEntry CreateEntry(DateTime date, double distance, double duration, WorkoutType workoutType, int averagePulse, double caloriesBurned)
        {
            return new RunEntry
            {
                Date = date,
                DistanceKm = 42.195,
                DurationMinutes = duration,
                AveragePulse = averagePulse,
                WorkoutType = workoutType,
                CaloriesBurned = caloriesBurned
            };
        }
    }
}
