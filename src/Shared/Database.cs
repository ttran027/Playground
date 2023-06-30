using Bogus;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public class Database
{
    private readonly List<Student> _students;
    private readonly List<Instructor> _instructors;
    private readonly List<Course> _courses;
    private readonly List<Exam> _exams;
    public Database()
    {
        _students = new Faker<Student>()
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.DateOfBirth, f => f.Date.Past(6, DateTime.Today.AddYears(-18)))
            .Generate(20)
            .Select((s, i) =>
            {
                s.StudentId = i + 1;
                return s;
            })
            .ToList();

        _instructors = new Faker<Instructor>()
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .Generate(5)
            .Select((s, i) =>
            {
                s.InstructorId = i + 1;
                return s;
            })
            .ToList();

        _courses = new Faker<Course>()
            .RuleFor(x => x.CourseName, f => $"Learn to {f.Hacker.Verb()} with {f.Hacker.Noun()}")
            .RuleFor(x => x.InstructedBy, f => f.Random.Int(1,5))
            .Generate(10)
            .Select((s, i) =>
            {
                s.CourseId = i + 1;
                return s;
            })
            .ToList();

        _exams = new Faker<Exam>()
            .RuleFor(x => x.CourseId, f => f.Random.Int(1, 10))
            .RuleFor(x => x.StudentId, f => f.Random.Int(1, 20))
            .RuleFor(x => x.ExamDate, f => f.Date.Past(1, DateTime.Today).Date)
            .RuleFor(x => x.Grade, f => f.Random.Int(0, 100))
            .Generate(200)
            .DistinctBy(x => new
            {
                x.StudentId,
                x.CourseId,
                x.ExamDate
            })
            .ToList();
    }

    public List<Student> Students => _students;
    public List<Instructor> Instructors => _instructors;
    public List<Course> Courses => _courses;
    public List<Exam> Exams => _exams;

}