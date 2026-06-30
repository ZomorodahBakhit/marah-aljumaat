using System;
using System.Collections.Generic;
using System.Text;
using University.Data.Entities;
using University.Data.Migrations;

namespace University.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext dbContext;
        public CourseRepository(UniversityDbContext context)
        {
            dbContext = context;
        }
        public Course? GetById(int CourseId) => dbContext.Courses.Find(CourseId);
        public List<Course> GetAll() => dbContext.Courses.ToList();
        public void Add(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
        }
        public void Update(Course course)
        {
            dbContext.Courses.Update(course);
            dbContext.SaveChanges();
        }
        public void Delete(int CourseId)
        {
            var course = dbContext.Courses.Find(CourseId);
            if (course != null)
            {
                dbContext.Courses.Remove(course);
                dbContext.SaveChanges();
            }
        }
    }
    public interface ICourseRepository
    {
        Course? GetById(int CourseId);
        List<Course> GetAll();
        void Add(Course course);
        void Update(Course course);
        void Delete(int CourseId);
    }
}
