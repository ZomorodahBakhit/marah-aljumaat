using Microsoft.EntityFrameworkCore;
using UniversityDB2;
using UniversityDB2.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

using var db = new University2DbContext();

//Insertion 
//Data for all the interns into the user table with Role ‘Student’
var students = new List<User>
{
    new User { UserName = "Marah123", FirstName = "Marah", LastName = "Aljumaat", EmailAddress = "marahaljumaat@gmail.com", PhoneNumber = "0781234567", Role = "Student" },
    new User { UserName = "Aya123", FirstName = "Aya", LastName = "Jazba", EmailAddress = "aya.jazba@gmail.com", PhoneNumber = "0518479541", Role = "Student" },
    new User { UserName = "Hiba123", FirstName = "Hiba", LastName = "Jazba", EmailAddress = "hiba.jazba@gmail.com", PhoneNumber = "0518479567", Role = "Student" }
};
db.Users.AddRange(students);
db.SaveChanges();

////Two teachers (Sami, Feryal)
var teachers = new List<User>
{
    new User { UserName = "sami123", FirstName = "sami", LastName = "hijazi", EmailAddress = "sami.hijazi@88ninety.com", PhoneNumber = "+1(240) 381 9639", Role = "teacher"},
    new User { UserName = "feryal123", FirstName = "feryal", LastName = "tulaimat", EmailAddress = "feryal.tulaimat@88ninety.com", PhoneNumber = "0781239639", Role = "teacher"}
};
db.Users.AddRange(teachers);
db.SaveChanges();

////At least 5 courses assigned to that teacher (SQL, C#, Entity Framework, Web API and React)
var courses = new List<Course>
{
  new Course { CourseName = "SQL", StartDate = new DateTime(2026,06,10), EndDate = new DateTime(2026,06,11), TeacherId = 5 },
  new Course { CourseName = "C#", StartDate = new DateTime(2026,06,12), EndDate = new DateTime(2026,06,13), TeacherId = 5 },
  new Course { CourseName = "Entity Framework", StartDate = new DateTime(2026,06,14), EndDate = new DateTime(2026,06,15), TeacherId = 5 },
  new Course { CourseName = "Web API", StartDate = new DateTime(2026,06,16), EndDate = new DateTime(2026,06,17), TeacherId = 5 },
  new Course { CourseName = "React", StartDate = new DateTime(2026,06,18), EndDate = new DateTime(2026,06,19), TeacherId = 5 }
};
db.Courses.AddRange(courses);
db.SaveChanges();

