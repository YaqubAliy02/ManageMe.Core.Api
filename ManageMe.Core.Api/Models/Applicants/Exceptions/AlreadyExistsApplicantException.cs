//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Applicants.Exceptions
{
    public class AlreadyExistsApplicantException : Xeption
    {
        public AlreadyExistsApplicantException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
