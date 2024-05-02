﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApplication.Core.Models;

public class Answer : BaseEntity
{
    [Required]
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    [ForeignKey("Question")] public int QuestionId { get; set; }
    public virtual Question Question { get; set; }

    public void Update(string text, bool isCorrect, int questionId)
    {
        Text = text;
        IsCorrect = isCorrect;
        QuestionId = questionId;
        UpdatedTime = DateTime.UtcNow;
    }
}