namespace hw8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Team()
        {
            Athletes = new HashSet<Athlete>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Team Name")]
        public string NAME { get; set; }

        public int? CoachID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Athlete> Athletes { get; set; }

        public virtual Coach Coach { get; set; }
    }
}
