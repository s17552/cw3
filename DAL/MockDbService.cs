using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Cw3.Models;
using Microsoft.VisualBasic.CompilerServices;

namespace Cw3.DAL
{
    public class MockDbService : IDbService
    {
        private static List<Student> _students;
        private static List<Enrollment> _enrollments;
        private const string ConnectionString = "Data Source=db-mssql;Initial Catalog=s17552;Integrated Security=True";

        static MockDbService()
        {
            fetchAllStudents();
            fetchAllEnrollments();
        }


        public List<Student> GetStudents()
        {
            return _students;
        }

        public List<Enrollment> GetEnrollments()
        {
            return _enrollments;
        }

        public List<Enrollment> fetchEnrollmentsForStudent(string studentId)
        {
            List<Enrollment> enrollmentsForStudent = new List<Enrollment>();
            using (var connection = new SqlConnection(ConnectionString))
            using (var com = new SqlCommand())
            {
                com.Connection = connection;
                com.CommandText = 
                    "SELECT * " +
                    "FROM Enrollment " +
                    "JOIN Student S on S.IdEnrollment = Enrollment.IdEnrollment " +
                    "WHERE S.IndexNumber = @studentId";
                com.Parameters.AddWithValue("studentId", studentId);
                connection.Open();
                var dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var enrollment = new Enrollment();
                    enrollment.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                    enrollment.Semester = dr["Semester"].ToString();
                    enrollment.IdStudy = dr["IdStudy"].ToString();
                    enrollment.StartDate = dr["StartDate"].ToString();
                    enrollmentsForStudent.Add(enrollment);

                    Console.WriteLine("3222 "+enrollmentsForStudent.Count());
                }

                return enrollmentsForStudent;
            }
        }

        public static void fetchAllStudents()
        {
            _students = new List<Student>();
            using (var connection = new SqlConnection(ConnectionString))
            using (var com = new SqlCommand())
            {
                com.Connection = connection;
                com.CommandText = "SELECT * FROM Student";
                connection.Open();
                var dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var student = new Student();
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.IndexNumber = dr["IndexNumber"].ToString();
                    student.IdStudent = Int32.Parse(dr["IndexNumber"].ToString());
                    _students.Add(student);
                }
            }
        }

        private static void fetchAllEnrollments()
        {
            _enrollments = new List<Enrollment>();
            using (var connection = new SqlConnection(ConnectionString))
            using (var com = new SqlCommand())
            {
                com.Connection = connection;
                com.CommandText = "SELECT * FROM Enrollment";
                connection.Open();
                var dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var enrollment = new Enrollment();
                    enrollment.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                    enrollment.Semester = dr["Semester"].ToString();
                    enrollment.IdStudy = dr["IdStudy"].ToString();
                    enrollment.StartDate = dr["StartDate"].ToString();
                    _enrollments.Add(enrollment);

                    Console.WriteLine(_enrollments.Count());
                }
            }
        }
    }
}