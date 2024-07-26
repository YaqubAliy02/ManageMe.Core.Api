//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Models.Applicants.Exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace ManageMe.Core.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private delegate ValueTask<Applicant> ReturningApplicantFunction();

        private async ValueTask<Applicant> TryCatch(
            ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (NullApplicantException nullApplicantException)
            {
                throw CreateAndLogValidationException(nullApplicantException);
            }
            catch(InvalidApplicantException invalidApplicantException)
            {
                throw CreateAndLogValidationException(invalidApplicantException);
            }
            catch(SqlException  sqlException)
            {
                var failedApplicantStorageException = new FailedApplicantStorageException(
                    message: "Failed applicant storage error occurred, contact support",
                    innerException: sqlException);

                throw CreateAndLogCriticalDependencyException(failedApplicantStorageException);
            }
        }


        private ApplicantValidationException CreateAndLogValidationException(
            Xeption exception)
        {
            var applicantValidationException = new ApplicantValidationException(
                message: "Applicant validation error occurred, fix the errors and try again.",
                innerException: exception);

            this.loggingBroker.LogError(applicantValidationException);

            return applicantValidationException;
        }
        private ApplicantDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var applicantDependencyException = new ApplicantDependencyException(
                message: "Applicant dependency error occurred, contact support",
                innerException: exception);

            this.loggingBroker.LogCritical(applicantDependencyException);

            return applicantDependencyException;
        }
    }
}
