using System;

namespace dotnet_core_apis.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string TaskItem { get; set; }
        public bool HasDone { get; set; }
    }
}
