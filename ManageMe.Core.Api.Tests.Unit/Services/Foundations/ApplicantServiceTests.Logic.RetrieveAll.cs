//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using FluentAssertions;
using ManageMe.Core.Api.Models.Applicants;
using Moq;

namespace ManageMe.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllApplicants()
        {
            //given
            IQueryable<Applicant> randomApplicants = GetRandomApplicants();
            IQueryable<Applicant> persistedApplicant = randomApplicants;
            IQueryable<Applicant> expectedApplicants = persistedApplicant;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllApplicants()).Returns(expectedApplicants);

            //when
            IQueryable<Applicant> actualApplicants =
                this.applicantService.RetrieveAllApplicants();

            //then
            actualApplicants.Should().BeEquivalentTo(expectedApplicants);

            this.storageBrokerMock.Verify(broker =>
            broker.SelectAllApplicants(), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
