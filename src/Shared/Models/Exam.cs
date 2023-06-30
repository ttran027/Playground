namespace Shared.Models;

public class Exam
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime ExamDate { get; set; }
    public int Grade { get; set; }
}