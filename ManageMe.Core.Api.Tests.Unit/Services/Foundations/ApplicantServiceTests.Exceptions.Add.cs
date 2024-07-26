//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using EFxceptions.Models.Exceptions;
using FluentAssertions;
using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Models.Applicants.Exceptions;
using Microsoft.Data.SqlClient;
using Moq;

namespace ManageMe.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccursLogItAsync()
        {
            //given
            Applicant someApplicant = CreateRandomApplicant();

            SqlException sqlException = GetSqlError();
            var failedApplicantStorageException =
                new FailedApplicantStorageException(
                    message: "Failed applicant storage error occurred, contact support",
                    innerException: sqlException);

            var expectedApplicantDependencyException =
                new ApplicantDependencyException(
                    message: "Applicant dependency error occurred, contact support",
                    innerException: failedApplicantStorageException);

            this.storageBrokerMock.Setup(broker => broker.InsertApplicantAsync(someApplicant))
                .ThrowsAsync(sqlException);

            //when
            ValueTask<Applicant> addApplicantTask =
                this.applicantService.AddApplicantAsync(someApplicant);

            //then
            await Assert.ThrowsAsync<ApplicantDependencyException>(() =>
                addApplicantTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantAsync(someApplicant), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedApplicantDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfDuplicateKeyErrorOccursAndLogItAsync()
        {
            // given
            string someMessage = GetRandomString();
            Applicant someApplicant = CreateRandomApplicant();
            var duplicateKeyException = new DuplicateKeyException(someMessage);

            var alreadyExistsApplicantException =
                new AlreadyExistsApplicantException(
                    message: "Appliacant already exists.",
                    innerException: duplicateKeyException);

            var expectedApplicantDependencyValidationException =
                new ApplicantDependencyValidationException(
                    message: "Applicant dependency validation error occurred. Fix the error and try again.",
                    innerException: alreadyExistsApplicantException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertApplicantAsync(someApplicant)).ThrowsAsync(duplicateKeyException);

            // when
            ValueTask<Applicant> addApplicantTask =
                this.applicantService.AddApplicantAsync(someApplicant);

            var actualApplicantDependencyValidationException =
                await Assert.ThrowsAsync<ApplicantDependencyValidationException>(addApplicantTask.AsTask);

            // then
            actualApplicantDependencyValidationException.Should()
                .BeEquivalentTo(expectedApplicantDependencyValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantAsync(someApplicant), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedApplicantDependencyValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogItAsync()
        {
            //given
            Applicant someApplicant = CreateRandomApplicant();

            var serviceException = new Exception();

            var failedApplicantServiceException =
                new FailedApplicantServiceException(
                    message: "Failed applicant service error occurred, contact support",
                    innerException: serviceException);

            var excpectedApplicantServiceException =
                new ApplicantServiceException(
                    message: "Applicant service error occurred, contact support",
                    innerException: failedApplicantServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertApplicantAsync(someApplicant)).ThrowsAsync(serviceException);

            //when
            ValueTask<Applicant> addApplicantTask =
                this.applicantService.AddApplicantAsync(someApplicant);

            //then
            await Assert.ThrowsAsync<ApplicantServiceException>(() =>
                addApplicantTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantAsync(someApplicant), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    excpectedApplicantServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
