CREATE DATABASE UniversityDB;
GO 
USE UniversityDB;
GO
------Create the following tables with appropriate data types, constraints and keys:
CREATE TABLE Users(
    UserId INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(64) NOT NULL,
    FirstName VARCHAR(64) NOT NULL,
    LastName VARCHAR(64) NOT NULL,
    EmailAddress VARCHAR(128) NOT NULL UNIQUE,
    PhoneNumber VARCHAR(16) NOT NULL,
    Role VARCHAR(32) NOT NULL); 

CREATE TABLE Syllabus (
    SyllabusId INT PRIMARY KEY IDENTITY(1,1),
    Description TEXT NULL)

CREATE TABLE Courses(
    CourseId INT PRIMARY KEY IDENTITY(1,1),
    CourseName VARCHAR(100) NOT NULL,
    TeacherId INT NULL,
    StartDate DateTime NOT NULL,
    EndDate DateTime NOT NULL,
    SyllabusId INT NULL REFERENCES Syllabus(SyllabusId)) 
ALTER TABLE Courses ADD CONSTRAINT FK_Courses_TeacherId FOREIGN KEY (TeacherId) REFERENCES Users(UserId);


CREATE TABLE Assignments (
    AssignmentId INT PRIMARY KEY IDENTITY(1,1),
    CourseId INT NOT NULL REFERENCES Courses(CourseId),
    AssignmentTitle VARCHAR(128) NOT NULL,
    Description TEXT NULL,
    Weight float NOT NULL,
    MaxGrade INT NOT NULL,
    DueDate DATE NOT NULL)

CREATE TABLE Comments(
    CommentId INT PRIMARY KEY IDENTITY(1,1),
    AssignmentId INT NOT NULL REFERENCES Assignments(AssignmentId),
    CreatedByUserId INT NOT NULL REFERENCES Users(UserId), 
    CreatedDate DATETIME NOT NULL,
    CommentContent TEXT NULL)

CREATE TABLE Grades (
    GradeId INT PRIMARY KEY IDENTITY(1,1),
    AssignmentId INT NOT NULL REFERENCES Assignments(AssignmentId),
    StudentId INT NOT NULL REFERENCES Users(UserId),
    Grade INT NULL)
GO 

----Write SQL statements to INSERT data for all the interns into the user table with Role ‘Student’
INSERT INTO Users(UserName, FirstName, LastName, EmailAddress, PhoneNumber, Role)
VALUES
('Marah123', 'Marah', 'Aljumaat', 'marahaljumaat@gmail.com', '05354444444', 'Student'),
('Aya123', 'Aya', 'Jazba', 'Ayajazba@gmail.com', '05353333333', 'Student'), 
('Hiba123', 'Hiba', 'Jazba', 'Hibajazba@gmail.com', '05355555555', 'Student'),
('Masa123', 'Masa', 'Hammoud', 'Masahammoud@gmail.com','05356666666', 'Student'); 

SELECT * FROM Users;

----Write SQL statements to INSERT data for Sami, Feryal into the user table with Role ‘Teacher’
INSERT INTO Users(UserName, FirstName, LastName, EmailAddress, PhoneNumber, Role)
VALUES
('Sami123', 'Sami', 'Hijazi', 'sami.hijazi@88ninety.com', '+12403819639', 'Teacher'),
('Feryal123', 'Feryal', 'FeryalLastName', 'feryal@88ninety.com', '05359999999', 'Teacher');

----Write SQL Statement to INSERT Syllabus for each Course.
INSERT INTO Syllabus(Description)
VALUES 
('This syllabus covers the fundamentals of SQL, including database design, querying, and optimization.'),
('This syllabus covers the basics of C# programming, including syntax, object-oriented programming, and application development.'),
('This syllabus covers the Entity Framework, including data modeling, database interactions, and performance optimization.'),
('This syllabus covers Web API development using ASP.NET Core, including RESTful design principles and security considerations.'),
('This syllabus covers React.js fundamentals, including component-based architecture, state management, and hooks.');
SELECT * FROM Syllabus;

