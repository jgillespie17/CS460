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

        [Required]
        public int Urgency { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime DueTime { get; set; }

        [Required]
        [StringLength(32)]
        public string Department { get; set; }

        [Required]
        public int Course { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [Required]
        [StringLength(512)]
        public string Notes { get; set; }


    }
}