using System;
using System.Collections.Generic;
using System.Text;
using University.Data.Entities;

namespace University.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        //to access the DbContext - DI 
        private readonly UniversityDbContext dbContext;

        //constructor 
        public StudentRepository(UniversityDbContext context)
        {
            dbContext = context;
        }
        //Get one student by id
        public Student? GetById(int StudentId) => dbContext.Students.Find(StudentId);
        //Get all students
        public List<Student> GetAll() => dbContext.Students.ToList();
        //Add a new student
        public void Add(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }
        //Update a student
        public void Update(Student student)
        {
            dbContext.Students.Update(student);
            dbContext.SaveChanges();
        }
        //Delete a student
        public void Delete(int StudentId)
        {
            var student = dbContext.Students.Find(StudentId);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                dbContext.SaveChanges();
            }
        }
    }
}
