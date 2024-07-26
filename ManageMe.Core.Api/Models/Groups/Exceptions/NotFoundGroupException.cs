//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Groups.Exceptions
{
    public class NotFoundGroupException : Xeption
    {
        public NotFoundGroupException(string message)
            : base(message) { }
    }
}
