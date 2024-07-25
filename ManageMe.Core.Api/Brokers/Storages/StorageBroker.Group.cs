//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Groups;
using Microsoft.EntityFrameworkCore;

namespace ManageMe.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Group> Groups { get; set; }
        public async ValueTask<Group> InsertGroupAsync(Group group) =>
            await this.InsertAsync(group);

        public IQueryable<Group> SelectAllGroups() =>
            this.SelectAll<Group>();

        public async ValueTask<Group> SelectGroupByIdAsync(Guid groupId) =>
            await this.SelectAsync<Group>(groupId);

        public async ValueTask<Group> UpdateGroupAsync(Group group) =>
            await this.UpdateAsync(group);

        public async ValueTask<Group> DeleteGroupAsync(Group group) =>
            await this.DeleteAsync(group);
    }
}
