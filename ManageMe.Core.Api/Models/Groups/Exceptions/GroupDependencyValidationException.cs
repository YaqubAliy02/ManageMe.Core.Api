//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Groups.Exceptions
{
    public class GroupDependencyValidationException : Xeption
    {
        public GroupDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException) { }
    }
}
