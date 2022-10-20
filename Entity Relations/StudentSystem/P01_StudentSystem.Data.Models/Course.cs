using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using P01StudentSystem.Data.Common;
// ReSharper disable All

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        private ICollection<Student> studentsEnrolled;
        private ICollection<Resource> resources;
        private ICollection<Homework> homeworkSubmissions;

        public Course()
        {
            this.studentsEnrolled = new HashSet<Student>();
            this.resources = new HashSet<Resource>();
            this.homeworkSubmissions = new HashSet<Homework>();
        }
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CourseNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Student> StudentsEnrolled
        {
            get
            {
                return this.studentsEnrolled;
            }

            set
            {
                this.studentsEnrolled = value;
            }
        }


        public virtual ICollection<Resource> Resources
        {
            get
            {
                return this.resources;
            }

            set
            {
                this.resources = value;
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


