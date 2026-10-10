using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
    }
    public class BookRequest
    {
        [Required(ErrorMessage ="Title is required")]
        [StringLength(100,MinimumLength =4,ErrorMessage ="Title name must be between 4 and 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Author name must be between 4 and 50 characters")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Category name must be between 4 and 50 characters")]
        public string Category { get; set; }
        [Required(ErrorMessage="Quantity is required")]
        public int Quantity { get; set; }
    }
   
}
