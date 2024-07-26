//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Groups.Exceptions
{
    public class NullGroupException : Xeption
    {
        public NullGroupException(string message)
            : base(message) { }
    }
}
