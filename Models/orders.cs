namespace OnlineBookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class orders
    {
        public int id { get; set; }

        public int? idUser { get; set; }

        public double? totalPrice { get; set; }

        public DateTime? create_at { get; set; }

        public virtual users users { get; set; }
    }
}
