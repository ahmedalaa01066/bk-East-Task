
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Users
{
    [Table("User", Schema = "Users")]

    public class User : BaseModel
    {

        public string Name { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public Role RoleId { get; set; }
        public VerifyStatus VerifyStatus { get; set; }
        public string? Token { get; set; }
        public string? OTP { get; set; }
        public string? OTPtoken { get; set; }
        public DateTime? OTPExpiration { get; set; }
        public Candidate Candidate { get; set; }
    }
}
