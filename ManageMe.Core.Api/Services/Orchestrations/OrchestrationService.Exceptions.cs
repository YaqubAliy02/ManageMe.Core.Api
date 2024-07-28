//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Orchestrations.Exceptions;
using ManageMe.Core.Api.Models.Spreadsheets.Exceptions;
using Xeptions;

namespace ManageMe.Core.Api.Services.Orchestrations
{
    public partial class OrchestrationService
    {
        private delegate Task ReturningTaskFunction();

        private async Task TryCatch(ReturningTaskFunction returningTaskFunction)
        {
            try
            {
                await returningTaskFunction();
            }
            catch (ExternalApplicantsProcessingValidationException 
            externalApplicantsProcessingValidationException)
            {
                throw CreateAndLogValidationException(
                    externalApplicantsProcessingValidationException.InnerException as Xeption);
            }
        }

        private ExternalApplicantsOrchestrationValidationException CreateAndLogValidationException(
            Xeption exception)
        {
            var externalApplicantsOrchestrationValidationException =
                new ExternalApplicantsOrchestrationValidationException(
                   message: "External applicant validation error occurred, fix the error and try again",
                   innerException: exception);

            this.loggingBroker.LogError(externalApplicantsOrchestrationValidationException);

            return externalApplicantsOrchestrationValidationException;
        }
    }
}
