using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hw5.Models
{
    public class Homework
    {
        [Key]
        public int ID { get; set; }

        [Required, DisplayName("Urgency")]
        public int Urgency { get; set; }

        [Required, DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        [Required, DisplayName("Due Time")]
        public DateTime DueTime { get; set; }

        [Required, DisplayName("Department")]
        [StringLength(3)]
        public string Department { get; set; }
        
        [Required, DisplayName("Course #")]
        public int CourseNum { get; set; }

        [Required, DisplayName("Title")]
        [StringLength(64)]
        public string Title { get; set; }

        public string Notes { get; set; }
    }
}