using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentientgeeksMVC.Models
{
    [Table("TblEmployee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [DisplayName("Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phoneno is required")]
        [DisplayName("Phoneno")]
        public string Phoneno { get; set; }
    }
}