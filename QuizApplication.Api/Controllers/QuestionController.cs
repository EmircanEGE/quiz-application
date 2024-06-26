﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Api.Models.Question;
using QuizApplication.Application.Services;

namespace QuizApplication.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] QuestionCreateRequest request)
    {
        var result = await _questionService.CreateAsync(request.Text, request.QuizId);
        if (result.StatusCode == 404) return StatusCode(result.StatusCode, result.Message);
        return StatusCode(result.StatusCode);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] QuestionUpdateRequest request)
    {
        var result = await _questionService.UpdateAsync(id, request.Text, request.QuizId);
        return StatusCode(result.StatusCode, result.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _questionService.DeleteAsync(id);
        return StatusCode(result.StatusCode, result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _questionService.GetByIdAsync(id);
        return StatusCode(result.StatusCode, result.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string text, int? quizId, int page = 1, int pageSize = 10)
    {
        var result = await _questionService.GetAsync(text, quizId, page, pageSize);
        if (result.StatusCode >= 400) return StatusCode(result.StatusCode, result.Message);
        return StatusCode(result.StatusCode, result.Data);
    }
}