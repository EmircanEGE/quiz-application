﻿namespace QuizApplication.Data.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedTime { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
}