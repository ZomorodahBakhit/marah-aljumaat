using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using University.Api.Filters;
using University.Core.Exceptions;
using University.Core.Forms;
using University.Core.Services;

namespace University.API.Controllers
{
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        public CourseController(ICourseService courseService)
        {
            _service = courseService;

        }
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            var course = _service.GetById(id);
            return new ApiResponse(course);
        }
        [HttpGet]
        public ApiResponse GetAll()
        {
            return new ApiResponse(_service.GetAll());
        }
        [HttpPost]
        public ApiResponse Create([FromBody] CreateCourseFrom form)
        {
            _service.Create(form);
            return new ApiResponse("Course created successfully");
        }
        [HttpPut("{id}")]
        public ApiResponse Update(int id, [FromBody] CreateCourseFrom form)
        {
            _service.Update(id, form);
            return new ApiResponse("Corse updated successfully");
        }
       
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var course = _service.GetById(id);
            if (course == null)
                throw new NotFoundException($"Course with id {id} not found");

            _service.Delete(id);
            return new ApiResponse();
        }
    }
}
