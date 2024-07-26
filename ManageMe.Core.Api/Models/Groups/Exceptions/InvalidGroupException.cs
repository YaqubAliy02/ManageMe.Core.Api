//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Xeptions;

namespace ManageMe.Core.Api.Models.Groups.Exceptions
{
    public class InvalidGroupException : Xeption
    {
        public InvalidGroupException(string message)
          : base(message) { }
    }
}
