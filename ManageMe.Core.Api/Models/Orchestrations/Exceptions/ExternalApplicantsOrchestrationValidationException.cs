//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Orchestrations.Exceptions
{
    public class ExternalApplicantsOrchestrationValidationException : Xeption
    {
        public ExternalApplicantsOrchestrationValidationException(string message, 
            Xeption innerException) : base(message, innerException) { }
    }
}
