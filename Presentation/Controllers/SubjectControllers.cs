﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class AccountsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AccountsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetSubjects(Guid id, CancellationToken cancellationToken)
        {
            var accountsDto = await _serviceManager.SubjectService.GetByIdAsync(id, cancellationToken);

            return Ok(accountsDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSubjectById(Guid id, CancellationToken cancellationToken)
        {
            var accountDto = await _serviceManager.SubjectService.GetByIdAsync(id,  cancellationToken);

            return Ok(accountDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(Guid id,  SubjectForCreationDto subjectForCreationDto, CancellationToken cancellationToken)
        {
            var subject = await _serviceManager.SubjectService.CreateAsync(subjectForCreationDto, id, cancellationToken);

            return CreatedAtAction(nameof(GetSubjectById), new { subjectId = subject.SubjectId}, subject);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAccount(Guid id, CancellationToken cancellationToken)
        {
            await _serviceManager.SubjectService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}