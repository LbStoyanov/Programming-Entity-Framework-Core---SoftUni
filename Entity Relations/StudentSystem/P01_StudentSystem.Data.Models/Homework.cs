using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        public int SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
