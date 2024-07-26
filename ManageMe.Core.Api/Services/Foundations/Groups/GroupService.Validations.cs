//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Groups;
using ManageMe.Core.Api.Models.Groups.Exceptions;

namespace ManageMe.Core.Api.Services.Foundations.Groups
{
    public partial class GroupService
    {
        private void ValidateGroupOnAdd(Group group)
        {
            ValidateGroupNotNull(group);

            Validate(
                (Rule: IsInvalid(group.GroupId), Parameter: nameof(Group.GroupId)),
                (Rule: IsInvalid(group.GroupName), Parameter: nameof(Group.GroupName)));
        }

        private void ValidateGroupOnModify(Group group)
        {
            ValidateGroupNotNull(group);

            Validate(
                (Rule: IsInvalid(group.GroupId), Parameter: nameof(Group.GroupId)),
                (Rule: IsInvalid(group.GroupName), Parameter: nameof(Group.GroupName)));
        }
        private void ValidateAgainstStorageGroupOnModify(Group inputAccount, Group storageGroup)
        {
            ValidateStorageGroup(storageGroup, inputAccount.GroupId);

            Validate(
                (Rule: IsInvalid(inputAccount.GroupId), Parameter: nameof(Group.GroupId)),
                (Rule: IsInvalid(inputAccount.GroupName), Parameter: nameof(Group.GroupName)));
        }
        private void ValidateGroupId(Guid groupId) =>
            Validate((Rule: IsInvalid(groupId), Parameter: nameof(Group.GroupId)));

        private void ValidateStorageGroup(Group maybeGroup, Guid groupId)
        {
            if (maybeGroup is null)
            {
                throw new NotFoundGroupException(
                    message: $"Group is not found with id: {groupId}.");
            }
        }

        private static dynamic IsInvalid(Guid groupId) => new
        {
            Condition = groupId == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {

            Condition = System.String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void ValidateGroupNotNull(Group group)
        {
            if (group == null)
            {
                throw new NullGroupException(message: "Group is null.");
            }
        }
        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidClientException = new InvalidGroupException(message: "Group is invalid.");

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
