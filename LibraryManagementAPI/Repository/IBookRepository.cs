using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Interface
{
    public interface IBookRepository
    {
        Task<CommonResponse> GetAllBooks();
        Task<CommonResponse> GetBookById(int id);
        Task<CommonResponse> InsertBook(BookRequest request);
        Task<CommonResponse> UpdateBook(int id, BookRequest request);
        Task<CommonResponse> DeleteBook(int id);
        Task<CommonResponse> SearchBooks(string search);
    }
}
