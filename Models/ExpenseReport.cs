using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseDiary.Models
{
    public class ExpenseReport
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(10,2)")]
        [DisplayFormat(DataFormatString = "")]
        [Required]
        public decimal Amount { get; set; }


        [DataType(DataType.Date)]   
        //[DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}",ApplyFormatInEditMode =true)]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime ExpenseDate { get; set; }=DateTime.Now;

        [Required]
        public string Category { get; set; }

    }
}
