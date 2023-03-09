namespace OnlineBookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order_item
    {
        public int id { get; set; }

        public int? idOrder { get; set; }

        public int? idBook { get; set; }

        public int? quantity { get; set; }

        public virtual books books { get; set; }
    }
}
