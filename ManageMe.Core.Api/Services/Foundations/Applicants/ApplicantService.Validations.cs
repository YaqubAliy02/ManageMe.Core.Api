//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Models.Applicants.Exceptions;

namespace ManageMe.Core.Api.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private void ValidateApplicantOnAdd(Applicant applicant)
        {
            ValidateApplicantNotNull(applicant);

            Validate(
                (Rule: IsInvalid(applicant.ApplicantId), Parameter: nameof(Applicant.ApplicantId)),
                (Rule: IsInvalid(applicant.FirstName), Parameter: nameof(Applicant.FirstName)),
                (Rule: IsInvalid(applicant.LastName), Parameter: nameof(Applicant.LastName)),
                (Rule: IsInvalid(applicant.Email), Parameter: nameof(Applicant.Email)),
                (Rule: IsInvalid(applicant.PhoneNumber), Parameter: nameof(Applicant.PhoneNumber)));
        }

        private static dynamic IsInvalid(Guid applicantId) => new
        {
            Condition = applicantId == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void ValidateApplicantNotNull(Applicant applicant)
        {
            if (applicant is null)
            {
                throw new NullApplicantException(message: "Applicant is null.");
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidClientException = new InvalidApplicantException(
                message: "Applicant is invalid.");

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidClientException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidClientException.ThrowIfContainsErrors();
        }
    }
}
