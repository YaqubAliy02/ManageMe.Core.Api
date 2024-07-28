//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class NotFoundApplicantException : Xeption
    {
        public NotFoundApplicantException(string message)
         : base() { }
    }
}
