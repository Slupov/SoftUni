using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01.Student_System.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime BirthDay { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}