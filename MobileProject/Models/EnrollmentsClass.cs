using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProject.Models
{
    internal class EnrollmentsClass
    {
        [PrimaryKey, AutoIncrement]
        public int EnrId { get; set; }
    }
}
