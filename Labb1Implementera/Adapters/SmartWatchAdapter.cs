using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb1Implementera.Interfaces;

namespace Labb1Implementera.Adapters
{
    /// <summary>
    /// This class implements the IFitnessTracker interface, adapting the SmartWatch class to provide
    /// a standardized methods for fetching fitness data. The GetHeartRate method retrieves pulse data,
    /// while the GetCaloriesBurned method fetches the number of calories burned during a workout.
    /// </summary>
    internal class SmartWatchAdapter : IFitnessTracker
    {
        private readonly SmartWatch _smartWatch;

        public SmartWatchAdapter(SmartWatch smartWatch)
        {
            _smartWatch = smartWatch;
        }

        public double GetCaloriesBurned()
        {
            return _smartWatch.GetCaloriesBurned();
        }

        public int GetHeartRate()
        {
            return _smartWatch.GetPulse();
        }
    }
}
