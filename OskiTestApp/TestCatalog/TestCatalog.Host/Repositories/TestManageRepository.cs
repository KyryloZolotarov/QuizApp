﻿using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestCatalog.Host.Data;
using TestCatalog.Host.Data.Entities;
using TestCatalog.Host.Repositories.Interfaces;

namespace TestCatalog.Host.Repositories
{
    public class TestManageRepository : ITestManageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TestManageRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task AddTestAsync(TestEntity test)
        {
            await _dbContext.Tests.AddAsync(test);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTestAsync(TestEntity test)
        {
            _dbContext.Tests.Remove(test);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TestEntity> GetTestAsync(int testId)
        {
            return await _dbContext.Tests.FirstOrDefaultAsync(h => h.Id == testId);
        }

        public async Task UpdateTestAsync(TestEntity test)
        {
            _dbContext.Tests.Update(test);
            await _dbContext.SaveChangesAsync();
        }
    }
}
