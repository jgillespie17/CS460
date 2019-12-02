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
        public string NAME { get; set; }

        public float TIME { get; set; }

        public int? MeetID { get; set; }

        public int? AthleteID { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Meet Meet { get; set; }
    }
}
