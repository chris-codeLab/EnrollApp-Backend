using System;
using System.Collections.Generic;

namespace Domain.Entities
{
     public class Student
    {
        public Guid? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? SurName { get; set; }
        public string? Email {get; set; }
        public string? Password {get; set;}
        public DateTime EnrollmentDate { get; set; }
    }
}
