﻿using System.ComponentModel.DataAnnotations;

namespace APICLass.DTOs
{
   
    public class AddUserDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Only 3-15 characters allowed!")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength =3, ErrorMessage = "Only 3 - 15 characters allowed!")]
        public string LastName { get; set; }

        [Required]
        public string  Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Phonenumber { get; set; }


    }
}
    