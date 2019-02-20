using dotnet_core_apis.Models;
using dotnet_core_apis.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace dotnet_core_apis.Controllers
{
    [Route("api/[controller]")]
    public class TodoTaskController : Controller
    {
        private static TodoTaskRepository _todoTaskRepository;

        public TodoTaskController(TodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        // GET api/todotask
        [HttpGet]
        public IEnumerable<TodoTask> Get()
        {
            return _todoTaskRepository.Get();
        }

        // GET api/todotask/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = _todoTaskRepository.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST api/todotask
        [HttpPost]
        public IActionResult Post([FromBody]TodoTask TodoTask)
        {
            _todoTaskRepository.Add(TodoTask);

            return Ok();
        }

        // POST api/todotask/reset
        [HttpPost("reset")]
        public IActionResult Reset()
        {
            _todoTaskRepository.Reset();

            return Ok();
        }

        // PUT api/todotask/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]TodoTask TodoTask)
        {
            var item = _todoTaskRepository.GetById(id);

            if (item == null)
                return NotFound();

            _todoTaskRepository.Update(TodoTask);

            return Ok();
        }

        // DELETE api/todotask/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _todoTaskRepository.Delete(id);

            return Ok();
        }

        // PUT api/todotask/mark/5
        [HttpPut("mark/{id}")]
        public IActionResult Mark(Guid id, [FromBody]bool hasDone)
        {
            var item = _todoTaskRepository.GetById(id);

            if (item == null)
                return NotFound();

            item.HasDone = hasDone;

            _todoTaskRepository.Update(item);

            return Ok();
        }
    }
}
