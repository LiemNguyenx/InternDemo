namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mst_mail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mail_id { get; set; }

        [StringLength(50)]
        public string from_address { get; set; }

        [StringLength(50)]
        public string subject { get; set; }

        [StringLength(500)]
        public string body { get; set; }

        [StringLength(50)]
        public string create_by { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(50)]
        public string update_by { get; set; }

        public DateTime? update_date { get; set; }
    }
}
