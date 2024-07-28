//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Groups;

namespace ManageMe.Core.Api.Services.Processings.Groups
{
    public interface IGroupProcessingService
    {
        ValueTask<Group> EnsureGroupExistsByName(string groupName);
        ValueTask<Group> AddGroupAsync(Group group);
        ValueTask<Group> RetrieveGroupByIdAsync(Guid groupid);
        IQueryable<Group> RetrieveAllGroups();
        ValueTask<Group> ModifyGroupAsync(Group group);
        ValueTask<Group> RemoveGroupAsync(Guid groupid);
    }
}