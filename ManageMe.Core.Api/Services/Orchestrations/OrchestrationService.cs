//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Brokers.Loggings;
using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Models.ExternalApplicants;
using ManageMe.Core.Api.Models.Groups;
using ManageMe.Core.Api.Services.Processings.Applicants;
using ManageMe.Core.Api.Services.Processings.Groups;
using ManageMe.Core.Api.Services.Processings.Spreadsheets;

namespace ManageMe.Core.Api.Services.Orchestrations
{
    public partial class OrchestrationService : IOrchestrationService
    {
        private readonly ISpreadsheetProcessingService spreadsheetProcessingService;
        private readonly IApplicantProcessingService applicantProcessingService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly ILoggingBroker loggingBroker;

        public OrchestrationService(
            ISpreadsheetProcessingService spreadsheetProcessingService,
            IApplicantProcessingService applicantProcessingService,
            IGroupProcessingService groupProcessingService,
            ILoggingBroker loggingBroker)
        {
            this.spreadsheetProcessingService = spreadsheetProcessingService;
            this.applicantProcessingService = applicantProcessingService;
            this.groupProcessingService = groupProcessingService;
            this.loggingBroker = loggingBroker;
        }

        public Task ProcessImportRequest(MemoryStream stream) =>
        TryCatch(async () =>
        {
            List<ExternalApplicant> validExternalApplicants =
                this.spreadsheetProcessingService.ReadExternalApplicants(stream);


            foreach (var externalApplicant in validExternalApplicants)
            {

                Group ensureGroup =
                    await groupProcessingService
                    .EnsureGroupExistsByName(externalApplicant.GroupName);

                Applicant applicant = MapToApplicant(externalApplicant, ensureGroup);

                await applicantProcessingService.AddApplicantAsync(applicant);
            }
        });
        private Applicant MapToApplicant(ExternalApplicant externalApplicant, Group ensureGroup)
        {
            return new Applicant
            {
                ApplicantId = Guid.NewGuid(),
                FirstName = externalApplicant.FirstName,
                LastName = externalApplicant.LastName,
                CreatedDate = externalApplicant.CreatedDate,
                Email = externalApplicant.Email,
                PhoneNumber = externalApplicant.PhoneNumber,
                GroupId = ensureGroup.GroupId,
                GroupName = ensureGroup.GroupName
            };
        }
    }
}
