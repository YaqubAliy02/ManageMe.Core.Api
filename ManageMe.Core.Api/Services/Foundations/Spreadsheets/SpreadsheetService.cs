//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Brokers.Spreadsheets;
using ManageMe.Core.Api.Models.ExternalApplicants;

namespace ManageMe.Core.Api.Services.Foundations.Spreadsheets
{
    public class SpreadsheetService : ISpreadsheetService
    {
        private readonly ISpreadsheetBroker spreadsheetBroker;

        public SpreadsheetService(ISpreadsheetBroker spreadsheetBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
        }

        public List<ExternalApplicant> GetExternalApplicants(MemoryStream stream)
        {
            List<ExternalApplicant> externalApplicants =
                            this.spreadsheetBroker.ImportApplicants(stream);

            return externalApplicants;
        }
    }
}
