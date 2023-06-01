using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryService.Models
{
    [Owned]
    public class ProductDescription
    {
        [Column("Summary", TypeName = "varchar(200)")]
        public string? Summary { get; set; }
        [Column("DOP")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
        public DateTime DOP { get; set; }
        [Column("DOE")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
        public DateTime DOE { get; set; }
        [Column("Cost")]
        public long Cost { get; set; }
    }
}