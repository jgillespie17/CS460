using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw5.Models
{
    public class Homework
    {
        public int Urgency { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DueTime { get; set; }
        public string Department { get; set; }
        public int CourseNum { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
    }
}