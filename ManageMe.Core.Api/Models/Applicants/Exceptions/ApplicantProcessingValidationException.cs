//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class ApplicantProcessingValidationException : Xeption
    {
        public ApplicantProcessingValidationException(string message, Xeption innerException) 
            : base(message, innerException) { }
    }
}
