//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Spreadsheets.Exceptions
{
    public class ExternalApplicantsProcessingValidationException : Xeption
    {
        public ExternalApplicantsProcessingValidationException(string message,
            Xeption innerException) : base(message, innerException) { }
    }
}
