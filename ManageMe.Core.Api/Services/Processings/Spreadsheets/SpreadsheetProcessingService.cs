//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.ExternalApplicants;
using ManageMe.Core.Api.Services.Foundations.Spreadsheets;

namespace ManageMe.Core.Api.Services.Processings.Spreadsheets
{
    public class SpreadsheetProcessingService : ISpreadsheetProcessingService
    {
        private readonly ISpreadsheetService spreadsheetService;

        public SpreadsheetProcessingService(ISpreadsheetService spreadsheetService)
        {
            this.spreadsheetService = spreadsheetService;
        }

        public List<ExternalApplicant> ReadExternalApplicants(MemoryStream stream)
        {
            List<ExternalApplicant> validExternalApplicants =
                spreadsheetService.GetExternalApplicants(stream);

            return validExternalApplicants;
        }
    }
}
