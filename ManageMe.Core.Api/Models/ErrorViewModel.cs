//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

namespace ManageMe.Core.Api.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
