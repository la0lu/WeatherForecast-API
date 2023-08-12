using System.ComponentModel.DataAnnotations;

namespace APICLass.DTOs
{
    public class ReturnUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phonenumber { get; set; } = "";
    }
}
