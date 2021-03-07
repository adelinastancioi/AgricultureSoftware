using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Cnp { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfEmployment { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public string WorkProgram { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
