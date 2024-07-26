//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Groups.Exceptions
{
    public class GroupServiceException : Xeption
    {
        public GroupServiceException(string message, Xeption innerException)
            :base(message, innerException) { }
    }
}
