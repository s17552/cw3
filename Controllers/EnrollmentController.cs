using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;
namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/Enrollments")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IDbService _dbService;

        public EnrollmentController(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            return Ok(_dbService.GetEnrollments());
        }
        
        [HttpGet("{studentId}")]
        public IActionResult GetStudentEnrollment(string studentId)
        {
            List<Student> students = _dbService.GetStudents();
            
            Student queryingStudent = students.Find(student => student.IndexNumber == studentId);

            if (queryingStudent != null)
            {
                return Ok(_dbService.fetchEnrollmentsForStudent(studentId));
            }
            return NotFound("Nie znaleziono studenta");

        }

    }
}