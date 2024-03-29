﻿using Infrastructure.Exceptions;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using TestCatalog.Host.Data;
using TestCatalog.Host.Data.Entities;
using TestCatalog.Host.Models.Requests;
using TestCatalog.Host.Repositories.Interfaces;
using TestCatalog.Host.Services.Interfaces;

namespace TestCatalog.Host.Services;

public class QuestionService : BaseDataService<ApplicationDbContext>, IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
    {
        _questionRepository = questionRepository;
    }

    public async Task AddQuestionAsync(AddQuestionRequest question)
    {
        await ExecuteSafeAsync(async () =>
        {
            var questionAdd = new QuestionEntity
            {
                TestId = question.TestId,
                Question = question.Question,
                Test = new TestEntity
                {
                    Id = question.Test.Id,
                    Description = question.Test.Description,
                    Name = question.Test.Name
                }
            };
            await _questionRepository.AddQuestionAsync(questionAdd);
        });
    }

    public async Task DeleteQuestionAsync(int questionId)
    {
        var questionExists = await ExecuteSafeAsync(async () => await _questionRepository.GetQuestionAsync(questionId));

        if (questionExists == null) throw new BusinessException($"Question with id: {questionId} not found");

        await ExecuteSafeAsync(async () => { await _questionRepository.DeleteQuestionAsync(questionExists); });
    }

    public async Task UpdateQuestionAsync(UpdateQuestionRequest question)
    {
        var questionExists =
            await ExecuteSafeAsync(async () => await _questionRepository.GetQuestionAsync(question.Id));

        if (questionExists == null) throw new BusinessException($"Question with id: {question.Id} not found");

        if (question.Question != null) questionExists.Question = question.Question;

        if (question.TestId != null) questionExists.TestId = question.TestId;

        await ExecuteSafeAsync(async () => { await _questionRepository.UpdateQuestionAsync(questionExists); });
    }
}