using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace Contracts
{
    public class SubjectForUpdateDto
    {
          public string? Title {get; set; }
          public int? Credits {get; set; }   
    }
    }

