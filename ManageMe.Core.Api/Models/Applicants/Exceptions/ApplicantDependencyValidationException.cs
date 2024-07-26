//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class ApplicantDependencyValidationException : Xeption
    {
        public ApplicantDependencyValidationException(string message, Xeption innerException) 
            :base(message, innerException) { }
    }
}
