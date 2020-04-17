namespace Cw3.Models
{
    public class Enrollment
    {
        public int IdEnrollment { get; set; }

        public string Semester { get; set; }

        public string IdStudy { get; set; }

        public string StartDate { get; set; }
        
        public override string ToString()
        {
            return IdEnrollment + " " + Semester + " " +  IdStudy + " " + StartDate;
        }

    }
}