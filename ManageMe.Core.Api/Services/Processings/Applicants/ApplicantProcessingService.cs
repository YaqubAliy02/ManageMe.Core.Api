//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Brokers.Loggings;
using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Services.Foundations.Applicants;
using ManageMe.Core.Api.Services.Processings.Groups;

namespace ManageMe.Core.Api.Services.Processings.Applicants
{
    public partial class ApplicantProcessingService : IApplicantProcessingService
    {
        private readonly IApplicantService applicantService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantProcessingService(
            IApplicantService applicantService,
            IGroupProcessingService groupProcessingService,
            ILoggingBroker loggingBroker)
        {
            this.applicantService = applicantService;
            this.groupProcessingService = groupProcessingService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant) =>
        TryCatch(async () =>
        {
            applicant.ApplicantId = Guid.NewGuid();
            applicant.CreatedDate = DateTime.Now;

            var newGroup = await this.groupProcessingService.EnsureGroupExistsByName(applicant.GroupName);

            applicant.GroupId = newGroup.GroupId;

            return await this.applicantService.AddApplicantAsync(applicant);
        });

        public ValueTask<Applicant> RetrieveApplicantByIdAsync(Guid applicantid) =>
            TryCatch(async () => await this.applicantService.RetrieveApplicantByIdAsync(applicantid));

        public IQueryable<Applicant> RetrieveAllApplicants() =>
            TryCatch(() => this.applicantService.RetrieveAllApplicants());

        public ValueTask<Applicant> ModifyApplicantAsync(Applicant applicant) =>
        TryCatch(async () =>
        {
            var newGroup = await this.groupProcessingService.EnsureGroupExistsByName(applicant.GroupName);

            applicant.GroupId = newGroup.GroupId;

            return await this.applicantService.ModifyApplicantAsync(applicant);
        });

        public ValueTask<Applicant> ModifyApplicantWithGroupAsync(Applicant applicant) =>
            TryCatch(async () => await this.applicantService.ModifyApplicantAsync(applicant));

        public ValueTask<Applicant> RemoveApplicantAsync(Guid applicantid) =>
            TryCatch(async () => await this.applicantService.RemoveApplicantAsync(applicantid));
    }
}
