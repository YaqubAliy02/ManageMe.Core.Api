//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using FluentAssertions;
using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Models.Applicants.Exceptions;
using Moq;

namespace ManageMe.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfInputIsNullAndLogItAsync()
        {
            // given
            Applicant nullApplicant = null;
            var nullApplicantException = new NullApplicantException(
                message: "Applicant is null.");

            var expectedApplicantValidationException =
                new ApplicantValidationException(
                    message: "Applicant validation error occurred, fix the errors and try again.",
                    innerException: nullApplicantException);

            // when
            ValueTask<Applicant> addApplicantTask = 
                this.applicantService.AddApplicantAsync(nullApplicant);

            ApplicantValidationException actualApplicantValidationException =
                await Assert.ThrowsAsync<ApplicantValidationException>(addApplicantTask.AsTask);

            // then
            actualApplicantValidationException.Should()
                .BeEquivalentTo(expectedApplicantValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedApplicantValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantAsync(It.IsAny<Applicant>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
