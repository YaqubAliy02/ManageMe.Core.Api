﻿//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Brokers.DateTimes;
using ManageMe.Core.Api.Brokers.Loggings;
using ManageMe.Core.Api.Brokers.Storages;
using ManageMe.Core.Api.Models.Applicants;

namespace ManageMe.Core.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public ApplicantService(
            IStorageBroker storageBroker, 
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant) =>
            TryCatch(async () =>
            {
                ValidateApplicantOnAdd(applicant);

                return await this.storageBroker.InsertApplicantAsync(applicant);
            });

        public IQueryable<Applicant> RetrieveAllApplicants()
        {
            throw new NotImplementedException();
        }
    }
}
