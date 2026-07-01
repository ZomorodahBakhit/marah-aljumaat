using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using University.Core.DTOs;
using University.Core.Exceptions;
using University.Core.Forms;
using University.Core.Validations;
using University.Data.Entities;
using University.Data.Repositories;

namespace University.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repository, ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public List<StudentDto> GetAll()
        {
            _logger.LogInformation("Attempting to retrieve all students");
                var studentsDto = _repository.GetAll()
                    .Select(s => new StudentDto { StudentId = s.StudentId, StudentName = s.StudentName }).ToList();

                if (!studentsDto.Any())
                {
                    _logger.LogWarning("No students found in the database");
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved {Count} students", studentsDto.Count);
                }

                return studentsDto;
        }

        public StudentDto? GetById(int id)
        {

            _logger.LogInformation("Attempting to retrieve student by ID: {id}", id);

                var student = _repository.GetById(id);

                if (student == null)
                {
                    _logger.LogWarning("Student with ID: {Id} not found", id);
                    throw new NotFoundException($"Student with ID {id} not found");
                }

                _logger.LogInformation("Successfully retrieved student with ID: {Id}, Name: {Name}", id, student.StudentName);

                return new StudentDto
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName
                };
        }
           
        public void Create(CreateStudentForm form)
        {

            _logger.LogInformation("Attempting to create new student with Name: {Name}, Email: {Email}",form.Name, form.Email);

                var validationResult = FormValidator.Validate(form);

                if (!validationResult.IsValid)
                {
                    _logger.LogWarning("Validation failed for student creation. Errors: {Errors}",
                        string.Join(", ", validationResult.Errors.SelectMany(e => e.Value)));

                    throw new BusinessException(validationResult.Errors);
                }
                if (IsEmailDuplicate(form.Email))
                {
                    _logger.LogWarning("Duplicate email detected during student creation: {Email}", form.Email);

                    throw new BusinessException(new Dictionary<string, List<string>>{
                        { nameof(form.Email), new List<string> { $"Email '{form.Email}' is already in use." } }
                    });
                }
                var student = new Student
                {
                    StudentName = form.Name,
                    StudentEmail = form.Email
                };
                _repository.Add(student);
                _logger.LogInformation("Successfully created student with ID: {Id}, Name: {Name}, Email: {Email}",
                   student.StudentId, student.StudentName, student.StudentEmail);
        }
            
        public void Update(int id, UpdateStudentForm form)
        {

            _logger.LogInformation("Attempting to update student with ID: {Id} with Name: {Name}, Email: {Email}",
              id, form.Name, form.Email);

                var validationResult = FormValidator.Validate(form);

                if (!validationResult.IsValid)
                {
                    _logger.LogWarning("Validation failed for student update. Errors: {Errors}",
                        string.Join(", ", validationResult.Errors.SelectMany(e => e.Value)));

                    throw new BusinessException(validationResult.Errors);
                }

                var student = _repository.GetById(id);
                if (student == null)
                {
                    _logger.LogWarning("Student with ID: {Id} not found for update", id);
                    throw new NotFoundException($"Student with ID {id} not found for updating");
                }

                if (IsEmailDuplicate(form.Email, StudentId: id))
                {
                    _logger.LogWarning("Duplicate email detected during student update. ID: {Id}, Email: {Email}", id, form.Email);

                    throw new BusinessException($"Email '{form.Email}' is already in use.");
                }

            var PreviousName = student.StudentName;
                var PreviousEmail = student.StudentEmail;

                student.StudentName = form.Name;
                student.StudentEmail = form.Email;

                _repository.Update(student);
                _logger.LogInformation("Successfully updated student with ID: {Id}. Previous values: Name: {PreviousName}, Email: {PreviousEmail}. New values: Name: {NewName}, Email: {NewEmail}",
                id, PreviousName, PreviousEmail, student.StudentName, student.StudentEmail);

        }
          
        
        public void Delete(int id)
        {
            _logger.LogInformation("Attempting to delete student with Id: {id}", id);
                var student = _repository.GetById(id);
                if (student == null)
                {
                    _logger.LogWarning("Student with ID: {Id} not found", id);
                    throw new NotFoundException($"Student with ID {id} not found for deletion");
                }
                _repository.Delete(id);
                _logger.LogInformation("Successfully deleted student with ID: {Id}, Name: {Name}", id, student.StudentName);

        }
        private bool IsEmailDuplicate(string email, int? StudentId = null)
        {
            return _repository.GetAll()
                .Any(s => s.StudentEmail.Equals(email, StringComparison.OrdinalIgnoreCase)
                          && (!StudentId.HasValue || s.StudentId != StudentId.Value));
        }

    }
}
    