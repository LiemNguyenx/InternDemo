namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mst_user
    {
        [Key]
        public int login_id { get; set; }

        [StringLength(500)]
        public string pass_login { get; set; }

        [StringLength(500)]
        public string loginkey { get; set; }

        public int? cnt_login_error { get; set; }

        public DateTime? date_login_error { get; set; }

        [StringLength(500)]
        public string mail { get; set; }

        public bool? use_flg { get; set; }

        public bool? dest_flg { get; set; }

        [StringLength(50)]
        public string code_cst { get; set; }

        [StringLength(50)]
        public string create_by { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(50)]
        public string update_by { get; set; }

        public DateTime? update_date { get; set; }

        public virtual mst_customer mst_customer { get; set; }
    }
}
