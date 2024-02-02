﻿using Infrastructure.Exceptions;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using UserProfiles.Host.Data;
using UserProfiles.Host.Data.Entities;
using UserProfiles.Host.Models.Dtos;
using UserProfiles.Host.Models.Requests;
using UserProfiles.Host.Repositories.Interfaces;
using UserProfiles.Host.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace UserProfiles.Host.Services
{
    public class UserManageService : BaseDataService<ApplicationDbContext>, IUserManageService
    {

        private readonly IUserManageRepository _userManageRepository;
        public UserManageService(IUserManageRepository userManageRepository,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger)
            : base(dbContextWrapper, logger)
        {
            _userManageRepository = userManageRepository;
        }

        public async Task AddUserAsync(AddUserRequest user)
        {
            await ExecuteSafeAsync(async () =>
            {
                var userAdd = new UserEntity()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                };

                await _userManageRepository.AddUserAsync(userAdd);
            });
        }

        public async Task DeleteUserAsync(string userId)
        {
            var userExists = await ExecuteSafeAsync(async () => await _userManageRepository.GetUserAsync(userId));

            if (userExists == null)
            {
                throw new BusinessException($"User with id: {userId} not found");
            }

            await ExecuteSafeAsync(async () =>
            {
                await _userManageRepository.DeleteUserAsync(userExists);
            });
        }

        public async Task UpdateUserAsync(UpdateUserRequest user)
        {
            var userExists = await ExecuteSafeAsync(async () => await _userManageRepository.GetUserAsync(user.Id));

            if (userExists == null)
            {
                throw new BusinessException($"User with id: {user.Id} not found");
            }

            if (user.FirstName != null)
            {
                userExists.FirstName = user.FirstName;
            }

            if (user.LastName != null)
            {
                userExists.LastName = user.LastName;
            }

            if (user.Email != null)
            {
                userExists.Email = user.Email;
            }

            if (user.Password != null)
            {
                userExists.Password = user.Password;
            }

            await ExecuteSafeAsync(async () =>
            {
                await _userManageRepository.UpdateUserAsync(userExists);
            });
        }
    }
}
