using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartLabApp.Models;
using System.Data;
 

namespace SmartlabApp.Controllers
{
    public class StudentController : ApiController
    {
        ScheduleModelContainer1 db = new ScheduleModelContainer1();

        public IEnumerable<Student> Get()
        {
            return db.StudentSet;
        }

        [HttpGet]
        public Student Get(int id)
        {
            return db.StudentSet.Find(id);
        }

        public void Post(Student value)
        {
            db.StudentSet.Add(value);
            db.SaveChanges();
        }

        public void Put(int id, Student value)
        {
            if (id == value.StudentId)
            {
                db.Entry(value).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Student Student = db.StudentSet.Find(id);
            if (Student != null)
            {
                db.StudentSet.Remove(Student);
                db.SaveChanges();
            }
        }
    }
}
