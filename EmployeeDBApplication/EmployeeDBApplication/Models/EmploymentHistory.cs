namespace EmployeeDBApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmploymentHistory")]
    public partial class EmploymentHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_EmploymentHistory { get; set; }

        [Column(TypeName = "date")]
        public DateTime EmploymentDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfDismissal { get; set; }

        public int Id_Employee { get; set; }

        public byte Experience { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
