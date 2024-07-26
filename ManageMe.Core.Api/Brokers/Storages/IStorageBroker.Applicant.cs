//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Applicants;

namespace ManageMe.Core.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Applicant> InsertApplicantAsync(Applicant applicant);
        IQueryable<Applicant> SelectAllApplicants();
        ValueTask<Applicant> SelectApplicantByIdAsync(Guid applicantId);
        ValueTask<Applicant> UpdateApplicantAsync(Applicant applicant);
        ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant);
    }
}
