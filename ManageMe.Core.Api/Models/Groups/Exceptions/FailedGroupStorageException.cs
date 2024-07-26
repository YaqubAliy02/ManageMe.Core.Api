//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Groups.Exceptions
{
    public class FailedGroupStorageException : Xeption
    {
        public FailedGroupStorageException(string message, Exception innerException)
          : base(message, innerException) { }
    }
}
