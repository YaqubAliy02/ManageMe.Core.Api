//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using FluentAssertions;
using ManageMe.Core.Api.Models.Applicants.Exceptions;
using Microsoft.Data.SqlClient;
using Moq;

namespace ManageMe.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public void ShouldThrowCriticalDependencyExceptionOnRetrieveAllIfSqlErrorOccureAndLogIt()
        {
            //given
            SqlException sqlException = GetSqlError();

            var failedStorageApplicantException =
                new FailedApplicantStorageException(
                    message: "Failed applicant storage error occurred, contact support",
                    innerException: sqlException);

            var expectedApplicantDependencyException =
                new ApplicantDependencyException(
                    message: "Applicant dependency error occurred, contact support",
                    innerException: failedStorageApplicantException);

            this.storageBrokerMock.Setup(broker =>
            broker.SelectAllApplicants()).Throws(sqlException);

            //when
            Action retrieveAllApplicantsAction = () =>
                this.applicantService.RetrieveAllApplicants();

            ApplicantDependencyException ApplicantDependencyException =
                Assert.Throws<ApplicantDependencyException>(retrieveAllApplicantsAction);

            //then
            ApplicantDependencyException.Should().BeEquivalentTo(
                expectedApplicantDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllApplicants(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedApplicantDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursLogIt()
        {
            //given
            string someMessage = GetRandomString();
            var serviceException = new Exception(someMessage);

            var failedApplicantServiceException =
                new FailedApplicantServiceException(
                    message: "Failed applicant service error occurred, contact support",
                    innerException: serviceException);

            var expectedApplicantServiceException =
                new ApplicantServiceException(
                    message: "Appplicant service error occurred, contact support",
                    innerException: failedApplicantServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllApplicants()).Throws(serviceException);

            //when
            Action retrieveAllApplicantsAction = () =>
            this.applicantService.RetrieveAllApplicants();

            ApplicantServiceException ApplicantServiceException =
                Assert.Throws<ApplicantServiceException>(retrieveAllApplicantsAction);

            //then
            ApplicantServiceException.Should().BeEquivalentTo(expectedApplicantServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllApplicants(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedApplicantServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
