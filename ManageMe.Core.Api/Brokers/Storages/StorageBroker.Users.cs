//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ManageMe.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user) =>
            await this.InsertAsync(user);

        public IQueryable<User> SelectAllUsers() =>
            this.SelectAll<User>();

        public async ValueTask<User> SelectUserByIdAsync(Guid userId) =>
           await this.SelectAsync<User>(userId);

        public async ValueTask<User> SelectUserByEmailAndPasswordAsync(string email, string password) =>
           await this.SelectAsync<User>(email, password);

        public async ValueTask<User> UpdateApplicantAsync(User user) =>
            await this.UpdateAsync(user);

        public async ValueTask<User> DeleteUserAsync(User user) =>
            await this.DeleteAsync(user);
    }
}
