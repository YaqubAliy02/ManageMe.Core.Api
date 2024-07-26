//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Groups;

namespace ManageMe.Core.Api.Services.Foundations.Groups
{
    public interface IGroupService
    {
        ValueTask<Group> AddGroupAsync(Group group);
    }
}