----Write SQL statements to INSERT data for SQL, C#, Entity Framework, Web API and React Courses.
INSERT INTO Courses(CourseName, TeacherId, StartDate, EndDate, SyllabusId)
VALUES
('SQL', 5 , '2026-06-22', '2026-06-23', 1),
('C#', 5, '2026-06-24', '2026-06-25', 2),
('Entity Framework', 5, '2026-06-28', '2026-06-29', 3),
('Web API', 5, '2026-06-30', '2026-07-01', 4),
('React', 6, '2026-07-01', '2026-07-02', 5);
SELECT * FROM Courses;

----Write SQL Statements to INSERT at least 5 Assignments for each Course with random due dates (past & future).
INSERT INTO Assignments(CourseId, AssignmentTitle, Description, Weight, MaxGrade, DueDate)
VALUES
(1, 'SQL Assignment 1', 'Write SQL queries to retrieve data from the database.', 0.20, 100, '2026-06-25'),
(1, 'SQL Assignment 2', 'Design a database schema for a library system.', 0.30, 100, '2026-07-01'),
(1, 'SQL Assignment 3', 'Optimize SQL queries for performance.', 0.25, 100, '2026-07-10'),
(1, 'SQL Assignment 4', 'Implement stored procedures and triggers.', 0.15, 100, '2026-06-15'),
(1, 'SQL Assignment 5', 'Create a backup and restore strategy for the database.', 0.10, 100, '2026-07-20'),
(2, 'C# Assignment 1', 'Create a console application that performs basic arithmetic operations.', 0.20, 100, '2026-06-26'),
(2, 'C# Assignment 2', 'Implement a simple class hierarchy with inheritance and polymorphism.', 0.30, 100, '2026-06-02'),
(2, 'C# Assignment 3', 'Develop a Windows Forms application for managing a to-do list.', 0.25, 100, '2026-07-11'),
(2, 'C# Assignment 4', 'Create a WPF application that displays data from a database.', 0.15, 100, '2026-07-16'),
(2, 'C# Assignment 5', 'Implement error handling and logging in a C# application.', 0.10, 100, '2026-07-21'),
(3, 'Entity Framework Assignment 1', 'Design a data model using Entity Framework Code First approach.', 0.20, 100, '2026-06-27'),
(3, 'Entity Framework Assignment 2', 'Implement CRUD operations using Entity Framework.', 0.30, 100, '2026-06-03'),
(3, 'Entity Framework Assignment 3', 'Optimize database interactions using Entity Framework performance techniques.', 0.25, 100, '2026-07-12'),
(3, 'Entity Framework Assignment 4', 'Implement migrations to manage database schema changes.', 0.15, 100, '2026-07-17'),
(3, 'Entity Framework Assignment 5', 'Create a repository pattern implementation using Entity Framework.', 0.10, 100 , '2026-07-22'),
(4, 'Web API Assignment 1', 'Develop a RESTful API using ASP.NET Core.', 0.20, 100, '2026-07-28'),
(4, 'Web API Assignment 2', 'Implement authentication and authorization in a Web API.', 0.10, 100, '2026-06-04'),
(4, 'Web API Assignment 3', 'Create a Web API that interacts with a database using Entity Framework.', 0.25, 100, '2026-07-13'),
(4, 'Web API Assignment 4', 'Implement error handling and logging in a Web API.', 0.15, 100, '2026-07-18'),
(4, 'Web API Assignment 5', 'Document the Web API using Swagger.', 0.10, 100, '2026-07-23'),
(5, 'React Assignment 1', 'Create a React application that displays a list of items from an API.', 0.20, 100, '2026-06-29'),
(5, 'React Assignment 2', 'Implement state management in a React application using Redux.', 0.30, 100, '2026-06-05'),
(5, 'React Assignment 3', 'Develop a React application with routing and navigation.', 0.25, 100, '2026-07-14'),
(5, 'React Assignment 4', 'Create reusable components in a React application.', 0.15, 100, '2026-07-19'),
(5, 'React Assignment 5', 'Implement form validation in a React application.', 0.10, 100, '2026-07-24');
SELECT * FROM Assignments;

