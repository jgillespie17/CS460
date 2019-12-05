namespace hw8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaceResult
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Event Name")]
        public string NAME { get; set; }

        [Display(Name = "Result Time")]
        public float TIME { get; set; }

        public int? MeetID { get; set; }

        [Display(Name = "Athlete")]
        public int? AthleteID { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Meet Meet { get; set; }
    }
}
