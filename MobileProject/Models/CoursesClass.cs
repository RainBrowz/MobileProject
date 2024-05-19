using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProject.Models
{
    public class CoursesClass
    {
        [PrimaryKey, AutoIncrement]
        public int CouId { get; set; }
        public string CourseName { get; set; }
    }
}
