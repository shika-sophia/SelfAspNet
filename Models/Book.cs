/*
 * @see SelfAspNet / SampleAsp / NT05_DataSourceControl
 *      / EntityDataModel / LinqEntitySample.aspx.cs
 */

namespace SelfAspNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        [DisplayName("ISBN")]
        [Required(ErrorMessage="{0}は必須です。")]
        [StringLength(17)]
        [RegularExpression(
            "[0-9]{3}-[0-9]{1}-[0-9]{3,5}-[0-9]{3,5}-[0-9X]{1}",
            ErrorMessage="{0}は正しい形式で入力してください。")]
        public string isbn { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [StringLength(100, ErrorMessage="{0}は {1}文字以内で入力してください。")]
        public string title { get; set; }

        [DisplayName("Price")]
        [Range(0,10000, ErrorMessage="{0}は {1}～{2}の範囲で入力してください。")]
        public int price { get; set; }

        [DisplayName("Publisher")]
        [Required]
        [StringLength(30)]
        public string publisher { get; set; }

        [DisplayName("Publish Date")]
        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        public DateTime publishDate { get; set; }

        [DisplayName("CD-ROM")]
        public bool? cdrom { get; set; }
    }//class
}
