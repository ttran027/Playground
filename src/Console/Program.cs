using Shared;
using System.Text.Json;
static void PrintData(object obj) =>
    Console.WriteLine(JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true }));
var database = new Database();
database.Students.ForEach(PrintData);
//database.Instructors.ForEach(PrintData);
//database.Courses.ForEach(PrintData);
//database.Exams.ForEach(PrintData);