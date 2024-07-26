//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Applicants;

namespace ManageMe.Core.Api.Services.Foundations.Applicants
{
    public interface IApplicantService
    {
        ValueTask<Applicant> AddApplicantAsync(Applicant applicant);
        IQueryable<Applicant> RetrieveAllApplicants();
    }
}