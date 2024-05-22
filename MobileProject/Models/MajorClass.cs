using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProject.Models
{
    public class MajorClass
    {
        [PrimaryKey, AutoIncrement]
        public int majId { get; set; }
        public string majName { get; set; }
    }
}
