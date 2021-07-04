using System;

#nullable disable

namespace AgriSoft.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime? TaskDate { get; set; }
        public TimeSpan? Estimated { get; set; }
        public int EmployeeId { get; set; }
        public string Location { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
