using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01StudentSystem.Data.Common;


// ReSharper disable All

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            //this.CourseEnrollments = new HashSet<Course>();
            this.HomeworkSubmissions = new HashSet<Homework>();
            this.StudentCourses = new HashSet<StudentCourse>();
        }
        //Entities
        //DB Schema
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudetnNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

       
        public DateTime RegistеredOn { get; set; }

        public DateTime? Birthday { get; set; }

        //public virtual ICollection<Course> CourseEnrollments { get; set; }
        
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
