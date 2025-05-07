using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "0:dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
