using dotnet_core_apis.Models;
using dotnet_core_apis.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace dotnet_core_apis.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private static TodoRepository _todoRepository;

        public TodoController(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // GET api/todo
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _todoRepository.Get();
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = _todoRepository.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Post([FromBody]TodoItem todoItem)
        {
            _todoRepository.Add(todoItem);

            return Ok();
        }

        // POST api/todo/reset
        [HttpPost("reset")]
        public IActionResult Reset()
        {
            _todoRepository.Reset();

            return Ok();
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]TodoItem todoItem)
        {
            var item = _todoRepository.GetById(id);

            if (item == null)
                return NotFound();

            _todoRepository.Update(todoItem);

            return Ok();
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _todoRepository.Delete(id);

            return Ok();
        }

        // PUT api/todo/mark/5
        [HttpPut("mark/{id}")]
        public IActionResult Mark(Guid id, [FromBody]bool hasDone)
        {
            var item = _todoRepository.GetById(id);

            if (item == null)
                return NotFound();

            item.HasDone = hasDone;

            _todoRepository.Update(item);

            return Ok();
        }
    }
}