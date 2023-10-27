using System;
using System.Collections.Generic;

namespace Domain.Entities
{
  
    public class Teacher {
        public Guid? TeacherId {get; set; }
        public string? FirstName {get; set; }
        public string? SurName {get; set; }
        public string? Email {get; set; }
        public string? Password {get; set;}
        public int? Dni {get; set; }
        public bool? Status {get; set; }

    }
}
