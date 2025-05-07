using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required, DisplayFormat(DataFormatString = "0:dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateOnly StartDate { get; set; }
        [Required, DisplayFormat(DataFormatString = "0:dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateOnly DeadLine { get; set; }
        [Required, DisplayFormat(DataFormatString = "0:dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateOnly FinishDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
