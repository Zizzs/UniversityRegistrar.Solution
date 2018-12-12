using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UniversityRegistrar;

namespace UniversityRegistrar.Models
{
    public class DepartmentClass
    {
        private int _id;
        private string _name;

        public DepartmentClass(string name,int id=0)
        {
            _id = id;
            _name = name;
        }
        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO departments (name) VALUES (@name);";
            cmd.Parameters.AddWithValue("@name", this._name);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<DepartmentClass> GetAll()
        {
            List<DepartmentClass> allDepartments = new List<DepartmentClass>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM departments;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                DepartmentClass newDepartment = new DepartmentClass(name, id);
                allDepartments.Add(newDepartment);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allDepartments;
        }

        public static List<DepartmentClass> FindById(int id)
        {
            List<DepartmentClass> currentDepartment = new List<DepartmentClass>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM departments WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int idz = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                DepartmentClass newDepartment = new DepartmentClass(name, idz);
                currentDepartment.Add(newDepartment);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return currentDepartment;
        }
    }
    public class JoinStudentDepartmentClass{
        private int _id;
        private int _student_id;
        private int _department_id;

        public JoinStudentDepartmentClass(int student_id, int department_id, int id=0)
        {
            _student_id = student_id;
            _department_id = department_id;
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

        public int GetDepartmentId()
        {
            return _department_id;
        }
        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO department_students(student_id, department_id) VALUES (@student, @department);";
            cmd.Parameters.AddWithValue("@student", this._student_id);
            cmd.Parameters.AddWithValue("@department", this._department_id);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        
        public static List<StudentClass> GetStudentsByDepartmentId(int departmentId)
        {
            
            List<StudentClass> allStudents = new List<StudentClass>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT students.* FROM
                students JOIN department_students ON (students.id = department_students.student_id)
                    JOIN departments ON (department_students.department_id = departments.id)
                WHERE departments.id = " + departmentId + ";";

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
    public class JoinCourseDepartmentClass
    {
        private int _id;
        private int _course_id;
        private int _department_id;

        public JoinCourseDepartmentClass(int course_id, int department_id, int id=0)
        {
            _course_id = course_id;
            _department_id = department_id;
            _id = id;
        }
        public int GetId()
        {
            return _id;
        }

        public int GetCourseId()
        {
            return _course_id;
        }

        public int GetDepartmentId()
        {
            return _department_id;
        }
        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO department_courses(course_id, department_id) VALUES (@course, @department);";
            cmd.Parameters.AddWithValue("@course", this._course_id);
            cmd.Parameters.AddWithValue("@department", this._department_id);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<CourseClass> GetCoursesByDepartmentId(int departmentId)
        {
            
            List<CourseClass> allCourses = new List<CourseClass>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT courses.* FROM
                courses JOIN department_courses ON (courses.id = department_courses.Course_id)
                    JOIN departments ON (department_courses.department_id = departments.id)
                WHERE departments.id = " + departmentId + ";";

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
    public class JoinTableClass
    {
        private int _id;
        private int _student_id;
        private int _course_id;
        private int _department_id;
        private int _status;

        public JoinTableClass(int student_id, int course_id, int id=0)
        {
            _student_id = student_id;
            _course_id = course_id;
            _id = id;
        }

        public JoinTableClass(int student_id, int course_id, int status, int id=0)
        {
            _student_id = student_id;
            _course_id = course_id;
            _status = status;
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

        public int GetStatus()
        {
            return _status;
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

        public static List<StudentClass> GetStudentsByCourseId(int courseId)
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

        public static bool FindStatusByStudentAndCourseId(int student_id, int course_id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT status FROM students_courses WHERE student_id = " + student_id + " AND course_id = " + course_id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            bool status = false;
            while(rdr.Read())
            {
                if (rdr.GetBoolean(0) == false)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return status;
        }

        public static void UpdatePassing(int student_id, int course_id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE students_courses SET status = true WHERE student_id = " + student_id + " AND course_id = " + course_id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void UpdateFailing(int student_id, int course_id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE students_courses SET status = false WHERE student_id = " + student_id + " AND course_id = " + course_id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
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
