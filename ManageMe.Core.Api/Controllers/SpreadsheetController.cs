//===========================
// Copyright (c) Tarteeb LLC
// Manage quickly and easily
//===========================

using ManageMe.Core.Api.Services.Orchestrations;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace ManageMe.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpreadsheetController : RESTFulController
    {
        private readonly IOrchestrationService orchestrationService;

        public SpreadsheetController(IOrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("importFile")]
        public async Task<IActionResult> ImportFile(IFormFile formFile)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream);
                stream.Position = 0;
                await this.orchestrationService.ProcessImportRequest(stream);
            }

            return RedirectToAction("showGroups", "Group");
        }
    }
}
