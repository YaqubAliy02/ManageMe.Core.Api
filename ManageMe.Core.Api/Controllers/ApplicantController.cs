//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Services.Processings.Applicants;
using ManageMe.Core.Api.Services.Processings.Groups;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace ManageMe.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : RESTFulController
    {
        private readonly IApplicantProcessingService applicantProcessingService;
        private readonly IGroupProcessingService groupProcessingService;

        public ApplicantController(
            IApplicantProcessingService applicantProcessingService,
            IGroupProcessingService groupProcessingService)
        {
            this.applicantProcessingService = applicantProcessingService;
            this.groupProcessingService = groupProcessingService;
        }

        [HttpGet("showApplicants")]
        public IActionResult ShowApplicants()
        {
            IQueryable<Applicant> applicants = this.applicantProcessingService.RetrieveAllApplicants();
            return Ok(applicants);
        }

        [HttpGet("showApplicantWithGroup/{groupId}")]
        public IActionResult ShowApplicantWithGroup(Guid groupId)
        {
            IQueryable<Applicant> applicants = this.applicantProcessingService.RetrieveAllApplicants().Where(a => a.GroupId == groupId);
            return Ok(applicants);
        }

        [HttpGet("postApplicant")]
        public IActionResult GetPostApplicant()
        {
            return Ok();
        }

        [HttpPost("postApplicant")]
        public async ValueTask<ActionResult<Applicant>> PostApplicant(Applicant applicant)
        {
            Applicant postedApplicant = 
                await this.applicantProcessingService.AddApplicantAsync(applicant);

            return Created(postedApplicant);   
        }

        [HttpPut]
        public async ValueTask<ActionResult<Applicant>> GetPutApplicant(Applicant applicant)
        {
            Applicant modifyApplicant =
                await this.applicantProcessingService.ModifyApplicantAsync(applicant);

            return Ok(modifyApplicant);
        }

        [HttpGet("putApplicantInGroup/{applicantId}")]
        public IActionResult GetPutApplicantInGroup(Guid applicantId)
        {
            IQueryable<Applicant> applicants = this.applicantProcessingService.RetrieveAllApplicants();
            Applicant applicant = applicants.SingleOrDefault(a => a.ApplicantId == applicantId);
            return Ok(applicant);
        }

        [HttpPut("putApplicant")]
        public IActionResult PutApplicant(Applicant applicant)
        {
            applicantProcessingService.ModifyApplicantAsync(applicant);
            return RedirectToAction("ShowApplicants");
        }

        [HttpPut("putApplicantInGroup")]
        public IActionResult PutApplicantInGroup(Applicant applicant)
        {
            applicantProcessingService.ModifyApplicantAsync(applicant);
            return RedirectToAction("showApplicantWithGroup");
        }

        [HttpDelete("deleteApplicant/{applicantId}")]
        public IActionResult DeleteApplicant(Guid applicantId)
        {
            IQueryable<Applicant> applicants = this.applicantProcessingService.RetrieveAllApplicants();
            Applicant applicant = applicants.SingleOrDefault(a => a.ApplicantId == applicantId);
            this.applicantProcessingService.RemoveApplicantAsync(applicant.ApplicantId);
            return RedirectToAction("showApplicants");
        }

        [HttpDelete("deleteApplicantInGroup/{applicantId}")]
        public IActionResult DeleteApplicantInGroup(Guid applicantId)
        {
            IQueryable<Applicant> applicants = this.applicantProcessingService.RetrieveAllApplicants();
            Applicant applicant = applicants.SingleOrDefault(a => a.ApplicantId == applicantId);
            this.applicantProcessingService.RemoveApplicantAsync(applicant.ApplicantId);
            return RedirectToAction("showApplicantWithGroup", new { groupId = applicant.GroupId });
        }
    }
}
