using System;
using System.Collections.Generic;
using System.Text;
using University.Core.DTOs;
using University.Core.Forms;

namespace University.Core.Services
{
    public interface IStudentService
    {
        StudentDto? GetById(int StudentId);
        List<StudentDto> GetAll();
        void Create(CreateStudentForm form);
        void Update(int StudentId, UpdateStudentForm form);
        void Delete(int StudentId);
    }
}
