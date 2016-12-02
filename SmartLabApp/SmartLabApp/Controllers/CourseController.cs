using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartLabApp.Models;
using System.Data;
 

namespace SmartApp.Controllers
{
    public class CourseController : ApiController
    {
        ScheduleModelContainer1 db = new ScheduleModelContainer1();

        public IEnumerable<Course> Get()
        {
            return db.CourseSet;
        }

        [HttpGet]
        public Course Get(int id)
        {
            return db.CourseSet.Find(id);
        }

        public void Post(Course value)
        {
            db.CourseSet.Add(value);
            db.SaveChanges();
        }

        public void Put(int id, Course value)
        {
            if (id == value.CourseId)
            {
                db.Entry(value).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Course Course = db.CourseSet.Find(id);
            if (Course != null)
            {
                db.CourseSet.Remove(Course);
                db.SaveChanges();
            }
        }
    }
}
