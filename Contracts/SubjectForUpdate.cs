using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Contracts
{
    public class SubjectForCreationDto
    {
         public class SubjectCreateDto
        {        
            [FromQuery(Name = "Name")]
            [Required(ErrorMessage = "Name of Subject is required")]
            [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
            public string? Title {get; set; }
            
            [FromQuery(Name = "num_of_Credits")]
            [Required(ErrorMessage = "Number of credits is required")]
            [StringLength(2, ErrorMessage = "Name can't be longer than 60 characters")]
            public int? Credits {get; set; }   
        }
    }
}
