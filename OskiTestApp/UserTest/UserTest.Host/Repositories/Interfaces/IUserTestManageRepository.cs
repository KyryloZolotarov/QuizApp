﻿using UserTest.Host.Data.Entities;

namespace UserTest.Host.Repositories.Interfaces
{
    public interface IUserTestManageRepository
    {
        Task AddUserTestAsync(UserTestEntity userTest);
        Task UpdateUserTestAsync(UserTestEntity userTest);
        Task DeleteUserTestAsync(UserTestEntity userTest);
        Task<UserTestEntity> GetUserTestAsync(int userTestId);
    }
}
