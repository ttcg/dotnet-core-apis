using dotnet_core_apis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_core_apis.Repositories
{
    public class TodoRepository
    {
        private static List<TodoItem> _todoItems;

        public TodoRepository()
        {
            if (_todoItems == null || _todoItems.Any() == false)
                Seed();
        }

        private void Seed()
        {
            _todoItems =
                new List<TodoItem>()
                {
                    new TodoItem() {Id = Guid.NewGuid(), TaskItem = "Learn React"},
                    new TodoItem() {Id = Guid.NewGuid(), TaskItem = "Learn React-Router"},
                    new TodoItem() {Id = Guid.NewGuid(), TaskItem = "Learn Redux"},
                    new TodoItem() {Id = Guid.NewGuid(), TaskItem = "Learn Axios"},
                    new TodoItem() {Id = Guid.NewGuid(), TaskItem = "Create a sample app", HasDone = true},
                    new TodoItem() {Id = Guid.NewGuid(), TaskItem = "Deploy to Netlify"}
                };
        }

        public void Reset() => Seed();

        public IList<TodoItem> Get() => _todoItems;

        public void Add(TodoItem item) => _todoItems.Add(item);

        public TodoItem GetById(Guid id) => _todoItems.SingleOrDefault(item => item.Id == id);

        public void Update(TodoItem item)
        {
            var index = _todoItems.FindIndex(p => p.Id.Equals(item.Id));
            if (index != -1)
                _todoItems[index] = item;
        }

        public void Delete(Guid id) => _todoItems.RemoveAll(item => item.Id == id);
    }
}