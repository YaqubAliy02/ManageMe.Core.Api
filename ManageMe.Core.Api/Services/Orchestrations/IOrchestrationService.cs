//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

namespace ManageMe.Core.Api.Services.Orchestrations
{
    public interface IOrchestrationService
    {
        Task ProcessImportRequest(MemoryStream stream);
    }
}