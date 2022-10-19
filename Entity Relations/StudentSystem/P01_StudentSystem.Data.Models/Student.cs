using System;
using System.ComponentModel.DataAnnotations;
using P01StudentSystem.Data.Common;


// ReSharper disable All

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        //Entities
        //DB Schema
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudetnNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.PhoneNumberMaxLength)]
        public int PhoneNumber { get; set; }

        public DateTime RegistrationOn { get; set; }

        public DateTime Birthday { get; set; }



    }
}
