﻿using Microsoft.AspNetCore.Mvc;
using Web.Server.ViewModels;

namespace Web.Server.Services.Interfaces
{
    public interface ITestService
    {
        Task<IEnumerable<TestViewModel>> GetAvailableTests(string userId);
        Task<TestViewModel> GetSelectedTest(int testId);
        Task<IEnumerable<TestViewModel>> GetPassedTests(string userId);
    }
}
