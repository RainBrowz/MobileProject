using MobileProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProject.DataTransactions
{
    public class DBTrans
    {
        public string dbPath;
        private SQLiteConnection conn;

        public DBTrans(string _dbPath)
        { this.dbPath = _dbPath; }

        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<StudentClass>();
        }
    }
    public List<StudentClass> GetAllStudents()
    {
        Init();
        return conn.Table<StudentClass>().ToList();
    }
    public void Add(StudentClass student)
    {
        conn = new SQLiteConnection(this.dbPath);
        conn.Insert(student);
    }

    public void Delete(int student_ID)
    {
        conn = new SQLiteConnection(this.dbPath);
        conn.Delete(new StudentClass { Id = student_ID });
    }
}