namespace OnlineBookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public books()
        {
            order_item = new HashSet<order_item>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string author { get; set; }

        [StringLength(255)]
        public string decription { get; set; }

        public int? public_date { get; set; }

        [StringLength(255)]
        public string category { get; set; }

        public double? price { get; set; }

        public string image_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_item> order_item { get; set; }
    }
}
