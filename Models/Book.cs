namespace SelfAspNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        [StringLength(17)]
        public string isbn { get; set; }

        [Required]
        [StringLength(100)]
        public string title { get; set; }

        public int price { get; set; }

        [Required]
        [StringLength(30)]
        public string publisher { get; set; }

        [Column(TypeName = "date")]
        public DateTime publishDate { get; set; }

        public bool? cdrom { get; set; }
    }
}
