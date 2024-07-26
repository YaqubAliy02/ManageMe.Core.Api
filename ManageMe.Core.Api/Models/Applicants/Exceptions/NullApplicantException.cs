//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class NullApplicantException : Xeption
    {
        public NullApplicantException(string message)
        : base(message) { }
    }
}
