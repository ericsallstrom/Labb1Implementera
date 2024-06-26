using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implementera.Adapters
{
    /// <summary>
    /// This class models a smartwatch that generates random pulse and burned calories data.
    /// </summary>
    internal class SmartWatch
    {
        private readonly Random _random = new();

        public int GetPulse()
        {
            return _random.Next(80, 182);
        }

        public double GetCaloriesBurned()
        {
            return _random.NextDouble() * 1000;
        }
    }
}
