//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.ExternalApplicants;

namespace ManageMe.Core.Api.Services.Foundations.Spreadsheets
{
    public interface ISpreadsheetService
    {
        List<ExternalApplicant> GetExternalApplicants(MemoryStream stream);
    }
}