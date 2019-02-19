using dotnet_core_apis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_apis.Repositories
{
    public class WorkoutRepository
    {
        private static List<Workout> _Workouts;

        public WorkoutRepository()
        {
            if (_Workouts == null || _Workouts.Any() == false)
                Seed();
        }

        private void Seed()
        {
            _Workouts =
                new List<Workout>()
                {
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Running", WorkoutDate = DateTime.Now.Date.AddDays(-10), Calories=100},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Running", WorkoutDate = DateTime.Now.Date.AddDays(-9), Calories=200},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Cycling", WorkoutDate = DateTime.Now.Date.AddDays(-9), Calories=300},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Cycling", WorkoutDate = DateTime.Now.Date.AddDays(-7), Calories=120},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Running", WorkoutDate = DateTime.Now.Date.AddDays(-6), Calories=160},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Running", WorkoutDate = DateTime.Now.Date.AddDays(-3), Calories=200},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Cycling", WorkoutDate = DateTime.Now.Date.AddDays(-2), Calories=320},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Cycling", WorkoutDate = DateTime.Now.Date.AddDays(-1), Calories=240},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Running", WorkoutDate = DateTime.Now.Date.AddDays(-1), Calories=360},
                    new Workout() {Id = Guid.NewGuid(), WorkoutType = "Running", WorkoutDate = DateTime.Now.Date, Calories=310}
                };
        }

        public void Reset() => Seed();

        public IList<Workout> GetAll() => _Workouts.OrderByDescending(t => t.WorkoutDate).ToList();

        public void Add(Workout item) => _Workouts.Add(item);

        public Workout GetById(Guid id) => _Workouts.SingleOrDefault(item => item.Id == id);

        public void Update(Workout item)
        {
            var index = _Workouts.FindIndex(p => p.Id.Equals(item.Id));
            if (index != -1)
                _Workouts[index] = item;
        }

        public void Delete(Guid id) => _Workouts.RemoveAll(item => item.Id == id);
    }
}
