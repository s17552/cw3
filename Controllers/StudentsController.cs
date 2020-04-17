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
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_dbService.GetStudents());
        }
        
        [HttpGet("{studentId}")]
        public IActionResult getSelectedStudent(string studentId)
        {
            List<Student> students = _dbService.GetStudents();
            Console.WriteLine("'" + studentId + "'");
            Student queryingStudent = students.Find(student => student.IndexNumber == studentId);

            if (queryingStudent != null)
            {
                return Ok(queryingStudent);
            }
            return NotFound("Nie znaleziono studenta");

        }

        /*
        [HttpGet]
        public string GetStudents(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");

        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult TestPut(int id)
        {
            if (id == 1)
            {
                return Ok("Sukcess");
            }
            return NotFound("Error");
        }
        [HttpDelete("{id}")]
        public IActionResult TestDelete(int id)
        {
            if (id == 1)
            {
                return Ok("Sukcess");
            }
            return NotFound("Error");
        }
    */
    }
}