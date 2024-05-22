using MobileProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileProject.DataTransactions
{
    public class DBTrans
    {
        public string dbPath;
        private SQLiteConnection conn;
        public DBTrans(string _dbPath)
        {
            this.dbPath = _dbPath;
        }
        private void Init()
        {
                    conn = new SQLiteConnection(this.dbPath);
                    conn.CreateTable<StudentClass>();
                    conn.CreateTable<CoursesClass>();
                    conn.CreateTable<MajorClass>();
                    conn.CreateTable<EnrollmentsClass>();
        }
        public List<StudentClass> GetAllStudents()
        {
                Init();
                return conn.Table<StudentClass>().ToList();
        }
        public void AddStudent(StudentClass student)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(student);
        }
        public void DeleteStudent(int student_ID)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new StudentClass { Id = student_ID });
        }
        public List<CoursesClass> GetAllCourses()
        {
                Init();
                return conn.Table<CoursesClass>().ToList();
        }
        public void AddCourse(CoursesClass course)
        {
                conn = new SQLiteConnection(this.dbPath);
                conn.Insert(course);
        }
        public void DeleteCourse(int course_ID)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new CoursesClass { CouId = course_ID });
        }
        public List<MajorClass> GetAllMajor()
        {
            Init();
            return conn.Table<MajorClass>().ToList();
        }
        public void AddMajor(MajorClass Major)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(Major);
        }
        public void DeleteMajor(int majorid)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new MajorClass { majId = majorid });
        }


    }
}
