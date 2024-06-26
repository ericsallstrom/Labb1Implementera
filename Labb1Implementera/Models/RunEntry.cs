using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implementera.Models
{
    internal class RunEntry
    {
        public DateTime Date { get; set; }
        public double DistanceKm { get; set; }
        public double DurationMinutes { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public int AveragePulse { get; set; }
        public double CaloriesBurned { get; set; }
    }
}
