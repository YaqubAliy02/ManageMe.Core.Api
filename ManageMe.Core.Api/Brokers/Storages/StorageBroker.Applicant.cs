//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Applicants;
using Microsoft.EntityFrameworkCore;

namespace ManageMe.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }

        public async ValueTask<Applicant> InsertApplicantAsync(Applicant applicant) =>
            await InsertAsync(applicant);

        public IQueryable<Applicant> SelectAllApplicants() =>
            SelectAll<Applicant>();

        public async ValueTask<Applicant> SelectApplicantByIdAsync(Guid applicantId) =>
            await this.SelectAsync<Applicant>(applicantId);

        public async ValueTask<Applicant> UpdateApplicantAsync(Applicant applicant) =>
            await this.UpdateAsync(applicant);

        public async ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant) =>
            await this.DeleteAsync(applicant);
    }
}
