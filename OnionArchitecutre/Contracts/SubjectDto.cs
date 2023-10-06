using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
     public class SubjectDto
        {
            public int? SubjectId {get; set; }
            public string? Title {get; set; }
            public int? Credits {get; set; }

        }
}
