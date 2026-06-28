using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using University.Core.Forms;
using University.Core.Services;

using University.Data.Repositories;

namespace University.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService studentService)
        {
            _service = studentService;

        }
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            var student = _service.GetById(id);
            return new ApiResponse(student);
        }
        [HttpGet]
        public ApiResponse GetAll()
        {
            return new ApiResponse(_service.GetAll());
        }
        [HttpPost]
        public ApiResponse Create([FromBody] CreateStudentForm form)
        {
            _service.Create(form);
            return new ApiResponse("Student created successfully");
        }
        [HttpPut("{id}")]
        public ApiResponse Update(int id, [FromBody] UpdateStudentForm form)
        {
            _service.Update(id, form);
            return new ApiResponse("Student updated successfully");
        }
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            _service.Delete(id);
            return new ApiResponse("Student deleted successfully");
        }
    }
}