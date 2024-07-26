//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class ApplicantServiceException : Xeption
    {
        public ApplicantServiceException(string message, Xeption innerException) : base() { }

    }
}
