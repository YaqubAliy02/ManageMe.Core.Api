//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class ApplicantValidationException : Xeption
    {
        public ApplicantValidationException(string message, Xeption innerException)
            : base(message, innerException) { }
    }
}
