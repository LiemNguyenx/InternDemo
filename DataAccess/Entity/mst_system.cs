namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mst_system
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int system_id { get; set; }

        public int config_value { get; set; }

        public int? display_order { get; set; }

        public bool? dest_flg { get; set; }

        public bool? sys_flg { get; set; }

        [StringLength(50)]
        public string member_new { get; set; }

        public DateTime? date_new { get; set; }

        [StringLength(50)]
        public string date_modify { get; set; }

        public DateTime? member_modify { get; set; }

        [StringLength(50)]
        public string admin_new { get; set; }

        public DateTime? admin_modify { get; set; }
    }
}
