//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using EFxceptions.Models.Exceptions;
using ManageMe.Core.Api.Models.Applicants.Exceptions;
using ManageMe.Core.Api.Models.Applicants;
using Xeptions;
using System.Data.SqlClient;

namespace ManageMe.Core.Api.Services.Processings.Applicants
{
    public partial class ApplicantProcessingService
    {
        private delegate ValueTask<Applicant> ReturningApplicantFunction();
        private delegate IQueryable<Applicant> ReturningApplicantsFunction();

        private async ValueTask<Applicant> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (NullApplicantException nullApplicantExeption)
            {
                throw CreateAndLogValidationException(nullApplicantExeption);
            }
            catch (InvalidApplicantException invalidApplicantException)
            {
                throw CreateAndLogValidationException(invalidApplicantException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsApplicantException =
                    new AlreadyExistsApplicantException(
                        message: "Appliacant already exists.",
                       innerException: duplicateKeyException);

                throw CreateAndALogDependencyValidationException(alreadyExistsApplicantException);
            }
            catch (SqlException sqlException)
            {
                var failedApplicantStorageException = new FailedApplicantStorageException(
                   message: "Failed applicant storage error occurred, contact support",
                   innerException: sqlException);

                throw CreateAndLogCriticalDependencyException(failedApplicantStorageException);
            }
            catch (Exception exception)
            {
                var failedApplicantServiceException = new FailedApplicantServiceException(
                    message: "Failed applicant service error occurred, contact support",
                   innerException: exception);

                throw CreateAndLogServiceException(failedApplicantServiceException);
            }
        }

        private IQueryable<Applicant> TryCatch(ReturningApplicantsFunction returningApplicantsFunction)
        {
            try
            {
                return returningApplicantsFunction();
            }
            catch (SqlException SqlException)
            {
                var failedApplicantStorageException =
                    new FailedApplicantStorageException(
                        message: "Failed applicant storage error occurred, contact support",
                       innerException: SqlException);

                throw CreateAndLogCriticalDependencyException(failedApplicantStorageException);
            }
            catch (Exception exception)
            {
                var failedApplicantServiceException =
                    new FailedApplicantServiceException(
                       message: "Failed applicant service error occurred, contact support",
                       innerException: exception);

                throw CreateAndLogServiceException(failedApplicantServiceException);
            }
        }

        private ApplicantDependencyValidationException CreateAndALogDependencyValidationException(Xeption exception)
        {
            var applicantDependencyValidationException =
                new ApplicantDependencyValidationException(
                    message: "Applicant dependency validation error occurred. Fix the error and try again.",
                    innerException: exception);
            this.loggingBroker.LogError(applicantDependencyValidationException);

            return applicantDependencyValidationException;
        }

        private ApplicantDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var applicantDependencyException = new ApplicantDependencyException(
                message: "Applicant dependency error occurred, contact support",
                innerException: exception);
            this.loggingBroker.LogCritical(applicantDependencyException);

            return applicantDependencyException;
        }

        private ApplicantServiceException CreateAndLogServiceException(Xeption exception)
        {
            var applicantServiceException = new ApplicantServiceException(
               message: "Applicant service error occurred, contact support",
               innerException: exception);
            this.loggingBroker.LogError(applicantServiceException);

            return applicantServiceException;
        }

        private ApplicantProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var applicantProcessingValidationException =
                new ApplicantProcessingValidationException(
                    message: "Applicant validation error occurred, fix the errors and try again.",
                   innerException: exception);

            this.loggingBroker.LogError(applicantProcessingValidationException);

            return applicantProcessingValidationException;
        }
    }
}