////At least 5 assignments per course  (SQL, C#, Entity Framework, Web API and React) with random due dates (past & future).
var assignments = new List<Assignment>
{
    new Assignment { AssignmentTitle = "SQL Assignment 1", AssignmentDescription = "SQL Basics", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,06,15), CourseId = 1 },
    new Assignment { AssignmentTitle = "SQL Assignment 2", AssignmentDescription = "SQL Joins", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,06,20), CourseId = 1 },
    new Assignment { AssignmentTitle = "SQL Assignment 3", AssignmentDescription = "SQL Stored procedures", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,06,30), CourseId = 1 },
    new Assignment { AssignmentTitle = "SQL Assignment 4", AssignmentDescription = "SQL constraints", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,06,10), CourseId = 1 },
    new Assignment { AssignmentTitle = "SQL Assignment 5", AssignmentDescription = "SQL functions", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,06,22), CourseId = 1 },

    new Assignment { AssignmentTitle = "C# Assignment 1", AssignmentDescription = "C# Basics", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,06,25), CourseId = 2 },
    new Assignment { AssignmentTitle = "C# Assignment 2", AssignmentDescription = "C# OOP", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,06,30), CourseId = 2 },
    new Assignment { AssignmentTitle = "C# Assignment 3", AssignmentDescription = "C# Methods", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,07,01), CourseId = 2 },
    new Assignment { AssignmentTitle = "C# Assignment 4", AssignmentDescription = "C# Classes", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,07,15), CourseId = 2 },
    new Assignment { AssignmentTitle = "C# Assignment 5", AssignmentDescription = "C# Threads", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,06,10), CourseId = 2 },

    new Assignment { AssignmentTitle = "Entity Framework Assignment 1", AssignmentDescription = "EF Basics", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,07,05), CourseId = 3 },
    new Assignment { AssignmentTitle = "Entity Framework Assignment 2", AssignmentDescription = "EF Relationships", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,07,10), CourseId = 3 },
    new Assignment { AssignmentTitle = "Entity Framework Assignment 3", AssignmentDescription = "EF DbContext", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,06,10), CourseId = 3 },
    new Assignment { AssignmentTitle = "Entity Framework Assignment 4", AssignmentDescription = "EF migration", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,06,04), CourseId = 3 },
    new Assignment { AssignmentTitle = "Entity Framework Assignment 5", AssignmentDescription = "EF configuration", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,07,20), CourseId = 3 },

    new Assignment { AssignmentTitle = "Web API Assignment 1", AssignmentDescription = "API Basics", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,07,15), CourseId = 4 },
    new Assignment { AssignmentTitle = "Web API Assignment 2", AssignmentDescription = "API Authentication", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,07,20), CourseId = 4 },
    new Assignment { AssignmentTitle = "Web API Assignment 3", AssignmentDescription = "API tokens", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,07,01), CourseId = 4 },
    new Assignment { AssignmentTitle = "Web API Assignment 4", AssignmentDescription = "API swagger", Weight = 25, MaxGrade = 100, DueDate = new DateOnly(2026,06,20), CourseId = 4 },
    new Assignment { AssignmentTitle = "Web API Assignment 5", AssignmentDescription = "API structure", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,06,22), CourseId = 4 },

    new Assignment { AssignmentTitle = "React Assignment 1", AssignmentDescription = "React Basics", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,07,28), CourseId = 5 },
    new Assignment { AssignmentTitle = "React Assignment 2", AssignmentDescription = "React State Management", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,07,04), CourseId = 5 },
    new Assignment { AssignmentTitle = "React Assignment 3", AssignmentDescription = "React part 3", Weight = 10, MaxGrade = 100, DueDate = new DateOnly(2026,06,13), CourseId = 5 },
    new Assignment { AssignmentTitle = "React Assignment 4", AssignmentDescription = "React part 4", Weight = 15, MaxGrade = 100, DueDate = new DateOnly(2026,06,23), CourseId = 5 },
    new Assignment { AssignmentTitle = "React Assignment 5", AssignmentDescription = "React part 5", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,06,29), CourseId = 5 }

};
db.Assignments.AddRange(assignments);
db.SaveChanges();


////At least 10 comments for random assignments
var commentsR = new List<Comment>
{
    new Comment { CreatedDate = new DateTime(2026,07,01) ,CommentContent = "Great work!", UserId = 6 ,AssignmentId = 1 },
    new Comment { CreatedDate = new DateTime(2026,07,11) ,CommentContent = "Needs improvement.", UserId = 6 ,AssignmentId = 2 },
    new Comment { CreatedDate = new DateTime(2026,06,30) ,CommentContent = "Excellent explanation.", UserId = 6 ,AssignmentId = 3 },
    new Comment { CreatedDate = new DateTime(2026,07,15) ,CommentContent = "Good effort.", UserId = 6 ,AssignmentId = 4 },
    new Comment { CreatedDate = new DateTime(2026,07,16) ,CommentContent = "Well done!", UserId = 5 ,AssignmentId = 5 },
    new Comment { CreatedDate = new DateTime(2026,07,17) ,CommentContent = "Keep it up!", UserId = 5 ,AssignmentId = 6 },
    new Comment { CreatedDate = new DateTime(2026,06,22) ,CommentContent = "Not bad.", UserId = 1 ,AssignmentId = 7 },
    new Comment { CreatedDate = new DateTime(2026,07,23) ,CommentContent = "Could be better.", UserId = 2 ,AssignmentId = 8 },
    new Comment { CreatedDate = new DateTime(2026,06,27) ,CommentContent = "Fantastic job!", UserId = 3 ,AssignmentId = 9 },
    new Comment { CreatedDate = new DateTime(2026,07,24) ,CommentContent = "Nice try.", UserId = 1 ,AssignmentId = 10 }
};
db.Comments.AddRange(commentsR);
db.SaveChanges();

