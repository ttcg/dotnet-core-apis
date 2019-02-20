using System;
using System.Collections.Generic;
using dotnet_core_apis.Models;
using dotnet_core_apis.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private static WorkoutRepository _workoutRepository;

        public WorkoutsController(WorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        // GET api/workout
        [HttpGet]
        public IEnumerable<Workout> Index()
        {
            return _workoutRepository.GetAll();
        }

        // GET api/workout/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = _workoutRepository.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST api/workout
        [HttpPost]
        public IActionResult Post([FromBody]Workout Workout)
        {
            _workoutRepository.Add(Workout);

            return Ok();
        }

        // POST api/workout/reset
        [HttpPost("reset")]
        public IActionResult Reset()
        {
            _workoutRepository.Reset();

            return Ok();
        }

        // PUT api/workout/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Workout Workout)
        {
            var item = _workoutRepository.GetById(id);

            if (item == null)
                return NotFound();

            _workoutRepository.Update(Workout);

            return Ok();
        }

        // DELETE api/workout/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _workoutRepository.Delete(id);

            return Ok();
        }
    }
}
