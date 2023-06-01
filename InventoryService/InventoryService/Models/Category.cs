using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Category_Id", TypeName = "bigint")]
        [Required]
        public long CategoryId { get; set; }
        [Column("Category_Name")]
        public string? CategoryName { get; set; }
        [Column("Created_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
        public DateTime CreatedDate { get; set; }
        [Column("LastUpdated_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
        public DateTime LastUpdatedDate { get; set; }
        [Column("Created_By", TypeName = "varchar(200)")]
        public string? CreatedBy { get; set; }
        [Column("LastUpdated_By", TypeName = "varchar(200)")]
        public string? LastUpdatedBy { get; set; }

    }
}