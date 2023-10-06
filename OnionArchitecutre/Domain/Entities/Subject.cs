using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    
   public class Subject
    {
        public Guid? SubjectId {get; set; }
        public string? Title {get; set; }
        public int? Credits {get; set; }
        
        public Nullable<int> StudentId {get; set;}
        public virtual ICollection<Student> Students {get; set;}

        public Nullable<Guid> TeacherId {get; set;}
        public virtual Teacher Teacher {get; set;}

    }
}