//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Users;

namespace ManageMe.Core.Api.Services.Processings.Users
{
    public interface IUserProcessingService
    {
        ValueTask<User> AddUserAsync(User user);
        ValueTask<User> RetrieveUserByIdAsync(Guid userid);
        ValueTask<User> RetrieveUserByEmailAndPasswordAsync(string email, string password);
        IQueryable RetrieveAllUsers();
        ValueTask<User> ModifyUserAsync(User user);
        ValueTask<User> RemoveUserAsync(Guid userid);
    }
}