//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Brokers.Storages;
using ManageMe.Core.Api.Models.Users;

namespace ManageMe.Core.Api.Services.Foundations.Users
{
    public class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;

        public UserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<User> AddUserAsync(User user) =>
         await this.storageBroker.InsertUserAsync(user);

        public async ValueTask<User> RetrieveUserByIdAsync(Guid userid) =>
            await this.storageBroker.SelectUserByIdAsync(userid);

        public async ValueTask<User> RetrieveUserByEmailAndPasswordAsync(string email, string password) =>
            await this.storageBroker.SelectUserByEmailAndPasswordAsync(email, password);

        public IQueryable RetrieveAllUsers() =>
            this.storageBroker.SelectAllUsers();

        public async ValueTask<User> ModifyUserAsync(User user) =>
            await this.storageBroker.UpdateAppolicantAsync(user);

        public async ValueTask<User> RemoveUserAsync(Guid userid)
        {
            User user = await this.storageBroker.SelectUserByIdAsync(userid);

            return await this.storageBroker.DeleteUserAsync(user);
        }
    }
}