////A grade for each student per assignment
var grades = new List<Grade>
{
    new Grade { GradeNumber = 85, StudentId = 1, AssignmentId = 1 },
    new Grade { GradeNumber = 90, StudentId = 1, AssignmentId = 2 },
    new Grade { GradeNumber = 78, StudentId = 1, AssignmentId = 3 },
    new Grade { GradeNumber = 92, StudentId = 1, AssignmentId = 4 },
    new Grade { GradeNumber = 88, StudentId = 1, AssignmentId = 5 },
    new Grade { GradeNumber = 95, StudentId = 1, AssignmentId = 6 },
    new Grade { GradeNumber = 80, StudentId = 1, AssignmentId = 7 },
    new Grade { GradeNumber = 87, StudentId = 1, AssignmentId = 8 },
    new Grade { GradeNumber = 91, StudentId = 1, AssignmentId = 9 },
    new Grade { GradeNumber = 89, StudentId = 1, AssignmentId = 10 },
    new Grade { GradeNumber = 85, StudentId = 1, AssignmentId = 11 },
    new Grade { GradeNumber = 90, StudentId = 1, AssignmentId = 12 },
    new Grade { GradeNumber = 78, StudentId = 1, AssignmentId = 13 },
    new Grade { GradeNumber = 92, StudentId = 1, AssignmentId = 14 },
    new Grade { GradeNumber = 88, StudentId = 1, AssignmentId = 15 },
    new Grade { GradeNumber = 95, StudentId = 1, AssignmentId = 16 },
    new Grade { GradeNumber = 80, StudentId = 1, AssignmentId = 17 },
    new Grade { GradeNumber = 87, StudentId = 1, AssignmentId = 18 },
    new Grade { GradeNumber = 91, StudentId = 1, AssignmentId = 19 },
    new Grade { GradeNumber = 89, StudentId = 1, AssignmentId = 20 },
    new Grade { GradeNumber = 95, StudentId = 1, AssignmentId = 21 },
    new Grade { GradeNumber = 80, StudentId = 1, AssignmentId = 22 },
    new Grade { GradeNumber = 87, StudentId = 1, AssignmentId = 23 },
    new Grade { GradeNumber = 91, StudentId = 1, AssignmentId = 24 },
    new Grade { GradeNumber = 89, StudentId = 1, AssignmentId = 25 },

    new Grade { GradeNumber = 85, StudentId = 2, AssignmentId = 1 },
    new Grade { GradeNumber = 84, StudentId = 2, AssignmentId = 2 },
    new Grade { GradeNumber = 83, StudentId = 2, AssignmentId = 3 },
    new Grade { GradeNumber = 82, StudentId = 2, AssignmentId = 4 },
    new Grade { GradeNumber = 81, StudentId = 2, AssignmentId = 5 },
    new Grade { GradeNumber = 80, StudentId = 2, AssignmentId = 6 },
    new Grade { GradeNumber = 79, StudentId = 2, AssignmentId = 7 },
    new Grade { GradeNumber = 78, StudentId = 2, AssignmentId = 8 },
    new Grade { GradeNumber = 77, StudentId = 2, AssignmentId = 9 },
    new Grade { GradeNumber = 76, StudentId = 2, AssignmentId = 10 },
    new Grade { GradeNumber = 75, StudentId = 2, AssignmentId = 11 },
    new Grade { GradeNumber = 74, StudentId = 2, AssignmentId = 12 },
    new Grade { GradeNumber = 73, StudentId = 2, AssignmentId = 13 },
    new Grade { GradeNumber = 72, StudentId = 2, AssignmentId = 14 },
    new Grade { GradeNumber = 71, StudentId = 2, AssignmentId = 15 },
    new Grade { GradeNumber = 70, StudentId = 2, AssignmentId = 16 },
    new Grade { GradeNumber = 69, StudentId = 2, AssignmentId = 17 },
    new Grade { GradeNumber = 65, StudentId = 2, AssignmentId = 18 },
    new Grade { GradeNumber = 64, StudentId = 2, AssignmentId = 19 },
    new Grade { GradeNumber = 63, StudentId = 2, AssignmentId = 20 },
    new Grade { GradeNumber = 62, StudentId = 2, AssignmentId = 21 },
    new Grade { GradeNumber = 61, StudentId = 2, AssignmentId = 22 },
    new Grade { GradeNumber = 60, StudentId = 2, AssignmentId = 23 },
    new Grade { GradeNumber = 59, StudentId = 2, AssignmentId = 24 },
    new Grade { GradeNumber = 58, StudentId = 2, AssignmentId = 25 },

    new Grade { GradeNumber = 90, StudentId = 3, AssignmentId = 1 },
    new Grade { GradeNumber = 91, StudentId = 3, AssignmentId = 2 },
    new Grade { GradeNumber = 92, StudentId = 3, AssignmentId = 3 },
    new Grade { GradeNumber = 93, StudentId = 3, AssignmentId = 4 },
    new Grade { GradeNumber = 94, StudentId = 3, AssignmentId = 5 },
    new Grade { GradeNumber = 95, StudentId = 3, AssignmentId = 6 },
    new Grade { GradeNumber = 96, StudentId = 3, AssignmentId = 7 },
    new Grade { GradeNumber = 97, StudentId = 3, AssignmentId = 8 },
    new Grade { GradeNumber = 98, StudentId = 3, AssignmentId = 9 },
    new Grade { GradeNumber = 99, StudentId = 3, AssignmentId = 10 },
    new Grade { GradeNumber = 100, StudentId = 3, AssignmentId = 11 },
    new Grade { GradeNumber = 90, StudentId = 3, AssignmentId = 12 },
    new Grade { GradeNumber = 89, StudentId = 3, AssignmentId = 13 },
    new Grade { GradeNumber = 87, StudentId = 3, AssignmentId = 14 },
    new Grade { GradeNumber = 88, StudentId = 3, AssignmentId = 15 },
    new Grade { GradeNumber = 95, StudentId = 3, AssignmentId = 16 },
    new Grade { GradeNumber = 78, StudentId = 3, AssignmentId = 17 },
    new Grade { GradeNumber = 99, StudentId = 3, AssignmentId = 18 },
    new Grade { GradeNumber = 83, StudentId = 3, AssignmentId = 19 },
    new Grade { GradeNumber = 56, StudentId = 3, AssignmentId = 20 },
    new Grade { GradeNumber = 15, StudentId = 3, AssignmentId = 21 },
    new Grade { GradeNumber = 20, StudentId = 3, AssignmentId = 22 },
    new Grade { GradeNumber = 48, StudentId = 3, AssignmentId = 23 },
    new Grade { GradeNumber = 35, StudentId = 3, AssignmentId = 24 },
    new Grade { GradeNumber = 24, StudentId = 3, AssignmentId = 25 }
};
db.Grades.AddRange(grades);
db.SaveChanges();

