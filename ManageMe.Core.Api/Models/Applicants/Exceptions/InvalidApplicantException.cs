//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class InvalidApplicantException : Xeption
    {
        public InvalidApplicantException(string message)
            : base(message) { }
    }
}
