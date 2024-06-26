using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implementera.Interfaces
{
    /// <summary>
    /// This interface defines a contract for fitness tracking devices. Implementing classes should 
    /// provide methods to retrieve fitness metrics, such as heart rate and calories burned, from 
    /// the fitness tracker. This interface supports the Adapter design pattern, allowing different 
    /// fitness tracking devices to be used interchangeably within the application.
    /// </summary>
    internal interface IFitnessTracker
    {
        int GetHeartRate();
        double GetCaloriesBurned();
    }
}