////A syllabus for each course
var syllabuses = new List<Syllabus>
{
    new Syllabus { SyllabusDescription = "SQL Syllabus Content", CourseId = 1 },
    new Syllabus { SyllabusDescription = "C# Syllabus Content", CourseId = 2 },
    new Syllabus { SyllabusDescription = "Entity Framework Syllabus Content", CourseId = 3 },
    new Syllabus { SyllabusDescription = "Web API Syllabus Content", CourseId = 4 },
    new Syllabus { SyllabusDescription = "React Syllabus Content", CourseId = 5 }
};
db.Syllabuses.AddRange(syllabuses);
db.SaveChanges();

//Queries
//List all courses
var coursesList = db.Courses.ToList();
foreach (var course in coursesList)
{
    Console.WriteLine($"Course ID: {course.CourseId}, Course Name: {course.CourseName}");
}

//Show all assignments for a specific course
var assignmentsForCourse = db.Assignments.Where(a => a.CourseId == 1).ToList();
foreach(var assignment in assignmentsForCourse)
{
    Console.WriteLine($"Assignment ID: {assignment.AssignmentId}, Title: {assignment.AssignmentTitle}, CourseId: {assignment.CourseId}");
}

//List all students
var studentList = db.Users.Where(s => s.Role == "Student").ToList();
foreach(var student in studentList)
{
    Console.WriteLine($"Student ID: {student.UserId}, Name: {student.FirstName} {student.LastName}");
}

