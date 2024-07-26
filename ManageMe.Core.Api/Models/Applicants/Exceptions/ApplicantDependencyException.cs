//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class ApplicantDependencyException : Xeption
    {
        public ApplicantDependencyException(string message, Xeption innerException)
            : base() { }

    }
}
