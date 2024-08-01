//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Models.Groups;
using ManageMe.Core.Api.Services.Processings.Applicants;
using ManageMe.Core.Api.Services.Processings.Groups;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace ManageMe.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : RESTFulController
    {
        private readonly IGroupProcessingService groupProcessingService;
        private readonly IApplicantProcessingService applicantProcessingService;

        public GroupController(
            IGroupProcessingService groupProcessingService,
            IApplicantProcessingService applicantProcessingService)
        {
            this.groupProcessingService = groupProcessingService;
            this.applicantProcessingService = applicantProcessingService;
        }

        [HttpGet("showGroups")]
        public IActionResult ShowGroups()
        {
            IQueryable<Group> groups = this.groupProcessingService.RetrieveAllGroups();
            return Ok(groups);
        }

        [HttpGet("postGroup")]
        public IActionResult GetPostGroup()
        {
            return Ok();
        }

        [HttpPost("postGroup")]
        public async ValueTask<ActionResult<Group>> PostGroup(Group group)
        {
            group.GroupId = Guid.NewGuid();

            Group postedGroup =
                await this.groupProcessingService.AddGroupAsync(group);

            return Created(postedGroup);
        }

        [HttpGet("putGroup/{groupId}")]
        public IActionResult GetPutGroup(Guid groupId)
        {
            IQueryable<Group> groups = this.groupProcessingService.RetrieveAllGroups();
            Group group = groups.FirstOrDefault(g => g.GroupId == groupId);
            return Ok(group);
        }

        [HttpPut("putGroup")]
        public async ValueTask<ActionResult<Group>> PutGroup(Group group)
        {
            IQueryable<Applicant> putApplicants = this.applicantProcessingService.RetrieveAllApplicants();

            foreach (Applicant applicant in putApplicants.Where(a => a.GroupId == group.GroupId))
            {
                applicant.GroupName = group.GroupName;

                await this.applicantProcessingService.ModifyApplicantWithGroupAsync(applicant);
            }

            Group modifiedGroup =
                await this.groupProcessingService.ModifyGroupAsync(group);

            return Ok(modifiedGroup);
        }

        [HttpDelete("deleteGroup/{groupId}")]
        public IActionResult DeleteGroup(Guid groupId)
        {
            IQueryable<Group> groups = this.groupProcessingService.RetrieveAllGroups();
            Group group = groups.SingleOrDefault(g => g.GroupId == groupId);

            if (group is null)
            {
                return NotFound();
            }

            this.groupProcessingService.RemoveGroupAsync(group.GroupId);

            return Ok();
        }
    }
}
