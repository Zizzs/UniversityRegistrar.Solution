using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers
{
    public class UniversityController : Controller
    {
        [HttpGet("/university/newstudent")]
        public ActionResult Student()
        {
            List<StudentClass> allStudents = StudentClass.GetAll();
            return View("NewStudent", allStudents);
        }

        [HttpPost("/university/newstudent")]
        public ActionResult NewStudent(string name, string date)
        {
            StudentClass student = new StudentClass(name, date);
            student.Save();
            return RedirectToAction("Student");
        }

        [HttpGet("/university/newcourse")]
        public ActionResult Course()
        {
            List<CourseClass> allCourses = CourseClass.GetAll();

            return View("NewCourse", allCourses);
        }


        [HttpPost("/university/newcourse")]
        public ActionResult NewCourse(string name, string code)
        {
            CourseClass course = new CourseClass(name, code);
            course.Save();
            return RedirectToAction("Course");
        }

        [HttpGet("/university/newdepartment")]
        public ActionResult Department()
        {
            List<DepartmentClass> departments = DepartmentClass.GetAll();
            return View("NewDepartment", departments);
        }

        [HttpPost("/university/newdepartment")]
        public ActionResult NewDepartment(string name)
        {
            DepartmentClass department = new DepartmentClass(name);
            department.Save();
            return RedirectToAction("Department");
        }

        [HttpGet("/university/assign")]
        public ActionResult Assign()
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<StudentClass> students = StudentClass.GetAll();
            List<CourseClass> courses = CourseClass.GetAll();
            allInfo.Add("students", students);
            allInfo.Add("courses" , courses);
            return View(allInfo);
        }


        [HttpPost("/university/assign")]
        public ActionResult NewAssign(int student, int course)
        {
            JoinTableClass join = new JoinTableClass(student, course);
            join.Save();
            return RedirectToAction("Assign");
        }

        [HttpGet("/university/assignstudents")]
        public ActionResult AssignStudents()
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<StudentClass> students = StudentClass.GetAll();
            List<DepartmentClass> departments = DepartmentClass.GetAll();
            allInfo.Add("students", students);
            allInfo.Add("departments" , departments);
            return View(allInfo);
        }

        [HttpPost("/university/assignstudents")]
        public ActionResult NewAssignStudents(int student, int department)
        {
            JoinStudentDepartmentClass join = new JoinStudentDepartmentClass(student, department);
            join.Save();
            return RedirectToAction("AssignStudents");
        }
       [HttpGet("/university/assigncourses")]
        public ActionResult AssignCourses()
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<CourseClass> courses = CourseClass.GetAll();
            List<DepartmentClass> departments = DepartmentClass.GetAll();
            allInfo.Add("courses", courses);
            allInfo.Add("departments" , departments);
            return View(allInfo);
        }

        [HttpPost("/university/assigncourses")]
        public ActionResult NewAssignCourses(int course, int department)
        {
            JoinCourseDepartmentClass join = new JoinCourseDepartmentClass(course, department);
            join.Save();
            return RedirectToAction("Assigncourses");
        }

        [HttpGet("/university/student/{id}")]
        public ActionResult ShowStudent(int id)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<StudentClass> student = StudentClass.FindById(id);
            List<CourseClass> courses = JoinTableClass.GetCoursesByStudentId(id);
            allInfo.Add("student", student);
            allInfo.Add("courses", courses);
            return View("ShowStudent", allInfo);
        }

        [HttpGet("/university/course/{id}")]
        public ActionResult ShowCourse(int id)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<StudentClass> students = JoinTableClass.GetStudentsByCourseId(id);
            List<CourseClass> course = CourseClass.FindById(id);
            allInfo.Add("students", students);
            allInfo.Add("course", course);
            return View("ShowCourse", allInfo);
        }

        [HttpGet("/university/department/{id}")]
        public ActionResult ShowDepartment(int id)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<DepartmentClass> department = DepartmentClass.FindById(id);
            List<StudentClass> students = JoinStudentDepartmentClass.GetStudentsByDepartmentId(id);
            List<CourseClass> courses = JoinCourseDepartmentClass.GetCoursesByDepartmentId(id);
            allInfo.Add("students", students);
            allInfo.Add("courses", courses);
            allInfo.Add("department", department);
            return View("ShowDepartment", allInfo);
        }
    }
}
