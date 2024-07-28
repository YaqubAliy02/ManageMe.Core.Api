//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.ExternalApplicants;

namespace ManageMe.Core.Api.Brokers.Spreadsheets
{
    public interface ISpreadsheetBroker
    {
        List<ExternalApplicant> ImportApplicants(MemoryStream stream);
    }
}