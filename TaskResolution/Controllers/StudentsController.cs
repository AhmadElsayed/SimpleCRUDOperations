using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskResolution.Models;

namespace TaskResolution.Controllers
{
    public class StudentsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Students
        public List<Student> GetStudents()
        {
            return db.Students.Include("Subjects").ToList();
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.ID)
            {
                return BadRequest();
            }

            Student newStudent = db.Students.Include("Subjects").SingleOrDefault(x => x.ID == student.ID);
            newStudent.FirstName = student.FirstName;
            newStudent.Birthdate = student.Birthdate;
            newStudent.LastName = student.LastName;
            newStudent.MidName = student.MidName;
            newStudent.Number = student.Number;

            newStudent.Subjects.Clear();
            foreach (var item in student.Subjects)
            {
                var subject = db.Subjects.SingleOrDefault(x => x.ID == item.ID);
                newStudent.Subjects.Add(subject);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student newStudent = new Student();
            newStudent.FirstName = student.FirstName;
            newStudent.Birthdate = student.Birthdate;
            newStudent.LastName = student.LastName;
            newStudent.MidName = student.MidName;
            newStudent.Number = student.Number;
            newStudent.Subjects = new List<Subject>();
            foreach (var item in student.Subjects)
            {
                var subject = db.Subjects.SingleOrDefault(x => x.ID == item.ID);
                newStudent.Subjects.Add(subject);
            }
            db.Students.Add(newStudent);

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.ID }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}