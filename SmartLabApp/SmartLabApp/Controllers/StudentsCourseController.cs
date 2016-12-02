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
    public class StudentsCourseController : ApiController
    {
        ScheduleModelContainer1 db = new ScheduleModelContainer1();

        public IEnumerable<StudentsCourse> Get()
        {
            return db.StudentsCourseSet;
        }

        [HttpGet]
        public StudentsCourse Get(int id)
        {
            return db.StudentsCourseSet.Find(id);
        }

        public void Post(StudentsCourse value)
        {
            db.StudentsCourseSet.Add(value);
            db.SaveChanges();
        }

        public void Put(int id, StudentsCourse value)
        {
            if (id == value.StudentsCourseId)
            {
                db.Entry(value).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            StudentsCourse StudentsCourse = db.StudentsCourseSet.Find(id);
            if (StudentsCourse != null)
            {
                db.StudentsCourseSet.Remove(StudentsCourse);
                db.SaveChanges();
            }
        }
    }
}
