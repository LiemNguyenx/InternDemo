namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mst_customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mst_customer()
        {
            mst_user = new HashSet<mst_user>();
        }

        [Key]
        [StringLength(50)]
        public string code_cst { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public bool? dest_flg { get; set; }

        [StringLength(50)]
        public string create_by { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(50)]
        public string update_by { get; set; }

        public DateTime? update_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mst_user> mst_user { get; set; }
    }
}
