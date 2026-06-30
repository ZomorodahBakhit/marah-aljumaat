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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly ILogger<CourseService> _logger;

        public CourseService(ICourseRepository repository, ILogger<CourseService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public CourseDto? GetById(int id)
        {

            _logger.LogInformation("Attempting to retrieve course by ID: {id}", id);

            try
            {
                var course = _repository.GetById(id);

                if (course == null)
                {
                    _logger.LogWarning("Course with ID: {Id} not found", id);
                    throw new NotFoundException($"Course with ID {id} not found");
                }

                _logger.LogInformation("Successfully retrieved Course with ID: {Id}, Name: {Name}", id, course.CourseName);

                return new CourseDto
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName
                };

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred while retrieving course with ID: {Id}", id);
                throw;
            }
        }

        public List<CourseDto> GetAll()
        {

            _logger.LogInformation("Attempting to retrieve all courses");

            try
            {
                var coursesDto = _repository.GetAll()
                    .Select(x => new CourseDto { CourseId = x.CourseId, CourseName = x.CourseName, StartDate = x.StartDate, EndDate = x.EndDate }).ToList();

                if (!coursesDto.Any())
                {
                    _logger.LogWarning("No courses found");
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved {Count} courses", coursesDto.Count);
                }

                return coursesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all courses");
                throw;
            }
        }

        public void Create(CreateCourseFrom form)
        {

            _logger.LogInformation("Attempting to create new course with Name: {Name}",
            form.CourseName);

            try
            {
                var validationResult = FormValidator.Validate(form);

                if (!validationResult.IsValid)
                {
                    _logger.LogWarning("Validation failed for course creation. Errors: {Errors}",
                        string.Join(", ", validationResult.Errors.SelectMany(e => e.Value)));

                    throw new BusinessException(validationResult.Errors);
                }
     
                var course = new Course
                {
                    CourseName = form.CourseName,
                    StartDate = form.StartDate,
                    EndDate = form.EndDate

                };

                _repository.Add(course);
                _logger.LogInformation("Successfully created course with ID: {Id}, Name: {Name}",
                   course.CourseId, course.CourseName);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error occurred while creating course with Name: {Name}",
                        form.CourseName);
                throw;
            }

        }

        public void Update(int id, CreateCourseFrom form)
        {
            _logger.LogInformation("Attempting to update course with ID: {Id} with Name: {Name}",
              id, form.CourseName);

            try
            {
                var validationResult = FormValidator.Validate(form);

                if (!validationResult.IsValid)
                {
                    _logger.LogWarning("Validation failed for course update. Errors: {Errors}",
                        string.Join(", ", validationResult.Errors.SelectMany(e => e.Value)));

                    throw new BusinessException(validationResult.Errors);
                }

                var course = _repository.GetById(id);
                if (course == null)
                {
                    _logger.LogWarning("course with ID: {Id} not found for update", id);
                    throw new NotFoundException($"course with ID {id} not found for updating");
                }

                var PreviousName = course.CourseName;

                course.CourseName = form.CourseName;
               
                _repository.Update(course);
                _logger.LogInformation("Successfully updated course with ID: {Id}. Previous values: Name: {PreviousName}. New values: Name: {NewName}",
                id, PreviousName, course.CourseName);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating course with ID: {Id}", id);
                throw;
            }
        }

        public void Delete(int id)
        {
            _logger.LogInformation("Attempting to delete course with Id: {id}", id);
            try
            {
                var course = _repository.GetById(id);
                if (course == null)
                {
                    _logger.LogWarning("course with ID: {Id} not found", id);
                    throw new NotFoundException($"course with ID {id} not found for deletion");
                }
                _repository.Delete(id);
                _logger.LogInformation("Successfully deleted course with ID: {Id}, Name: {Name}", id, course.CourseName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting course with ID: {Id}", id);
                throw;
            }

        }
    }

    public interface ICourseService
    {
        CourseDto? GetById(int CourseId);
        List<CourseDto> GetAll();
        void Create(CreateCourseFrom form);
        void Update(int CourseId, CreateCourseFrom form);
        void Delete(int CourseId);
    }
}
