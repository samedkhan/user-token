using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class Person
    {
        public int Id{ get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(200)]
        public string Token { get; set; }
    }
}