----Write SQL Statements to INSERT at least 10 comments for random assignments.
INSERT INTO Comments(AssignmentId, CreatedByUserId, CreatedDate, CommentContent)
VALUES
(1, 1, '2026-06-23', 'Excellent SQL queries'),
(2, 2, '2026-06-24', 'Excellent schema design'),
(3, 3, '2026-06-25', 'Bad performance, optimize it please'),
(4, 4, '2026-06-26', 'Correct implementation'),
(5, 1, '2026-06-27', 'Good backup stratgy'),
(6, 2, '2026-06-28', 'Excellent console app'),
(7, 3, '2026-06-29', 'Correct implementation'),
(8, 4, '2026-06-30', 'Good app'),
(9, 1, '2026-07-01', 'Excellent job'),
(10, 2, '2026-07-02', 'Correct implementation');
SELECT * FROM Comments;

----Write SQL Statement to INSERT random grades for all students for every assignment.
INSERT INTO Grades(AssignmentId, StudentId, Grade)
VALUES 
(2,1,95),
(3,1,90),
(4,1,88),
(5,1,92),
(1,1,100),
(1,2,95),
(1,3,90),
(1,4,85),
(20,1,92),
(2,2,88),
(21,3,91),
(17,4,87),
(13,1,94),
(3,2,89),
(19,3,93),
(24,4,86),
(7,1,90),
(8,2,85),
(9,3,88),
(11,4,82),
(12,1,91),
(5,2,87),
(5,3,89),
(5,4,84);

SELECT * FROM Grades;


----Write a SELECT query to list all courses.
SELECT Courses.CourseName FROM Courses
--or , if you want to also see the details and not only the names :>
SELECT * FROM Courses;

----Write a SELECT query to find all assignments for a specific course.
SELECT * FROM Assignments WHERE CourseId = 2; 

----Write a SELECT query to find all students (users with the role 'Student').
SELECT * FROM Users WHERE Role = 'Student';

----Write an UPDATE statement to change a student's role.
UPDATE Users SET Role = 'Alumni' WHERE UserId = 1;
SELECT * FROM Users WHERE UserId = 1;

----Write a DELETE statement to remove a specific comment. 
DELETE FROM Comments WHERE CommentId = 8;
SELECT * FROM Comments;


----Write a query to list all students along with their grades for a specific course. Users-Grades relationship ? we alson need Assignments (so hard)
UPDATE Users SET Role = 'Student' WHERE UserId = 1;
SELECT Users.FirstName, Users.LastName, Grades.Grade, Assignments.CourseId FROM Users 
    INNER JOIN Grades ON Users.UserId = Grades.StudentId ---link the Users table with the Grades table to get the names and grades 
    INNER JOIN Assignments ON Grades.AssignmentId = Assignments.AssignmentId
WHERE Assignments.CourseId =1;

----Write a query to calculate the average grade for each course. courses-gardes-assignments relationship ? (So hard)
SELECT Courses.CourseName, AVG(Grades.Grade) AS AverageGrade FROM Courses
    INNER JOIN Assignments ON Courses.CourseId = Assignments.CourseId
    INNER JOIN Grades ON Assignments.AssignmentId = Grades.AssignmentId
GROUP BY Courses.CourseName;

----Write a query to list all courses with their respective syllabuses. Courses-Sylabus relationship ?
SELECT Courses.CourseName, Syllabus.Description FROM Courses 
    INNER JOIN Syllabus ON Courses.SyllabusId = Syllabus.SyllabusId; 

----Write a query to find all comments for a specific course. Comments-Assignments relationship ? 
SELECT Comments.CommentContent, Assignments.CourseId FROM comments 
    INNER JOIN Assignments ON Comments.AssignmentId = Assignments.AssignmentId
WHERE Assignments.CourseId = 2;

----Create a stored procedure to add a new student.
CREATE OR ALTER PROCEDURE spAddNewStudent
    @UserName VARCHAR(64),
    @FirstName VARCHAR(64),
    @LastName VARCHAR(64),
    @EmailAddress VARCHAR(128),
    @PhoneNumber VARCHAR(16) 
