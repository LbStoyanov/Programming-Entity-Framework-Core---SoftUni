using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using P01StudentSystem.Data.Common;


// ReSharper disable All

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {

        private ICollection<Course> courseEnrollments;
        private ICollection<Homework> homeworkSubmissions;

        public Student()
        {
            this.courseEnrollments = new HashSet<Course>();
            this.homeworkSubmissions = new HashSet<Homework>();
        }
        //Entities
        //DB Schema
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudetnNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.PhoneNumberMaxLength)]
        public int PhoneNumber { get; set; }

        public DateTime RegistеredOn { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> CourseEnrollments
        {
            get
            {
                return this.courseEnrollments;
            }

            set
            {
                this.courseEnrollments = value;
            }
        }

        public virtual ICollection<Homework> HomeworkSubmissions
        {
            get
            {
                return this.homeworkSubmissions;
            }
            set
            {
                this.homeworkSubmissions = value;
            }
        }



    }
}
