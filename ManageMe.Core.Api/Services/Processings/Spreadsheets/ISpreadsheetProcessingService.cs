//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.ExternalApplicants;

namespace ManageMe.Core.Api.Services.Processings.Spreadsheets
{
    public interface ISpreadsheetProcessingService
    {
        List<ExternalApplicant> ReadExternalApplicants(MemoryStream stream);
    }
}