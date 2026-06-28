using System;
using System.Collections.Generic;
using System.Text;
using University.Core.DTOs;
using University.Core.Forms;
using University.Data.Entities;
using University.Data.Repositories;

namespace University.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repository)
        {
            _repo = repository;
        }

        public StudentDto? GetById(int StudentId)
        {
            var student = _repo.GetById(StudentId);
            if (student == null) return null;
            return new StudentDto
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName
            };
        }

        public List<StudentDto> GetAll()
        {
            return _repo.GetAll()
                .Select(s => new StudentDto { StudentId = s.StudentId, StudentName = s.StudentName })
                .ToList();
        }

        public void Create(CreateStudentForm form)
        {
            var student = new Student
            {
                StudentName = form.Name,
                StudentEmail = form.Email
            };
            _repo.Add(student);
        }

        public void Update(int StudentId, UpdateStudentForm form)
        {
            var student = _repo.GetById(StudentId);
            if (student == null) return;
            student.StudentName = form.Name;
            student.StudentEmail = form.Email;
            _repo.Update(student);
        }

        public void Delete(int StudentId)
        {
            _repo.Delete(StudentId);
        }
    }
}
