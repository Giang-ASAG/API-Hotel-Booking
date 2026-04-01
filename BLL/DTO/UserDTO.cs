using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class UserDTO
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }

        public string? Address { get; set; }
        public bool? Active { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreationDate { get; set; }

        public int? UserRoleId { get; set; }
    }
    public class UserNoPasswordDTO
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }
        public int? UserRoleId { get; set; }

        public bool? Active { get; set; }
    }
}
