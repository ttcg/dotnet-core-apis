using System;

namespace dotnet_core_apis.Models
{
    public class Workout
    {
        public Guid Id { get; set; }
        public string WorkoutType { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int Calories { get; set; }
    }
}
