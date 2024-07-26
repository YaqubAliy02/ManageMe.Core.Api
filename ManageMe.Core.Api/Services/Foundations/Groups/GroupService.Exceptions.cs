//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using EFxceptions.Models.Exceptions;
using ManageMe.Core.Api.Models.Groups;
using ManageMe.Core.Api.Models.Groups.Exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace ManageMe.Core.Api.Services.Foundations.Groups
{
    public partial class GroupService
    {
        private delegate ValueTask<Group> ReturningGroupFunction();
        private delegate IQueryable<Group> ReturningGroupsFunction();

        private async ValueTask<Group> TryCatch(ReturningGroupFunction returningGroupFunction)
        {
            try
            {
                return await returningGroupFunction();
            }
            catch (NullGroupException nullGroupExeption)
            {
                throw CreateAndLogValidationException(nullGroupExeption);
            }
            catch (InvalidGroupException invalidGroupException)
            {
                throw CreateAndLogValidationException(invalidGroupException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsGroupException =
                    new AlreadyExistsGroupException(
                        message: "Group already exists.",
                        innerException: duplicateKeyException);

                throw CreateAndALogDependencyValidationException(alreadyExistsGroupException);
            }
            catch (SqlException sqlException)
            {
                var failedGroupStorageException = new FailedGroupStorageException(
                   message: "Failed group storage error occurred, contact support.",
                   innerException: sqlException);

                throw CreateAndLogCriticalDependencyException(failedGroupStorageException);
            }
            catch (Exception exception)
            {
                var failedGroupServiceException = new FailedGroupServiceException(
                    message: "Failed group service error occurred, contact support.",
                    innerException: exception);

                throw CreateAndLogServiceException(failedGroupServiceException);
            }
        }

        private IQueryable<Group> TryCatch(ReturningGroupsFunction returningGroupsFunction)
        {
            try
            {
                return returningGroupsFunction();
            }
            catch (SqlException SqlException)
            {
                var failedGroupStorageException =
                    new FailedGroupStorageException(
                        message: "Failed group storage error occurred, contact support.",
                        innerException: SqlException);

                throw CreateAndLogCriticalDependencyException(failedGroupStorageException);
            }
            catch (Exception exception)
            {
                var failedGroupServiceException =
                    new FailedGroupServiceException(
                        message: "Failed group service error occurred, contact support.",
                        innerException: exception);

                throw CreateAndLogServiceException(failedGroupServiceException);
            }
        }

        private GroupDependencyValidationException CreateAndALogDependencyValidationException(Xeption exception)
        {
            var groupDependencyValidationException =
                new GroupDependencyValidationException(
                    message: "Group dependency validation error occurred, fix the error and try again.",
                    innerException: exception);

            this.loggingBroker.LogError(groupDependencyValidationException);

            return groupDependencyValidationException;
        }

        private GroupValidationException CreateAndLogValidationException(Xeption exception)
        {
            var groupValidationException =
                new GroupValidationException(
                    message: "Group validation error occurred, fix the error and try again.",
                    innerException: exception);

            this.loggingBroker.LogError(groupValidationException);

            return groupValidationException;
        }

        private GroupDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var groupDependencyException = new GroupDependencyException(
                message: "Group dependency error occurred, contact support.",
                innerException: exception);

            this.loggingBroker.LogCritical(groupDependencyException);

            return groupDependencyException;
        }

        private GroupServiceException CreateAndLogServiceException(Xeption exception)
        {
            var groupServiceException = new GroupServiceException(
                message: "Group dependency validation error occurred, fix the error and try again.",
                innerException: exception);
            this.loggingBroker.LogError(groupServiceException);

            return groupServiceException;
        }
    }
}
