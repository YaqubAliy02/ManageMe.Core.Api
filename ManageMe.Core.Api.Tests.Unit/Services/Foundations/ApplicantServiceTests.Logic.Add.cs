//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using FluentAssertions;
using Force.DeepCloner;
using ManageMe.Core.Api.Models.Applicants;
using Moq;

namespace ManageMe.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldAddApplicantAsync()
        {
            //given
            Applicant randomApplicant = CreateRandomApplicant();
            Applicant inputApplicant = randomApplicant;
            Applicant persistedApplicant = inputApplicant;
            Applicant expectedApplicant = persistedApplicant.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertApplicantAsync(inputApplicant))
                .ReturnsAsync(persistedApplicant);

            // when
            Applicant actualApplicant = await this.applicantService
                .AddApplicantAsync(inputApplicant);

            // then
            actualApplicant.Should().BeEquivalentTo(expectedApplicant);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertApplicantAsync(inputApplicant), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
