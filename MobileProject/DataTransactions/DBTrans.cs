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
        public void DeleteStudent(int DeleteStudent)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new StudentClass { Id = DeleteStudent });
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
        public void DeleteCourse(int DeleteCourse)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new CoursesClass { CouId = DeleteCourse });
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
        public void DeleteMajor(int DeleteMajor)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new MajorClass { majId = DeleteMajor });
        }

        public List<EnrollmentsClass> GetAllEnrollments()
        {
            Init();
            return conn.Table<EnrollmentsClass>().ToList();
        }
        public void AddEnrollments(EnrollmentsClass Enrollments)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(Enrollments);
        }
        public void DeleteEnrollments(int DeleteEnroll)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new EnrollmentsClass { EnrId = DeleteEnroll });
        }


    }
}
