using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversityRegistrar;

namespace UniversityRegistrar.Models
{
    public class JoinTableClass
    {
        private int _id;
        private int _student_id;
        private int _course_id;

        public JoinTableClass(int student_id, int course_id, int id=0)
        {
            _student_id = student_id;
            _course_id = course_id;
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetStudentId()
        {
            return _student_id;
        }

        public int GetCourseId()
        {
            return _course_id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO students_courses(student_id, course_id) VALUES (@student, @course);";
            cmd.Parameters.AddWithValue("@student", this._student_id);
            cmd.Parameters.AddWithValue("@course", this._course_id);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public static List<CourseClass> GetCoursesByStudentId(int studentId)
        {
            {
                List<CourseClass> allCourses = new List<CourseClass>{};
                MySqlConnection conn = DB.Connection();
                conn.Open();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT courses.* FROM
                    courses JOIN students_courses ON (courses.id = students_courses.course_id)
                        JOIN students ON (students_courses.student_id = students.id)
                    WHERE students.id = " + studentId + ";";

                MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
                while(rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string name = rdr.GetString(1);
                    string code = rdr.GetString(2);
                    CourseClass newCourse = new CourseClass(name, code, id);
                    allCourses.Add(newCourse);
                }
                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
                return allCourses;
            }
        }

        public static List<StudentClass> GetStudentsByCourseId(int courseId)
        {
            {
                List<StudentClass> allStudents = new List<StudentClass>{};
                MySqlConnection conn = DB.Connection();
                conn.Open();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT students.* FROM
                    students JOIN students_courses ON (students.id = students_courses.student_id)
                        JOIN courses ON (students_courses.course_id = courses.id)
                    WHERE courses.id = " + courseId + ";";

                MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
                while(rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string name = rdr.GetString(1);
                    DateTime date = (DateTime) rdr.GetDateTime(2);
                    StudentClass newStudent = new StudentClass(name, date.ToString("MM/dd/yyyy"), id);
                    allStudents.Add(newStudent);
                }
                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
                return allStudents;
            }
        }
    }
    public class StudentClass
    {
        private int _id;
        private string _name;
        private string _date;

        public StudentClass(string name, string date, int id=0)
        {
            _name = name;
            _date = date;
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDate()
        {
            return _date;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO students(name, date) VALUES (@name, @date);";
            cmd.Parameters.AddWithValue("@name", this._name);
            cmd.Parameters.AddWithValue("@date", this._date);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<StudentClass> GetAll()
        {
            List<StudentClass> allStudents = new List<StudentClass>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM students;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                DateTime date = (DateTime) rdr.GetDateTime(2);
                StudentClass newStudent = new StudentClass(name, date.ToString("MM/dd/yyyy"), id);
                allStudents.Add(newStudent);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStudents;
        }

        public static List<StudentClass> FindById(int id)
        {
            List<StudentClass> currentStudent = new List<StudentClass>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM students WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int idz = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                DateTime date = (DateTime) rdr.GetDateTime(2);
                StudentClass newStudent = new StudentClass(name, date.ToString("MM/dd/yyyy"), idz);
                currentStudent.Add(newStudent);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return currentStudent;
        }
    }

    public class CourseClass
    {
        private int _id;
        private string _name;
        private string _code;

        public CourseClass(string name, string code, int id=0)
        {
            _name = name;
            _code = code;
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetCode()
        {
            return _code;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO courses(name, code) VALUES (@name, @code);";
            cmd.Parameters.AddWithValue("@name", this._name);
            cmd.Parameters.AddWithValue("@code", this._code);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<CourseClass> FindById(int id)
        {
            List<CourseClass> currentCourse = new List<CourseClass>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM courses WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int idz = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string code = rdr.GetString(2);
                CourseClass newCourse = new CourseClass(name, code, idz);
                currentCourse.Add(newCourse);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return currentCourse;
        }

        public static List<CourseClass> GetAll()
        {
            List<CourseClass> allCourses = new List<CourseClass>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM courses;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string code = rdr.GetString(2);
                CourseClass newCourse = new CourseClass(name, code, id);
                allCourses.Add(newCourse);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCourses;
        }
    }
}
