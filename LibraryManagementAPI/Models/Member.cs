using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class MemberRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^[0-9]{10}$",ErrorMessage ="Phone number must contain 10 digits")]
        public string Phone { get; set; }
    }
    public class MemberResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<CurrentBorrowingResponse> CurrentBorrowings { get; set; }
        public List<BorrowingHistoryResponse> BorrowingHistory { get; set; }
    }

}
