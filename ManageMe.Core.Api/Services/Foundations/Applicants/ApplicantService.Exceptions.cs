//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using EFxceptions.Models.Exceptions;
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
            catch (InvalidApplicantException invalidApplicantException)
            {
                throw CreateAndLogValidationException(invalidApplicantException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsApplicantException = new AlreadyExistsApplicantException(
                    message: "Appliacant already exists.",
                    innerException: duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsApplicantException);
            }
            catch (SqlException sqlException)
            {
                var failedApplicantStorageException = new FailedApplicantStorageException(
                    message: "Failed applicant storage error occurred, contact support",
                    innerException: sqlException);

                throw CreateAndLogCriticalDependencyException(failedApplicantStorageException);
            }
            catch(Exception exception)
            {
                var failedApplicantServiceException = new FailedApplicantServiceException(
                    message: "Failed applicant service error occurred, contact support",
                    innerException:exception);

                throw CreateAndLogServiceException(failedApplicantServiceException);
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

        private ApplicantDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var applicantDependencyException = new ApplicantDependencyValidationException(
                message: "Applicant dependency validation error occurred. Fix the error and try again.",
                innerException: exception);

            this.loggingBroker.LogError(applicantDependencyException);

            return applicantDependencyException;
        }

        private ApplicantServiceException CreateAndLogServiceException(Xeption exception)
        {
            var applicantDependencyException = new ApplicantServiceException(
                message: "Applicant service error occurred, contact support",
                innerException: exception);

            this.loggingBroker.LogError(applicantDependencyException);

            return applicantDependencyException;
        }
    }
}