AS
BEGIN 
   INSERT INTO Users(UserName, FirstName, LastName, EmailAddress, PhoneNumber, Role)
    VALUES (@UserName, @FirstName, @LastName, @EmailAddress, @PhoneNumber, 'Student');
END;

EXEC spAddNewStudent 'Nur123', 'Nur' ,'Hizan', 'Nur.hizan@gmail.com','0542555555' 
SELECT * FROM Users;

----Create a stored procedure to add a new Assignment. Make sure the course assignments weights don’t go above 100.
CREATE OR ALTER PROCEDURE AddNewAssignment
    @CourseId INT,
    @AssignmentTitle VARCHAR(128),
    @Description TEXT,
    @Weight FLOAT,
    @MaxGrade INT,
    @DueDate DATE
AS
BEGIN
DECLARE @TotalWeight FLOAT;
    SELECT @TotalWeight = SUM(Weight) FROM Assignments WHERE CourseId = @CourseId;
    IF (ISNULL(@TotalWeight,0) + @Weight) <= 1.0
    BEGIN
        INSERT INTO Assignments(CourseId, AssignmentTitle, Description, Weight, MaxGrade, DueDate)
        VALUES (@CourseId, @AssignmentTitle, @Description, @Weight, @MaxGrade, @DueDate);
    END
    ELSE
    BEGIN
        PRINT 'ERROR THE TOTAL WEIGHT IS ABOVE %100';
    END
END;

EXEC AddNewAssignment 1, 'SQL Assignment 6', 'Create a database backup strategy.', 0.15, 100, '2026-07-25' ---SHOULD GIVE ERROR
EXEC AddNewAssignment 4, 'Web API Assignment 6', 'Create what is requested', 0.02, 100, '2026-07-25' ---SHOULD WORK
SELECT * FROM Assignments;

----19 Create function to calculate the Student Grade in a Course. Return ‘A', 'B’, etc…  
CREATE OR ALTER FUNCTION CalculateStudentGrade(@StudentId INT,@CourseId INT)
RETURNS CHAR(1)
AS
BEGIN
    DECLARE @LetterGrade CHAR(1);
    DECLARE @Result FLOAT;
    SELECT @Result =
    ISNULL(SUM((CAST(G.Grade AS FLOAT) / A.MaxGrade) * A.Weight), 0)
    FROM Grades G INNER JOIN Assignments A ON G.AssignmentId = A.AssignmentId
    WHERE A.CourseId = @CourseId AND G.StudentId = @StudentId;

    IF @Result >= 0.80
        SET @LetterGrade = 'A';
    ELSE IF @Result >= 0.70
        SET @LetterGrade = 'B';
    ELSE IF @Result >= 0.60
        SET @LetterGrade = 'C';
    ELSE IF @Result >= 0.50
        SET @LetterGrade = 'D';
    ELSE
        SET @LetterGrade = 'F';

    RETURN @LetterGrade;
END;

SELECT dbo.CalculateStudentGrade(4,4) AS LetterGrade; 

SELECT SUM((CAST(G.Grade AS FLOAT) / A.MaxGrade) * A.Weight) 
FROM Grades G
INNER JOIN Assignments A
    ON G.AssignmentId = A.AssignmentId
WHERE A.CourseId = 4
    AND G.StudentId = 4;

----20 Create a function to calculate the GPA of a student. 
CREATE OR ALTER FUNCTION CalculateStudentGPA(@StudentId INT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @GPA FLOAT;

    SELECT @GPA =
        ISNULL(
            SUM(
                CASE dbo.CalculateStudentGrade(@StudentId, CourseId)
                    WHEN 'A' THEN 4.0
                    WHEN 'B' THEN 3.0
                    WHEN 'C' THEN 2.0
                    WHEN 'D' THEN 1.0
                    ELSE 0.0
                END
            ) / COUNT(*),0)
    FROM(
        SELECT DISTINCT A.CourseId
        FROM Grades G
        INNER JOIN Assignments A
            ON G.AssignmentId = A.AssignmentId
        WHERE G.StudentId = @StudentId ) AS StudentCourses;

    RETURN @GPA;
END;
SELECT dbo.CalculateStudentGPA(4) AS GPA;
GO