using System;
using System.Collections.Generic;
using System.Text;
using University.Data.Entities;

namespace University.Data.Repositories
{
    public interface IStudentRepository
    {
        Student? GetById(int StudentId);
        //we used list becuse we want to return multiple students
        List<Student> GetAll();
        //function type is void because we don't want to return anything
        //parameter is student because we want to add a student to the database
        void Add(Student student);
        void Update(Student student);
        void Delete(int StudentId);
    }
}
