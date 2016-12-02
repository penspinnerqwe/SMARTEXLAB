using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartLabApp.Models;
using System.Data;


namespace SmartLabApp.Controllers
{
    public class TaskController : ApiController
    {
        ScheduleModelContainer1 db = new ScheduleModelContainer1();

        [Route("api/Allteacherscourses")]
        //All teachers with their courses	
        public Object GetTeachersCourse()
        {
            var result = from CourseTmp in db.CourseSet
                         join TeacherTmp in db.TeacherSet on CourseTmp.TeacherId equals TeacherTmp.TeacherId
                         select new { TeacherLastName = TeacherTmp.LastName, CourseName = CourseTmp.CourseName };

            return result;
        }
        [Route("api/Allstudentscourses")]
        //All students with their courses	
        public Object GetStudentsCurses()
        {
            var result = from StCrTmp in db.StudentsCourseSet
                         join CrTmp in db.CourseSet on StCrTmp.CourseId equals CrTmp.CourseId into TempDB
                         from tempDB in TempDB
                         join StudTmp in db.StudentSet on StCrTmp.StudentId equals StudTmp.StudentId
                         select new { StudentLastName = StudTmp.LastName, CourseName = tempDB.CourseName };

            return result;
        }
        [Route("api/Studentsrecords")]
        //Students with their grades records	
        public Object GetStudentsGrades()
        {
            var result = from StCrTmp in db.StudentsCourseSet
                         join CrTmp in db.CourseSet on StCrTmp.CourseId equals CrTmp.CourseId into TempDB
                         from tempDB in TempDB
                         join StudTmp in db.StudentSet on StCrTmp.StudentId equals StudTmp.StudentId
                         select new { StudentLastName = StudTmp.LastName, CourseName = tempDB.CourseName, Grades = StCrTmp.Appraisal };

            return result;
        }
        [Route("api/Studentsinfo")]
        //Students personal info with sorted by students names		
        public Object GetStudentsInfo()
        {
            var result = from StudTmp in db.StudentSet
                         orderby StudTmp.LastName
                         select StudTmp;

            return result;
        }
        [Route("api/Corses3enrolled")]
        //Corses with more then 3 students enrolled		
        public Object GetCourseCount()
        {
            var result = from StudCourTmp in db.StudentsCourseSet
                         where db.StudentsCourseSet.Count(X => X.CourseId == StudCourTmp.CourseId) > 3
                         join CrTmp in db.CourseSet on StudCourTmp.CourseId equals CrTmp.CourseId into TempDB
                         from tempDB in TempDB
                         join StudTmp in db.StudentSet on StudCourTmp.StudentId equals StudTmp.StudentId
                         select new { CourseName = tempDB.CourseName, HoursCount = tempDB.HoursNumber, StudentLastName = StudTmp.LastName, };

            return result;
        }
        [Route("api/Teachers1course")]
        //Teachers with only 1 course	
        public Object GetTeacherCount()
        {
            var result = from CourTmp in db.CourseSet
                         where db.CourseSet.Count(X => X.TeacherId == CourTmp.TeacherId) == 1
                         join TeachTmp in db.TeacherSet on CourTmp.TeacherId equals TeachTmp.TeacherId
                         select new { TeacherLastName = TeachTmp.LastName, CourseName = CourTmp.CourseName, HoursCount = CourTmp.HoursNumber };

            return result;
        }
    }
}
