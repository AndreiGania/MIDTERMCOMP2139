namespace COMP2139_Qyuz.Models;

public class QuizQuestion
{

    public string QuestionText { get; set; }
    public List<string> Options { get; set; } = new List<string>();
    public string CorrectAnswer { get; set; }
    public string? ImageUrl { get; set; }
}