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
    /// This class implements the IRunEntryFactory interface, allowing creation of
    /// RunEntry objects for regular workouts where distance is provided by the user.
    /// </summary>
    internal class RegularRunEntryFactory : IRunEntryFactory
    {
        public RunEntry CreateEntry(DateTime date, double distance, double duration, WorkoutType workoutType, int averagePulse, double caloriesBurned)
        {
            return new RunEntry
            {
                Date = date,
                DistanceKm = distance,
                DurationMinutes = duration,
                WorkoutType = workoutType,
                AveragePulse = averagePulse,
                CaloriesBurned = caloriesBurned
            };
        }
    }
}
