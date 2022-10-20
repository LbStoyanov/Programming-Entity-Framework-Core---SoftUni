using P01StudentSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ResourceNameMaxLength)]
        public string Name { get; set; }
        [MaxLength(GlobalConstants.ResourceUrlMaxLength)]
        public string Url { get; set; }
        [Required]
        public ResourceType ResourceType { get; set; }

        public int CourseID { get; set; }
    }
}
