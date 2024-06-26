using Labb1Implementera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implementera.Interfaces
{
    /// <summary>
    /// This interface defines a contract for creating RunEntry objects which represent entries for various types of 
    /// running activities. Implementing classes should provide a method CreateEntry that initializes and returns a 
    /// RunEntry object with specified parameters such as date, distance, duration, workout type, average pulse, 
    /// and calories burned. This interface supports the Factory Method design pattern, allowing different types 
    /// of run entries (regular runs, marathons, etc.) to be created by appropriate factory implementations.
    /// </summary>
    internal interface IRunEntryFactory
    {       
        RunEntry CreateEntry(DateTime date, double distance, double duration, WorkoutType workoutType, int averagePulse, double caloriesBurned);
    }
}
