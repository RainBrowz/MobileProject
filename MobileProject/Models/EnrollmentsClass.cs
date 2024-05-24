using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProject.Models
{
    public class EnrollmentsClass
    {
        [PrimaryKey, AutoIncrement]
        public int EnrId { get; set; }
        public int StudentId { get; set; } // Assuming this is the foreign key referencing students
        public string StudentName { get; set; } // Assuming this is the foreign key referencing students
        public int CourseId { get; set; } // Assuming this is the foreign key referencing courses
        public DateTime EnrollmentDate { get; set; }
    }
}
