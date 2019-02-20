using System;

namespace dotnet_core_apis.Models
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        public string TaskItem { get; set; }
        public bool HasDone { get; set; }
        public DateTime? DoneBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
