//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class FailedApplicantServiceException : Xeption
    {
        public FailedApplicantServiceException(string message, Exception innerException)
            : base() { }
    }
}