//Show all comments for a given assignment
var commentsForAssignment = db.Comments.Where(c => c.AssignmentId == 1).ToList();
foreach(var comment in commentsForAssignment)
{
    Console.WriteLine($"Comment: {comment.CommentContent}, AssignmentId: {comment.AssignmentId} ");
}

//Show all grades for a student
var gradesForStudent = db.Grades.Where(g => g.StudentId == 1).ToList();
foreach(var grade in gradesForStudent)
{
    Console.WriteLine($"StudentId: {grade.StudentId}, Grade: {grade.GradeNumber}, AssignmentId: {grade.AssignmentId}");
}

//List each assignment with its course and the teacher’s full name
var assignmentsWithCourseAndTeacher = db.Assignments
    .Include(a => a.Course)
    .ThenInclude(c => c.Teacher)
    .ToList();
foreach (var assignment in assignmentsWithCourseAndTeacher)
{
    Console.WriteLine($"Assignment: {assignment.AssignmentTitle}, Course: {assignment.Course.CourseName}, Teacher: {assignment.Course.Teacher.FirstName} {assignment.Course.Teacher.LastName}");
}

//Query to show average grade per course
var averageGradePerCourse = db.Grades
    .GroupBy(g => g.Assignment.Course.CourseName)
    .Select(g => new
    {
        CourseName = g.Key,
        AverageGrade = g.Average(x => x.GradeNumber)
    })
    .ToList();
foreach (var avgGrade in averageGradePerCourse)
{
    Console.WriteLine($"Course: {avgGrade.CourseName}, Average Grade: {avgGrade.AverageGrade}");
}

//Create a method to return letter grades (A, B, C, etc.) based on the student’s performance


//Create a method to calculate GPA for a student


//Updates & Deletions
//Update a student’s role to “Teacher”
var studentToUpdate = db.Users.FirstOrDefault(s => s.UserId == 3);

if (studentToUpdate != null)
{

    if (studentToUpdate.Role == "Teacher")
    {
        Console.WriteLine("User is already a Teacher. No changes made.");
    }
    else
    {
        studentToUpdate.Role = "Teacher";
        db.SaveChanges();
        Console.WriteLine("Student role updated to Teacher successfully.");
    }
}
else
{
    Console.WriteLine("Student not found.");
}

//Delete a specific comment
var commentToDelete = db.Comments.FirstOrDefault(co => co.CommentId == 8);

if (commentToDelete != null)
{
    db.Comments.Remove(commentToDelete);
    db.SaveChanges();
    Console.WriteLine("Comment deleted successfully.");
}
else
{
    Console.WriteLine("Comment not found.");
}