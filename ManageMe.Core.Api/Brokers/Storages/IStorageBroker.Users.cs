//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Users;

namespace ManageMe.Core.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
        ValueTask<User> SelectUserByIdAsync(Guid userId);
        ValueTask<User> SelectUserByEmailAndPasswordAsync(string email, string password);
        ValueTask<User> UpdateApplicantAsync(User user);
        ValueTask<User> DeleteUserAsync(User user);
    }
}
