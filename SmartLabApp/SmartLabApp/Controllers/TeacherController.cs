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
    public class TeacherController : ApiController
    {
        ScheduleModelContainer1 db = new ScheduleModelContainer1();
        // GET api/values
        public IEnumerable<Teacher> Get()
        {
            return db.TeacherSet;
        }

        // GET api/values/5
        [HttpGet]
        public Teacher Get(int id)
        {
            return db.TeacherSet.Find(id);
        }

        public void Post(Teacher value)
        {
            db.TeacherSet.Add(value);
            db.SaveChanges();
        }

        public void Put(int id, Teacher value)
        {
            if (id == value.TeacherId)
            {
                db.Entry(value).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Teacher Teacher = db.TeacherSet.Find(id);
            if (Teacher != null)
            {
                db.TeacherSet.Remove(Teacher);
                db.SaveChanges();
            }
        }
    }
}
